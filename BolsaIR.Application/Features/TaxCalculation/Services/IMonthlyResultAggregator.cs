using BolsaIR.Application.Features.TaxCalculation.DTOs;
using BolsaIR.Application.Features.TaxCalculation.Results;

namespace BolsaIR.Application.Features.TaxCalculation.Services;

public interface IMonthlyResultAggregator
{
	void AddOperation(
		MonthlyTaxResult monthResult,
		OperationForTaxCalculation operation,
		OperationCalculationResult calculation);
}