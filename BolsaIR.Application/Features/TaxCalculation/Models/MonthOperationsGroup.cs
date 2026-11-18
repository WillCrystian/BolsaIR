using BolsaIR.Application.Features.TaxCalculation.DTOs;

namespace BolsaIR.Application.Features.TaxCalculation.Models;

public sealed class MonthOperationsGroup
{
	public int Year { get; init; }

	public int Month { get; init; }

	public List<OperationForTaxCalculation> Operations { get; init; } = [];
}