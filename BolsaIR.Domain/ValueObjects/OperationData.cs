using BolsaIR.Domain.Enums;

public sealed record OperationData(
	Guid AssetId,
	OperationType OperationType,
	TradeType TradeType,
	int Quantity,
	decimal UnitPrice,
	decimal BrokerageFee,
	decimal ExchangeFee,
	decimal RegistrationFee,
	decimal SettlementFee,
	decimal Emoluments,
	decimal OtherFees,
	decimal Irrf,
	DateOnly SettlementDate,
	string? Observation);