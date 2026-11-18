using BolsaIR.Application.Features.TaxCalculation.Results;

namespace BolsaIR.Application.Features.TaxCalculation.Services;

public interface ITaxCalculationQueryService
{
	Task<AnnualTaxResult> GetAnnualCalculationAsync(
		int year,
		CancellationToken cancellationToken = default);
}