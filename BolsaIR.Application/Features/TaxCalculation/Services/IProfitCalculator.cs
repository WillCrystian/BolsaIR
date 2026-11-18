using BolsaIR.Application.Features.TaxCalculation.DTOs;
using BolsaIR.Application.Features.TaxCalculation.Models;
using BolsaIR.Application.Features.TaxCalculation.Results;

namespace BolsaIR.Application.Features.TaxCalculation.Services;

public interface IProfitCalculator
{
	OperationCalculationResult Calculate(
		PositionSnapshot position,
		OperationForTaxCalculation operation);
}