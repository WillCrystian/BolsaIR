using BolsaIR.Application.Features.TaxCalculation.DTOs;

namespace BolsaIR.Application.Features.TaxCalculation.Services;

public interface IMonthlyResultCalculator
{
	void Process(TaxCalculationContext context);
}