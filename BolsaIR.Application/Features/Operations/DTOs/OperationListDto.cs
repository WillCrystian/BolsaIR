using BolsaIR.Domain.Enums;

namespace BolsaIR.Application.Features.Operations.DTOs;

public sealed class OperationListDto
{
	public Guid Id { get; init; }

	public string AssetTicker { get; init; } = string.Empty;

	public OperationType OperationType { get; init; }

	public TradeType TradeType { get; init; }

	public int Quantity { get; init; }

	public decimal UnitPrice { get; init; }

	public DateOnly SettlementDate { get; init; }

	public bool Processed { get; init; }
}