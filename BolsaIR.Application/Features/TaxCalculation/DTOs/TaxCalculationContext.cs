using BolsaIR.Domain.Entities;

namespace BolsaIR.Application.Features.TaxCalculation.DTOs;

public sealed class TaxCalculationContext
{
	public required Position Position { get; init; }

	public required Operation Operation { get; init; }

	public ProfitCalculationResult? Profit { get; set; }

	// Acumuladores
	public decimal MonthlySales { get; set; }

	public decimal MonthlyCost { get; set; }

	public decimal MonthlyGrossProfit { get; set; }

	public decimal MonthlyNetProfit { get; set; }

	// Prejuízo
	public decimal AccumulatedLoss { get; set; }

	public decimal MonthlyTaxableProfit { get; set; }

	// IR
	public decimal Irrf { get; set; }

	public decimal TaxRate { get; set; }

	public decimal TaxDue { get; set; }

	// Controle
	public bool IsExempt { get; set; }

	public bool IsDayTrade { get; set; }
}