using BolsaIR.Domain.Enums;

namespace BolsaIR.Application.Features.TaxCalculation.DTOs;

public sealed class OperationForTaxCalculation
{
	public Guid OperationId { get; init; }

	public Guid BrokerageNoteId { get; init; }

	public Guid AssetId { get; init; }

	public string AssetTicker { get; init; } = string.Empty;

	public AssetType AssetType { get; init; }

	public OperationType OperationType { get; init; }

	public TradeType TradeType { get; init; }

	public DateOnly SettlementDate { get; init; }

	public decimal Quantity { get; init; }

	public decimal UnitPrice { get; init; }

	public decimal GrossValue { get; init; }

	public decimal NetValue { get; init; }

	public decimal TotalFees { get; init; }

	public decimal Irrf { get; init; }

	public bool IsExemptAsset { get; init; }

	public bool IsFractional { get; init; }

	public decimal BrokerageFee { get; init; }

	public decimal ExchangeFee { get; init; }

	public decimal RegistrationFee { get; init; }

	public decimal SettlementFee { get; init; }

	public decimal Emoluments { get; init; }

	public decimal OtherFees { get; init; }
}