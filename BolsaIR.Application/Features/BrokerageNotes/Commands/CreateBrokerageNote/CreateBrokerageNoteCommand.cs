using BolsaIR.Application.Common;
using MediatR;

namespace BolsaIR.Application.Features.BrokerageNotes.Commands.CreateBrokerageNote;

public sealed class CreateBrokerageNoteCommand : IRequest<Result<Guid>>
{
	public Guid BrokerId { get; init; }

	public string NoteNumber { get; init; } = string.Empty;

	public DateOnly TradeDate { get; init; }

	public decimal BrokerageFee { get; init; }

	public decimal ExchangeFee { get; init; }

	public decimal RegistrationFee { get; init; }

	public decimal SettlementFee { get; init; }

	public decimal Emoluments { get; init; }

	public decimal OtherFees { get; init; }

	public decimal Irrf { get; init; }

	public decimal TotalValue { get; init; }

	public decimal NetValue { get; init; }

	public decimal LiquidValue { get; init; }

	public string? Observation { get; init; }

	public List<OperationData> Operations { get; init; } = [];
}