using BolsaIR.Application.Features.TaxCalculation.Results;
using BolsaIR.Application.Features.TaxCalculation.Services;

namespace BolsaIR.Infrastructure.Services.TaxCalculation;

public sealed class LossCompensationCalculator
	: ILossCompensationCalculator
{
	public void Apply(
		MonthlyTaxResult result,
		decimal commonAccumulatedLoss,
		decimal fiiAccumulatedLoss,
		decimal dayTradeAccumulatedLoss)
	{
		ArgumentNullException.ThrowIfNull(result);

		ApplyCommon(result, commonAccumulatedLoss);

		ApplyFii(result, fiiAccumulatedLoss);

		ApplyDayTrade(result, dayTradeAccumulatedLoss);
	}

	private static void ApplyCommon(
		MonthlyTaxResult result,
		decimal accumulatedLoss)
	{
		var profit =
			result.CommonProfit -
			result.CommonLoss;

		result.CommonAccumulatedLossBefore =
			accumulatedLoss;

		if (profit <= 0)
		{
			result.CommonAccumulatedLossUsed = 0m;

			result.CommonAccumulatedLossAfter =
				accumulatedLoss + Math.Abs(profit);

			result.CommonTaxableProfit = 0m;

			return;
		}

		var used =
			Math.Min(
				accumulatedLoss,
				profit);

		result.CommonAccumulatedLossUsed = used;

		result.CommonAccumulatedLossAfter =
			accumulatedLoss - used;

		result.CommonTaxableProfit =
			profit - used;
	}

	private static void ApplyFii(
		MonthlyTaxResult result,
		decimal accumulatedLoss)
	{
		var profit =
			result.FiiProfit -
			result.FiiLoss;

		result.FiiAccumulatedLossBefore =
			accumulatedLoss;

		if (profit <= 0)
		{
			result.FiiAccumulatedLossUsed = 0m;

			result.FiiAccumulatedLossAfter =
				accumulatedLoss + Math.Abs(profit);

			result.FiiTaxableProfit = 0m;

			return;
		}

		var used =
			Math.Min(
				accumulatedLoss,
				profit);

		result.FiiAccumulatedLossUsed = used;

		result.FiiAccumulatedLossAfter =
			accumulatedLoss - used;

		result.FiiTaxableProfit =
			profit - used;
	}

	private static void ApplyDayTrade(
		MonthlyTaxResult result,
		decimal accumulatedLoss)
	{
		var profit =
			result.DayTradeProfit -
			result.DayTradeLoss;

		result.DayTradeAccumulatedLossBefore =
			accumulatedLoss;

		if (profit <= 0)
		{
			result.DayTradeAccumulatedLossUsed = 0m;

			result.DayTradeAccumulatedLossAfter =
				accumulatedLoss + Math.Abs(profit);

			result.DayTradeTaxableProfit = 0m;

			return;
		}

		var used =
			Math.Min(
				accumulatedLoss,
				profit);

		result.DayTradeAccumulatedLossUsed = used;

		result.DayTradeAccumulatedLossAfter =
			accumulatedLoss - used;

		result.DayTradeTaxableProfit =
			profit - used;
	}
}