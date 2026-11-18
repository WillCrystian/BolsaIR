using BolsaIR.Application.Features.TaxCalculation.Results;

namespace BolsaIR.Application.Features.TaxCalculation.Contexts;

public sealed class MonthlyTaxCalculationContext
{
	public required int Year { get; init; }

	public required int Month { get; init; }

	public List<OperationCalculationResult> Operations { get; init; } = [];

	public required MonthlyTaxResult Result { get; init; }
}