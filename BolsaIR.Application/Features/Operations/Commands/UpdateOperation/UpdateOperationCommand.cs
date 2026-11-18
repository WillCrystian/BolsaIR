using BolsaIR.Application.Common;
using BolsaIR.Domain.Enums;
using MediatR;

namespace BolsaIR.Application.Features.Operations.Commands.UpdateOperation;

public sealed class UpdateOperationCommand : IRequest<Result>
{
	public Guid BrokerageNoteId { get; init; }

	public Guid OperationId { get; init; }

	public Guid AssetId { get; init; }

	public OperationType OperationType { get; init; }

	public TradeType TradeType { get; init; }

	public int Quantity { get; init; }

	public decimal UnitPrice { get; init; }

	public DateOnly SettlementDate { get; init; }

	public decimal BrokerageFee { get; init; }

	public decimal ExchangeFee { get; init; }

	public decimal RegistrationFee { get; init; }

	public decimal SettlementFee { get; init; }

	public decimal Emoluments { get; init; }

	public decimal OtherFees { get; init; }

	public decimal Irrf { get; init; }

	public string? Observation { get; init; }
}