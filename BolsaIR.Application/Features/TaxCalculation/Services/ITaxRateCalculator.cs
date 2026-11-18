using BolsaIR.Application.Features.TaxCalculation.Results;

namespace BolsaIR.Application.Features.TaxCalculation.Services;

public interface ITaxRateCalculator
{
	void Calculate(MonthlyTaxResult month);
}