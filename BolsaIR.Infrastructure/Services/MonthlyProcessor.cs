using BolsaIR.Application.Features.TaxCalculation.Models;
using BolsaIR.Application.Features.TaxCalculation.Results;
using BolsaIR.Application.Features.TaxCalculation.Services;
using BolsaIR.Infrastructure.Services.TaxCalculation;

namespace BolsaIR.Infrastructure.Services;

public sealed class MonthlyProcessor : IMonthlyProcessor
{
	private readonly IProfitCalculator _profitCalculator;
	private readonly IMonthlyResultAggregator _monthlyResultAggregator;
	private readonly IPositionSnapshotService _positionSnapshotService ;

	public MonthlyProcessor(
		IProfitCalculator profitCalculator,
		IMonthlyResultAggregator aggregator,
		IPositionSnapshotService positionSnapshotService
		)
	{
		_profitCalculator = profitCalculator;
		_monthlyResultAggregator = aggregator;
		_positionSnapshotService = positionSnapshotService;
	}

	public Task<MonthlyTaxResult> ProcessAsync(
		MonthOperationsGroup month,
		Dictionary<Guid, PositionSnapshot> positions,
		CancellationToken cancellationToken = default)
	{
		var result = new MonthlyTaxResult
		{
			Year = month.Year,
			Month = month.Month
		};

		foreach (var operation in month.Operations)
		{
			var snapshot =
				_positionSnapshotService.GetOrCreate(
					positions,
					operation);

			var calculation =
				_profitCalculator.Calculate(
					snapshot,
					operation);

			_monthlyResultAggregator.AddOperation(
				result,
				operation,
				calculation);
		}

		return Task.FromResult(result);
	}
}
