using BolsaIR.Application.Features.TaxCalculation.Results;

namespace BolsaIR.Application.Features.TaxCalculation.Services;

public interface IDarfCalculator
{
	void Calculate(MonthlyTaxResult month);
}