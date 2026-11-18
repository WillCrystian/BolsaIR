using BolsaIR.Application.Features.Operations.Services;
using BolsaIR.Application.Features.TaxCalculation.Models;
using BolsaIR.Application.Features.TaxCalculation.Results;
using BolsaIR.Application.Features.TaxCalculation.Services;

namespace BolsaIR.Infrastructure.Services.TaxCalculation;

public sealed class TaxCalculationEngine : ITaxCalculationEngine
{
	private readonly IOperationReadService _operationReadService;
	private readonly IMonthlyProcessor _monthlyProcessor;
	private readonly IAnnualResultAggregator _annualAggregator;
	private readonly ILossCompensationCalculator _lossCompensationCalculator;
	private readonly ITaxRateCalculator _taxRateCalculator;
	private readonly IDarfCalculator _darfCalculator;
	private readonly IExemptionRule _exemptionRule;

	public TaxCalculationEngine(
		IOperationReadService operationReadService,
		IMonthlyProcessor monthlyProcessor,
		ILossCompensationCalculator lossCompensationCalculator,
		ITaxRateCalculator taxRateCalculator,
		IDarfCalculator darfCalculator,
		IAnnualResultAggregator annualAggregator,
		IExemptionRule exemptionRule)
	{
		_operationReadService = operationReadService;
		_monthlyProcessor = monthlyProcessor;
		_lossCompensationCalculator = lossCompensationCalculator;
		_taxRateCalculator = taxRateCalculator;
		_darfCalculator = darfCalculator;
		_annualAggregator = annualAggregator;
		_exemptionRule = exemptionRule;
	}

	public async Task<AnnualTaxResult> CalculateAsync(
		int year,
		CancellationToken cancellationToken = default)
	{
		var operations =
			await _operationReadService.GetAllForTaxCalculationAsync(
				year,
				cancellationToken);

		var annualResult = new AnnualTaxResult
		{
			Year = year
		};

		var months =
			operations
				.GroupBy(x => new
				{
					x.SettlementDate.Year,
					x.SettlementDate.Month
				})
				.OrderBy(x => x.Key.Year)
				.ThenBy(x => x.Key.Month);

		// ==========================================
		// PREJUÍZOS ACUMULADOS
		// ==========================================

		decimal commonAccumulatedLoss = 0m;
		decimal fiiAccumulatedLoss = 0m;
		decimal dayTradeAccumulatedLoss = 0m;

		// ==========================================
		// POSIÇÕES
		// ==========================================

		var positions =
			new Dictionary<Guid, PositionSnapshot>();

		foreach (var month in months)
		{
			var group = new MonthOperationsGroup
			{
				Year = month.Key.Year,
				Month = month.Key.Month,
				Operations = month
					.OrderBy(x => x.SettlementDate)
					.ThenBy(x => x.OperationId)
					.ToList()
			};

			// ==========================================
			// PROCESSA MÊS
			// ==========================================

			var monthlyResult =
				await _monthlyProcessor.ProcessAsync(
					group,
					positions,
					cancellationToken);

			// ==========================================
			// COMPENSAÇÃO DE PREJUÍZO
			// ==========================================

			_lossCompensationCalculator.Apply(
				monthlyResult,
				commonAccumulatedLoss,
				fiiAccumulatedLoss,
				dayTradeAccumulatedLoss);

			// ==========================================
			// ISENÇÃO
			// ==========================================

			_exemptionRule.Apply(monthlyResult);

			// ==========================================
			// ALÍQUOTAS
			// ==========================================

			_taxRateCalculator.Calculate(monthlyResult);

			// ==========================================
			// DARF
			// ==========================================

			_darfCalculator.Calculate(monthlyResult);

			// ==========================================
			// ATUALIZA PREJUÍZOS
			// ==========================================

			commonAccumulatedLoss =
				monthlyResult.CommonAccumulatedLossAfter;

			fiiAccumulatedLoss =
				monthlyResult.FiiAccumulatedLossAfter;

			dayTradeAccumulatedLoss =
				monthlyResult.DayTradeAccumulatedLossAfter;

			// ==========================================
			// CONSOLIDA ANO
			// ==========================================

			_annualAggregator.AddMonth(
				annualResult,
				monthlyResult);
		}

		// ==========================================
		// PREJUÍZO PARA O PRÓXIMO ANO
		// ==========================================

		annualResult.CommonAccumulatedLossCarryForward =
			commonAccumulatedLoss;

		annualResult.FiiAccumulatedLossCarryForward =
			fiiAccumulatedLoss;

		annualResult.DayTradeAccumulatedLossCarryForward =
			dayTradeAccumulatedLoss;

		return annualResult;
	}
}