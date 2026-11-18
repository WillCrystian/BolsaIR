namespace BolsaIR.Application.Features.TaxCalculation.DTOs;

public sealed record ProfitCalculationResult(
	decimal Quantity,
	decimal AveragePrice,
	decimal SalePrice,
	decimal Cost,
	decimal SaleValue,
	decimal GrossProfit);