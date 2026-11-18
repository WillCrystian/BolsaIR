using BolsaIR.Application.Features.TaxCalculation.Results;

namespace BolsaIR.Application.Features.TaxCalculation.Services;

public interface IExemptionRule
{
	void Apply(MonthlyTaxResult month);
}