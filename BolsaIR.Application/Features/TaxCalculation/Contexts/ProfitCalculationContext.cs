using BolsaIR.Domain.Entities;

namespace BolsaIR.Application.Features.TaxCalculation.Contexts;

public sealed class ProfitCalculationContext
{
	public required Position Position { get; init; }

	public required Operation Operation { get; init; }
}