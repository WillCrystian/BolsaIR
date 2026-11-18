namespace BolsaIR.Application.Features.TaxCalculation.Services;

public interface IAveragePriceCalculator
{
	decimal CalculateAveragePrice(
		decimal currentQuantity,
		decimal currentAveragePrice,
		decimal buyQuantity,
		decimal buyUnitPrice);
}