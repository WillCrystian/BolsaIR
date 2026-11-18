using BolsaIR.Application.Features.TaxCalculation.DTOs;
using BolsaIR.Domain.Enums;

namespace BolsaIR.Infrastructure.Services.TaxCalculation;

public static class TaxOperationClassifier
{
	public static TaxOperationCategory Classify(
		OperationForTaxCalculation operation)
	{
		ArgumentNullException.ThrowIfNull(operation);

		if (operation.TradeType == TradeType.DayTrade)
			return TaxOperationCategory.DayTrade;

		if (operation.AssetType == AssetType.Fii)
			return TaxOperationCategory.Fii;

		return TaxOperationCategory.Common;
	}
}