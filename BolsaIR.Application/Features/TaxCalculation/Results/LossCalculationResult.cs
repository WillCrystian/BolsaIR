namespace BolsaIR.Application.Features.TaxCalculation.Results;

public sealed class LossCalculationResult
{
	public decimal PreviousAccumulatedLoss { get; init; }

	public decimal ProfitBeforeCompensation { get; init; }

	public decimal CompensatedLoss { get; init; }

	public decimal TaxableProfit { get; init; }

	public decimal RemainingAccumulatedLoss { get; init; }
}