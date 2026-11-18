namespace BolsaIR.Application.Features.Positions.DTOs;

public sealed class PositionDetailsDto
{
	public Guid Id { get; init; }

	public Guid AssetId { get; init; }

	public string AssetTicker { get; init; } = string.Empty;

	public string TradingName { get; init; } = string.Empty;

	public string CompanyName { get; init; } = string.Empty;

	public decimal Quantity { get; init; }

	public decimal AveragePrice { get; init; }

	public decimal TotalCost { get; init; }

	public DateOnly? LastMovementDate { get; init; }

	public bool IsClosed { get; init; }
}