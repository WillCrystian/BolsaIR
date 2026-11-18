using BolsaIR.Application.Features.TaxCalculation.Results;
using BolsaIR.Application.Features.TaxCalculation.Services;

namespace BolsaIR.Infrastructure.Services.TaxCalculation;

public sealed class LossCalculator : ILossCalculator
{
	public LossCalculationResult Calculate(
		decimal accumulatedLoss,
		decimal monthProfit)
	{
		if (monthProfit <= 0)
		{
			return new LossCalculationResult
			{
				PreviousAccumulatedLoss = accumulatedLoss,

				ProfitBeforeCompensation = monthProfit,

				CompensatedLoss = 0,

				TaxableProfit = 0,

				RemainingAccumulatedLoss =
					accumulatedLoss + Math.Abs(monthProfit)
			};
		}

		var compensated =
			Math.Min(accumulatedLoss, monthProfit);

		return new LossCalculationResult
		{
			PreviousAccumulatedLoss = accumulatedLoss,

			ProfitBeforeCompensation = monthProfit,

			CompensatedLoss = compensated,

			TaxableProfit =
				monthProfit - compensated,

			RemainingAccumulatedLoss =
				accumulatedLoss - compensated
		};
	}
}