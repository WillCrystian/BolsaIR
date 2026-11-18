using BolsaIR.Domain.Enums;

namespace BolsaIR.Application.Features.BrokerageNotes.DTOs;

public class ImportOperationDto
{
	public string Ticker { get; set; } = string.Empty;

	public string TradingName { get; set; } = string.Empty;

	public AssetType AssetType { get; set; }

	public OperationType OperationType { get; set; }

	public TradeType TradeType { get; set; }

	public int Quantity { get; set; }

	public decimal UnitPrice { get; set; }

	public decimal GrossValue { get; set; }	

	public decimal BrokerageFee { get; set; }

	public decimal ExchangeFee { get; set; }

	public decimal RegistrationFee { get; set; }

	public decimal SettlementFee { get; set; }

	public decimal Emoluments { get; set; }

	public decimal OtherFees { get; set; }

	public decimal Irrf { get; set; }

	public DateOnly TradeDate { get; set; }

	public DateOnly SettlementDate { get; set; }

	public string Observation { get; set; } = string.Empty;
}