using BolsaIR.Application.Features.TaxCalculation.DTOs;

namespace BolsaIR.Application.Features.TaxCalculation.Models;

public sealed class YearOperationsGroup
{
	public int Year { get; init; }

	public List<MonthOperationsGroup> Months { get; init; } = [];
}