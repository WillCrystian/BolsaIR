using BolsaIR.Application.Features.TaxCalculation.Results;

namespace BolsaIR.Application.Features.TaxCalculation.Services;

public interface ITaxCalculationEngine
{
	Task<AnnualTaxResult> CalculateAsync(
		int year,
		CancellationToken cancellationToken = default);
}