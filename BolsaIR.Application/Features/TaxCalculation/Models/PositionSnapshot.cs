namespace BolsaIR.Application.Features.TaxCalculation.Models;

public sealed class PositionSnapshot
{
	public Guid AssetId { get; init; }

	public decimal Quantity { get; set; }

	public decimal AveragePrice { get; set; }

	public decimal TotalCost { get; set; }
}