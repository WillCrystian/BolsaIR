namespace BolsaIR.Application.Features.TaxCalculation.Results;

public sealed class AnnualTaxResult
{
	public int Year { get; init; }

	public List<MonthlyTaxResult> Months { get; } = [];

	// ==========================================
	// CONSOLIDAÇÃO ANUAL
	// ==========================================

	public decimal TotalPurchases { get; set; }

	public decimal TotalSales { get; set; }

	public decimal NetProfit { get; set; }

	public decimal TotalFees { get; set; }

	public decimal TotalIrrf { get; set; }

	public decimal TotalTaxableProfit { get; set; }

	public decimal TotalTaxDue { get; set; }

	public decimal TotalDarf { get; set; }

	// ==========================================
	// PREJUÍZOS
	// ==========================================

	public decimal CommonAccumulatedLossCarryForward { get; set; }

	public decimal FiiAccumulatedLossCarryForward { get; set; }

	public decimal DayTradeAccumulatedLossCarryForward { get; set; }



	public decimal CommonPurchases { get; set; }
	public decimal CommonSales { get; set; }
	public decimal CommonProfit { get; set; }
	public decimal CommonLoss { get; set; }
	public decimal CommonTaxableProfit { get; set; }
	public decimal CommonTax { get; set; }
	public decimal FiiPurchases { get; set; }
	public decimal FiiSales { get; set; }
	public decimal FiiProfit { get; set; }
	public decimal FiiLoss { get; set; }
	public decimal FiiTaxableProfit { get; set; }
	public decimal FiiTax { get; set; }

	public decimal DayTradePurchases { get; set; }
	public decimal DayTradeSales { get; set; }
	public decimal DayTradeProfit { get; set; }
	public decimal DayTradeLoss { get; set; }
	public decimal DayTradeTaxableProfit { get; set; }
	public decimal DayTradeTax { get; set; }
	public decimal FinalProfit { get; set; }

	// ==========================================
	// AUXILIARES
	// ==========================================

	public bool HasProfit =>
		NetProfit > 0;

	public bool HasTaxToPay =>
		TotalDarf > 0;
}