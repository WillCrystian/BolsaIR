using BolsaIR.Domain.Entities;

namespace BolsaIR.Application.Features.TaxCalculation.DTOs;

public sealed class MonthlyTaxCalculationContext
{
	public required List<Operation> Operations { get; init; }

	public decimal TotalSales { get; set; }

	public decimal GrossProfit { get; set; }

	public decimal NetProfit { get; set; }

	public decimal TotalFees { get; set; }

	public decimal Irrf { get; set; }

	public decimal TaxRate { get; set; }

	public decimal TaxDue { get; set; }

	public bool IsExempt { get; set; }
}