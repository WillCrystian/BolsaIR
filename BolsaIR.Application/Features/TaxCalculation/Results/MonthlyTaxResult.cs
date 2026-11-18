namespace BolsaIR.Application.Features.TaxCalculation.Results;

public class MonthlyTaxResult
{
	public int Year { get; set; }

	public int Month { get; set; }

	// ==========================================
	// COMUM
	// ==========================================

	public decimal CommonPurchases { get; set; }

	public decimal CommonSales { get; set; }

	public decimal CommonProfit { get; set; }

	public decimal CommonLoss { get; set; }

	public decimal CommonTaxableProfit { get; set; }

	public decimal CommonTax { get; set; }

	public decimal CommonAccumulatedLossBefore { get; set; }

	public decimal CommonAccumulatedLossUsed { get; set; }

	public decimal CommonAccumulatedLossAfter { get; set; }
	public decimal CommonStockSales { get; set; }
	public decimal CommonStockProfit { get; set; }
	public decimal CommonStockLoss { get; set; }

	// ==========================================
	// FII
	// ==========================================

	public decimal FiiPurchases { get; set; }

	public decimal FiiSales { get; set; }

	public decimal FiiProfit { get; set; }

	public decimal FiiLoss { get; set; }

	public decimal FiiTaxableProfit { get; set; }

	public decimal FiiTax { get; set; }

	public decimal FiiAccumulatedLossBefore { get; set; }

	public decimal FiiAccumulatedLossUsed { get; set; }

	public decimal FiiAccumulatedLossAfter { get; set; }

	// ==========================================
	// DAY TRADE
	// ==========================================

	public decimal DayTradePurchases { get; set; }

	public decimal DayTradeSales { get; set; }

	public decimal DayTradeProfit { get; set; }

	public decimal DayTradeLoss { get; set; }

	public decimal DayTradeTaxableProfit { get; set; }

	public decimal DayTradeTax { get; set; }

	public decimal DayTradeAccumulatedLossBefore { get; set; }

	public decimal DayTradeAccumulatedLossUsed { get; set; }

	public decimal DayTradeAccumulatedLossAfter { get; set; }

	// ==========================================
	// GERAL
	// ==========================================

	public decimal TotalFees { get; set; }

	public decimal Irrf { get; set; }

	public decimal TaxDue { get; set; }

	public decimal DarfValue { get; set; }

	public decimal FinalProfit { get; set; }

	public bool IsExempt { get; set; }


	public decimal CommonTaxRate { get; set; }

	public decimal FiiTaxRate { get; set; }

	public decimal DayTradeTaxRate { get; set; }





	public decimal TotalPurchases =>
		CommonPurchases +
		FiiPurchases +
		DayTradePurchases;

	public decimal TotalSales =>
		CommonSales +
		FiiSales +
		DayTradeSales;

	public decimal TotalTaxableProfit =>
		CommonTaxableProfit +
		FiiTaxableProfit +
		DayTradeTaxableProfit;

	public decimal TotalTax =>
		CommonTax +
		FiiTax +
		DayTradeTax;

	public List<OperationCalculationResult> Operations { get; set; }
		= new();
}