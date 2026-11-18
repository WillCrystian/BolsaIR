using BolsaIR.Application.Features.TaxCalculation.DTOs;
using BolsaIR.Application.Features.TaxCalculation.Results;
using BolsaIR.Application.Features.TaxCalculation.Services;
using BolsaIR.Domain.Enums;

namespace BolsaIR.Infrastructure.Services.TaxCalculation;

public sealed class MonthlyResultAggregator
	: IMonthlyResultAggregator
{
	public void AddOperation(
		MonthlyTaxResult result,
		OperationForTaxCalculation operation,
		OperationCalculationResult calculation)
	{
		ArgumentNullException.ThrowIfNull(result);
		ArgumentNullException.ThrowIfNull(operation);
		ArgumentNullException.ThrowIfNull(calculation);

		result.Operations.Add(calculation);

		var isDayTrade =
			operation.TradeType == TradeType.DayTrade;

		var isFii =
			operation.AssetType == AssetType.Fii;

		// ==========================================
		// COMPRAS
		// ==========================================

		if (operation.OperationType == OperationType.Buy)
		{
			if (isDayTrade)
			{
				result.DayTradePurchases +=
					operation.GrossValue;
			}
			else if (isFii)
			{
				result.FiiPurchases +=
					operation.GrossValue;
			}
			else
			{
				result.CommonPurchases +=
					operation.GrossValue;
			}

			result.TotalFees += operation.TotalFees;
			result.Irrf += operation.Irrf;

			return;
		}

		// ==========================================
		// VENDAS
		// ==========================================

		if (isDayTrade)
		{
			result.DayTradeSales +=
				operation.GrossValue;

			if (calculation.GrossProfit >= 0)
			{
				result.DayTradeProfit +=
					calculation.GrossProfit;
			}
			else
			{
				result.DayTradeLoss +=
					Math.Abs(calculation.GrossProfit);
			}
		}
		else if (isFii)
		{
			result.FiiSales +=
				operation.GrossValue;

			if (calculation.GrossProfit >= 0)
			{
				result.FiiProfit +=
					calculation.GrossProfit;
			}
			else
			{
				result.FiiLoss +=
					Math.Abs(calculation.GrossProfit);
			}
		}
		else
		{
			result.CommonSales +=
				operation.GrossValue;

			if (calculation.GrossProfit >= 0)
			{
				result.CommonProfit +=
					calculation.GrossProfit;
			}
			else
			{
				result.CommonLoss +=
					Math.Abs(calculation.GrossProfit);
			}
		}

		result.TotalFees += operation.TotalFees;

		result.Irrf += operation.Irrf;

		result.FinalProfit =
			result.CommonProfit -
			result.CommonLoss +
			result.FiiProfit -
			result.FiiLoss +
			result.DayTradeProfit -
			result.DayTradeLoss;
	}
}