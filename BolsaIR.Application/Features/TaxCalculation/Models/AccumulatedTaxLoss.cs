namespace BolsaIR.Application.Features.TaxCalculation.Models;

public sealed class AccumulatedTaxLoss
{
	public decimal Common { get; set; }

	public decimal Fii { get; set; }

	public decimal DayTrade { get; set; }
}