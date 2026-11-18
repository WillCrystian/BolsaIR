using BolsaIR.Application.Features.TaxCalculation.Results;
using BolsaIR.Application.Features.TaxCalculation.Services;

namespace BolsaIR.Infrastructure.Services.TaxCalculation;

public sealed class TaxCalculationQueryService : ITaxCalculationQueryService
{
	private readonly ITaxCalculationEngine _taxCalculationEngine;

	public TaxCalculationQueryService(
		ITaxCalculationEngine taxCalculationEngine)
	{
		_taxCalculationEngine = taxCalculationEngine;
	}

	public async Task<AnnualTaxResult> GetAnnualCalculationAsync(
		int year,
		CancellationToken cancellationToken = default)
	{
		return await _taxCalculationEngine.CalculateAsync(
			year,
			cancellationToken);
	}
}