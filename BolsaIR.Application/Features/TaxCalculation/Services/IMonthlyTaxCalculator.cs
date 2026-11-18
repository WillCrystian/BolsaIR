using BolsaIR.Application.Features.TaxCalculation.Models;
using BolsaIR.Application.Features.TaxCalculation.Results;

namespace BolsaIR.Application.Features.TaxCalculation.Services;

public interface IMonthlyTaxCalculator
{
	void Calculate(
		MonthOperationsGroup month,
		MonthlyTaxResult result);
}