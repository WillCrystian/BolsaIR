namespace BolsaIR.Application.Features.TaxCalculation.DTOs;

public sealed class ProcessedOperationResult
{
	public required Guid OperationId { get; init; }

	public required Guid AssetId { get; init; }

	public required DateOnly SettlementDate { get; init; }

	public decimal Quantity { get; init; }

	public decimal AveragePrice { get; init; }

	public decimal SalePrice { get; init; }

	public decimal SaleValue { get; init; }

	public decimal Cost { get; init; }

	public decimal GrossProfit { get; init; }

	public decimal TaxableProfit { get; set; }

	public decimal TaxDue { get; set; }

	public bool IsExempt { get; set; }

	public bool IsDayTrade { get; init; }
}