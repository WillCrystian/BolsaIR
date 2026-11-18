using BolsaIR.Application.Features.TaxCalculation.DTOs;
using BolsaIR.Application.Features.TaxCalculation.Models;
using BolsaIR.Application.Features.TaxCalculation.Results;
using BolsaIR.Application.Features.TaxCalculation.Services;
using BolsaIR.Domain.Enums;

namespace BolsaIR.Infrastructure.Services.TaxCalculation;

public sealed class ProfitCalculator : IProfitCalculator
{
	public OperationCalculationResult Calculate(
		PositionSnapshot position,
		OperationForTaxCalculation operation)
	{
		ArgumentNullException.ThrowIfNull(position);
		ArgumentNullException.ThrowIfNull(operation);

		var taxCategory =
			TaxOperationClassifier.Classify(operation);

		//---------------------------------------------------------
		// COMPRA
		//---------------------------------------------------------

		if (operation.OperationType == OperationType.Buy)
		{
			var purchaseCost =
				(operation.Quantity * operation.UnitPrice)
				+ operation.TotalFees;

			position.TotalCost += purchaseCost;
			position.Quantity += operation.Quantity;

			position.AveragePrice =
				position.Quantity == 0
					? 0
					: position.TotalCost / position.Quantity;

			return new OperationCalculationResult
			{
				OperationId = operation.OperationId,
				AssetId = operation.AssetId,
				OperationType = operation.OperationType,

				TaxCategory = taxCategory,

				CostBasis = purchaseCost,

				GrossProfit = 0,
				NetProfit = 0,
				TaxableProfit = 0,

				RemainingQuantity = position.Quantity,
				AveragePrice = position.AveragePrice,

				AssetType = operation.AssetType,
				TradeType = operation.TradeType
			};
		}

		//---------------------------------------------------------
		// VENDA DE OPÇÃO
		//---------------------------------------------------------

		if (operation.AssetType == AssetType.Option)
		{
			var saleValue =
				operation.Quantity * operation.UnitPrice;

			var netProfit =
				saleValue - operation.TotalFees;

			return new OperationCalculationResult
			{
				OperationId = operation.OperationId,
				AssetId = operation.AssetId,
				OperationType = operation.OperationType,

				TaxCategory = taxCategory,

				CostBasis = 0,

				GrossProfit = saleValue,
				NetProfit = netProfit,
				TaxableProfit = netProfit,

				RemainingQuantity = position.Quantity,
				AveragePrice = position.AveragePrice,

				AssetType = operation.AssetType,
				TradeType = operation.TradeType
			};
		}

		//---------------------------------------------------------
		// VENDA NORMAL
		//---------------------------------------------------------

		if (operation.Quantity > position.Quantity)
		{
			throw new InvalidOperationException(
				$"Tentativa de vender {operation.Quantity} ativos, " +
				$"porém a posição possui apenas {position.Quantity}.");
		}

		var cost =
			position.AveragePrice * operation.Quantity;

		var saleValueNormal =
			operation.UnitPrice * operation.Quantity;

		var grossProfit =
			saleValueNormal - cost;

		var netProfitNormal =
			grossProfit - operation.TotalFees;

		position.Quantity -= operation.Quantity;
		position.TotalCost -= cost;

		if (Math.Abs(position.TotalCost) < 0.0001m)
			position.TotalCost = 0;

		if (position.Quantity == 0)
		{
			position.TotalCost = 0;
			position.AveragePrice = 0;
		}
		else
		{
			position.AveragePrice =
				position.TotalCost / position.Quantity;
		}

		return new OperationCalculationResult
		{
			OperationId = operation.OperationId,
			AssetId = operation.AssetId,
			OperationType = operation.OperationType,

			TaxCategory = taxCategory,

			CostBasis = cost,

			GrossProfit = grossProfit,
			NetProfit = netProfitNormal,
			TaxableProfit = netProfitNormal,

			RemainingQuantity = position.Quantity,
			AveragePrice = position.AveragePrice,

			AssetType = operation.AssetType,
			TradeType = operation.TradeType
		};
	}
}