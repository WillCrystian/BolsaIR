using BolsaIR.Application.Features.TaxCalculation.Results;
using BolsaIR.Application.Features.TaxCalculation.Services;

namespace BolsaIR.Infrastructure.Services.TaxCalculation;

public sealed class TaxRateCalculator : ITaxRateCalculator
{
	private const decimal CommonRate = 0.15m;
	private const decimal FiiRate = 0.20m;
	private const decimal DayTradeRate = 0.20m;

	public void Calculate(MonthlyTaxResult month)
	{
		ArgumentNullException.ThrowIfNull(month);

		// ============================================================
		// COMUM
		// ============================================================

		month.CommonTaxRate =
			month.CommonTaxableProfit > 0m
				? CommonRate
				: 0m;

		// ============================================================
		// FII
		// ============================================================

		month.FiiTaxRate =
			month.FiiTaxableProfit > 0m
				? FiiRate
				: 0m;

		// ============================================================
		// DAY TRADE
		// ============================================================

		month.DayTradeTaxRate =
			month.DayTradeTaxableProfit > 0m
				? DayTradeRate
				: 0m;
	}
}