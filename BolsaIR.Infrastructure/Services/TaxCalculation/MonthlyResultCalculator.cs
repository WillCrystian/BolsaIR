using BolsaIR.Application.Features.TaxCalculation.DTOs;
using BolsaIR.Application.Features.TaxCalculation.Services;

namespace BolsaIR.Infrastructure.Services.TaxCalculation;

public sealed class MonthlyResultCalculator : IMonthlyResultCalculator
{
	public void Process(TaxCalculationContext context)
	{
		ArgumentNullException.ThrowIfNull(context);

		if (context.Profit is null)
			throw new InvalidOperationException(
				"O lucro da operação ainda não foi calculado.");

		context.MonthlySales +=
			context.Profit.SaleValue;

		context.MonthlyCost +=
			context.Profit.Cost;

		context.MonthlyGrossProfit +=
			context.Profit.GrossProfit;

		context.MonthlyNetProfit =
			context.MonthlyTaxableProfit;
	}
}