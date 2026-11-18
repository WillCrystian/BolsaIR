namespace BolsaIR.Application.Features.Positions.DTOs;

public sealed class PositionListDto
{
	public Guid Id { get; init; }

	public Guid AssetId { get; init; }

	public string AssetTicker { get; init; } = string.Empty;

	public decimal Quantity { get; init; }

	public decimal AveragePrice { get; init; }

	public decimal TotalCost { get; init; }

	public bool IsClosed { get; init; }
}