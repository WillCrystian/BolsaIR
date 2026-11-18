using BolsaIR.Application.Features.TaxCalculation.Models;

namespace BolsaIR.Application.Features.TaxCalculation.Services;

public interface ITaxCalculationDataProvider
{
	Task<YearOperationsGroup> GetYearAsync(
		int year,
		CancellationToken cancellationToken = default);
}