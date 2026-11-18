using BolsaIR.Domain.Enums;

namespace BolsaIR.Application.Features.Operations.DTOs;

public sealed class OperationDetailsDto
{
	public Guid Id { get; init; }

	public Guid BrokerageNoteId { get; init; }

	public Guid AssetId { get; init; }

	public string AssetTicker { get; init; } = string.Empty;

	public string AssetName { get; init; } = string.Empty;

	public OperationType OperationType { get; init; }

	public TradeType TradeType { get; init; }

	public int Quantity { get; init; }

	public decimal UnitPrice { get; init; }

	public decimal BrokerageFee { get; init; }

	public decimal ExchangeFee { get; init; }

	public decimal RegistrationFee { get; init; }

	public decimal SettlementFee { get; init; }

	public decimal Emoluments { get; init; }

	public decimal OtherFees { get; init; }

	public decimal Irrf { get; init; }

	public decimal GrossValue { get; init; }

	public decimal TotalFees { get; init; }

	public decimal NetValue { get; init; }

	public DateOnly SettlementDate { get; init; }

	public string? Observation { get; init; }

	public bool Processed { get; init; }

	public DateTime? ProcessedAt { get; init; }

	public string? ExternalId { get; init; }
}