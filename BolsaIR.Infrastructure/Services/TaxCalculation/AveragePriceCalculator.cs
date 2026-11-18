using BolsaIR.Application.Features.TaxCalculation.Services;

namespace BolsaIR.Infrastructure.Services.TaxCalculation;

public sealed class AveragePriceCalculator	: IAveragePriceCalculator
{
	public decimal CalculateAveragePrice(
		decimal currentQuantity,
		decimal currentAveragePrice,
		decimal buyQuantity,
		decimal buyUnitPrice)
	{
		if (buyQuantity <= 0)
			throw new ArgumentOutOfRangeException(nameof(buyQuantity));

		if (buyUnitPrice <= 0)
			throw new ArgumentOutOfRangeException(nameof(buyUnitPrice));

		var currentCost =
			currentQuantity * currentAveragePrice;

		var purchaseCost =
			buyQuantity * buyUnitPrice;

		var newQuantity =
			currentQuantity + buyQuantity;

		if (newQuantity == 0)
			return 0;

		return (currentCost + purchaseCost) / newQuantity;
	}
}