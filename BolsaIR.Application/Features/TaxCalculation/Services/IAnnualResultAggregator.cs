using BolsaIR.Application.Features.TaxCalculation.Results;

namespace BolsaIR.Application.Features.TaxCalculation.Services;

public interface IAnnualResultAggregator
{
	void AddMonth(
		AnnualTaxResult annualResult,
		MonthlyTaxResult monthlyResult);
}