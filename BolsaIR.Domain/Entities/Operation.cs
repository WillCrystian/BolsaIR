using BolsaIR.Domain.Common;
using BolsaIR.Domain.Enums;

namespace BolsaIR.Domain.Entities;

public class Operation : EntityBase
{
	private Operation()
	{
	}

	public Operation(BrokerageNote brokerageNote, Asset asset, OperationData data)
	{
		BrokerageNote = brokerageNote;
		BrokerageNoteId = brokerageNote.Id;

		Update(asset, data);

		Processed = false;
	}

	public Guid BrokerageNoteId { get; private set; }

	public BrokerageNote BrokerageNote { get; private set; } = null!;

	public Guid AssetId { get; private set; }

	public Asset Asset { get; private set; } = null!;

	public OperationType OperationType { get; private set; }

	public TradeType TradeType { get; private set; }

	public int Quantity { get; private set; }

	public decimal UnitPrice { get; private set; }

	public DateOnly SettlementDate { get; private set; }

	public decimal BrokerageFee { get; private set; }

	public decimal ExchangeFee { get; private set; }

	public decimal RegistrationFee { get; private set; }

	public decimal SettlementFee { get; private set; }

	public decimal Emoluments { get; private set; }

	public decimal OtherFees { get; private set; }

	public decimal Irrf { get; private set; }

	public string? Observation { get; private set; }

	public string? ExternalId { get; private set; }

	public bool Processed { get; private set; }

	public DateTime? ProcessedAt { get; private set; }

	public decimal GrossValue => Quantity * UnitPrice;

	public decimal TotalFees =>
		BrokerageFee +
		ExchangeFee +
		RegistrationFee +
		SettlementFee +
		Emoluments +
		OtherFees;

	public decimal NetValue =>
		OperationType == OperationType.Buy
			? GrossValue + TotalFees
			: GrossValue - TotalFees;

	public void Update(Asset asset, OperationData data)
	{
		if (asset is null)
			throw new ArgumentNullException(nameof(asset));

		if (data.Quantity <= 0)
			throw new ArgumentOutOfRangeException(nameof(data.Quantity));

		if (data.UnitPrice <= 0)
			throw new ArgumentOutOfRangeException(nameof(data.UnitPrice));

		Asset = asset;
		AssetId = asset.Id;

		OperationType = data.OperationType;
		TradeType = data.TradeType;

		Quantity = data.Quantity;
		UnitPrice = data.UnitPrice;

		SettlementDate = data.SettlementDate;

		BrokerageFee = data.BrokerageFee;
		ExchangeFee = data.ExchangeFee;
		RegistrationFee = data.RegistrationFee;
		SettlementFee = data.SettlementFee;
		Emoluments = data.Emoluments;
		OtherFees = data.OtherFees;
		Irrf = data.Irrf;

		Observation = string.IsNullOrWhiteSpace(data.Observation)
			? null
			: data.Observation.Trim();

		Touch();
	}

	public void SetExternalId(string? externalId)
	{
		ExternalId = string.IsNullOrWhiteSpace(externalId)
			? null
			: externalId.Trim();

		Touch();
	}

	public void MarkAsProcessed()
	{
		Processed = true;
		ProcessedAt = DateTime.UtcNow;

		Touch();
	}

	public void MarkAsUnprocessed()
	{
		Processed = false;
		ProcessedAt = null;

		Touch();
	}
}