using BolsaIR.Application.Features.TaxCalculation.Results;

namespace BolsaIR.Application.Features.TaxCalculation.Services;

public interface IExemptionCalculator
{
	bool IsExempt(MonthlyTaxResult monthlyResult);
}