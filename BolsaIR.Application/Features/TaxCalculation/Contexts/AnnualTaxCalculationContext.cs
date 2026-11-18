using BolsaIR.Application.Features.TaxCalculation.Results;

namespace BolsaIR.Application.Features.TaxCalculation.Contexts;

public sealed class AnnualTaxCalculationContext
{
	public required int Year { get; init; }

	public List<MonthlyTaxResult> Months { get; init; } = [];

	public required AnnualTaxResult Result { get; init; }
}