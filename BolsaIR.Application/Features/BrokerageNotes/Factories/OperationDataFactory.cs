using BolsaIR.Application.Features.BrokerageNotes.DTOs;
using BolsaIR.Domain;

namespace BolsaIR.Application.Features.BrokerageNotes.Factories;

public static class OperationDataFactory
{
	public static OperationData Create(
		ImportOperationDto operation,
		DateOnly settlementDate)
	{
		return new OperationData(
			Guid.Empty,
			operation.OperationType,
			operation.TradeType,
			operation.Quantity,
			operation.UnitPrice,
			operation.BrokerageFee,
			operation.ExchangeFee,
			operation.RegistrationFee,
			operation.SettlementFee,
			operation.Emoluments,
			operation.OtherFees,
			operation.Irrf,
			settlementDate,
			operation.Observation);
	}
}