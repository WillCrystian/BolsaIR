using BolsaIR.Application.Features.TaxCalculation.Results;

namespace BolsaIR.Application.Features.TaxCalculation.Services;

public interface ILossCompensationCalculator
{
	void Apply(
		MonthlyTaxResult result,
		decimal commonAccumulatedLoss,
		decimal fiiAccumulatedLoss,
		decimal dayTradeAccumulatedLoss);
}