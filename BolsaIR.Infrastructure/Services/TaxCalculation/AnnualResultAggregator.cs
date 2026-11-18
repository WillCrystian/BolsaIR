using BolsaIR.Application.Features.TaxCalculation.Results;
using BolsaIR.Application.Features.TaxCalculation.Services;

namespace BolsaIR.Infrastructure.Services.TaxCalculation;

public sealed class AnnualResultAggregator
	: IAnnualResultAggregator
{
	public void AddMonth(
		AnnualTaxResult annualResult,
		MonthlyTaxResult month)
	{
		ArgumentNullException.ThrowIfNull(annualResult);
		ArgumentNullException.ThrowIfNull(month);

		annualResult.Months.Add(month);

		// ============================================================
		// COMUM
		// ============================================================

		annualResult.CommonPurchases +=
			month.CommonPurchases;

		annualResult.CommonSales +=
			month.CommonSales;

		annualResult.CommonProfit +=
			month.CommonProfit;

		annualResult.CommonLoss +=
			month.CommonLoss;

		annualResult.CommonTaxableProfit +=
			month.CommonTaxableProfit;

		annualResult.CommonTax +=
			month.CommonTax;

		annualResult.CommonAccumulatedLossCarryForward =
			month.CommonAccumulatedLossAfter;

		// ============================================================
		// FII
		// ============================================================

		annualResult.FiiPurchases +=
			month.FiiPurchases;

		annualResult.FiiSales +=
			month.FiiSales;

		annualResult.FiiProfit +=
			month.FiiProfit;

		annualResult.FiiLoss +=
			month.FiiLoss;

		annualResult.FiiTaxableProfit +=
			month.FiiTaxableProfit;

		annualResult.FiiTax +=
			month.FiiTax;

		annualResult.FiiAccumulatedLossCarryForward =
			month.FiiAccumulatedLossAfter;

		// ============================================================
		// DAY TRADE
		// ============================================================

		annualResult.DayTradePurchases +=
			month.DayTradePurchases;

		annualResult.DayTradeSales +=
			month.DayTradeSales;

		annualResult.DayTradeProfit +=
			month.DayTradeProfit;

		annualResult.DayTradeLoss +=
			month.DayTradeLoss;

		annualResult.DayTradeTaxableProfit +=
			month.DayTradeTaxableProfit;

		annualResult.DayTradeTax +=
			month.DayTradeTax;

		annualResult.DayTradeAccumulatedLossCarryForward =
			month.DayTradeAccumulatedLossAfter;

		// ============================================================
		// GERAL
		// ============================================================

		annualResult.TotalFees +=
			month.TotalFees;

		annualResult.TotalIrrf +=
			month.Irrf;

		annualResult.TotalTaxDue +=
			month.TaxDue;

		annualResult.TotalDarf +=
			month.DarfValue;

		annualResult.FinalProfit +=
			month.FinalProfit;
	}
}