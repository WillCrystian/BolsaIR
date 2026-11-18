using BolsaIR.Application.Features.TaxCalculation.Results;
using BolsaIR.Application.Features.TaxCalculation.Services;
using BolsaIR.Domain.Enums;
using BolsaIR.Domain.Taxation;

namespace BolsaIR.Infrastructure.Services.TaxCalculation;

public sealed class ExemptionCalculator : IExemptionCalculator
{
	public bool IsExempt(MonthlyTaxResult monthlyResult)
	{
		ArgumentNullException.ThrowIfNull(monthlyResult);

		// Day Trade nunca possui isenção
		//if (monthlyResult.Operations.Any(x => x.TradeType == TradeType.DayTrade))
		//	return false;

		//// Se existir ativo que não seja ação, perde a isenção
		//if (monthlyResult.Operations.Any(x => x.AssetType != AssetType.Stock))
		//	return false;

		//// Limite mensal de vendas para Swing Trade de ações
		//return monthlyResult.TotalSales <=
		//	TaxConstants.SwingTradeExemptionLimit;
		return false;
	}
}