using BolsaIR.Application.Features.TaxCalculation.DTOs;
using BolsaIR.Application.Features.TaxCalculation.Models;
using BolsaIR.Domain.Enums;
using BolsaIR.Infrastructure.Services.TaxCalculation;
using Xunit;

namespace BolsaIR.Tests.TaxCalculation;

public class ProfitCalculatorTests
{
	[Fact]
	public void Should_Calculate_Profit_When_Selling_All_Position()
	{
		// Arrange

		var calculator = new ProfitCalculator();

		var position = new PositionSnapshot
		{
			AssetId = Guid.NewGuid(),
			Quantity = 100,
			AveragePrice = 20m,
			TotalCost = 2000m
		};

		var operation = new OperationForTaxCalculation
		{
			OperationId = Guid.NewGuid(),

			AssetId = position.AssetId,

			AssetTicker = "PETR4",

			AssetType = AssetType.Stock,

			OperationType = OperationType.Sell,

			TradeType = TradeType.SwingTrade,

			Quantity = 100,

			UnitPrice = 25m
		};

		// Act

		var result =
			calculator.Calculate(
				position,
				operation);

		// Assert

		Assert.Equals(2000m, result.CostBasis);

		Assert.Equals(500m, result.GrossProfit);

		Assert.Equals(500m, result.NetProfit);

		Assert.Equals(0m, position.Quantity);

		Assert.Equals(0m, position.TotalCost);

		Assert.Equals(0m, position.AveragePrice);
	}
}