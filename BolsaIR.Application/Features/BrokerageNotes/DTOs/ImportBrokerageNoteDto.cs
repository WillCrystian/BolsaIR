namespace BolsaIR.Application.Features.BrokerageNotes.DTOs;

public class ImportBrokerageNoteDto
{
	public string BrokerName { get; set; } = string.Empty;

	public string NoteNumber { get; set; } = string.Empty;

	public DateOnly TradeDate { get; set; }

	public DateOnly? SettlementDate { get; set; }

	public decimal TotalValue { get; set; }

	public decimal NetValue { get; set; }

	public decimal LiquidValue { get; set; }

	public decimal BrokerageFee { get; set; }

	public decimal ExchangeFee { get; set; }

	public decimal RegistrationFee { get; set; }

	public decimal SettlementFee { get; set; }

	public decimal Emoluments { get; set; }

	public decimal OtherFees { get; set; }

	public decimal Irrf { get; set; }

	public List<ImportOperationDto> Operations { get; set; } = [];
}