using BolsaIR.Domain.Enums;

namespace BolsaIR.Application.Features.TaxCalculation.Results;

public sealed class OperationCalculationResult
{
	public Guid OperationId { get; init; }

	public Guid AssetId { get; init; }

	public OperationType OperationType { get; init; }

	public decimal CostBasis { get; init; }

	public decimal GrossProfit { get; init; }

	public decimal NetProfit { get; init; }

	public decimal TaxableProfit { get; init; }

	public decimal RemainingQuantity { get; init; }

	public decimal AveragePrice { get; init; }

	public AssetType AssetType { get; init; }

	public TradeType TradeType { get; init; }

	public TaxOperationCategory TaxCategory { get; set; }
}