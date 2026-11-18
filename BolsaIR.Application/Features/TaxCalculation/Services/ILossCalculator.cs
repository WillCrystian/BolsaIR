using BolsaIR.Application.Features.TaxCalculation.Results;

namespace BolsaIR.Application.Features.TaxCalculation.Services;

public interface ILossCalculator
{
	LossCalculationResult Calculate(
		decimal accumulatedLoss,
		decimal monthProfit);
}