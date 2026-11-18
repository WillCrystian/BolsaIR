using BolsaIR.Application.Features.TaxCalculation.Results;
using BolsaIR.Application.Features.TaxCalculation.Services;

namespace BolsaIR.Infrastructure.Services.TaxCalculation;

public sealed class DarfCalculator : IDarfCalculator
{
	public void Calculate(MonthlyTaxResult month)
	{
		ArgumentNullException.ThrowIfNull(month);

		// ============================================================
		// IMPOSTO DEVIDO POR GRUPO
		// ============================================================

		var commonTax =
			month.CommonTaxableProfit *
			month.CommonTaxRate;

		var fiiTax =
			month.FiiTaxableProfit *
			month.FiiTaxRate;

		var dayTradeTax =
			month.DayTradeTaxableProfit *
			month.DayTradeTaxRate;

		month.CommonTax = Math.Max(0m, commonTax);
		month.FiiTax = Math.Max(0m, fiiTax);
		month.DayTradeTax = Math.Max(0m, dayTradeTax);

		// ============================================================
		// TOTAL DO IMPOSTO
		// ============================================================

		month.TaxDue =
			month.CommonTax +
			month.FiiTax +
			month.DayTradeTax;

		// ============================================================
		// DARF
		// ============================================================

		var darf =
			month.TaxDue -
			month.Irrf;

		month.DarfValue =
			Math.Max(0m, darf);

		// ============================================================
		// RESULTADO FINAL
		// ============================================================

		month.FinalProfit =
			(month.CommonProfit - month.CommonLoss) +
			(month.FiiProfit - month.FiiLoss) +
			(month.DayTradeProfit - month.DayTradeLoss);
	}
}