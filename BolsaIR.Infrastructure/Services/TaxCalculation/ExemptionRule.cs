using BolsaIR.Application.Features.TaxCalculation.Results;
using BolsaIR.Application.Features.TaxCalculation.Services;
using BolsaIR.Domain.Enums;

namespace BolsaIR.Infrastructure.Services.TaxCalculation;

public sealed class ExemptionRule : IExemptionRule
{
	private const decimal StockSalesExemptionLimit = 20_000m;

	public void Apply(MonthlyTaxResult month)
	{
		ArgumentNullException.ThrowIfNull(month);

		month.CommonIsExempt = false;

		// ============================================================
		// ISENÇÃO DE AÇÕES
		// ============================================================
		//
		// A regra considera somente as vendas de ações.
		//
		// Não considera:
		// - Opções
		// - FII
		// - ETF
		// - BDR
		// - Day Trade
		//
		// O limite é analisado sobre o total vendido em ações
		// no mercado comum durante o mês.
		// ============================================================

		if (month.CommonStockSales <= StockSalesExemptionLimit)
		{
			if (month.CommonStockProfit > 0m)
			{
				month.CommonIsExempt = true;
			}
		}

		if (!month.CommonIsExempt)
		{
			return;
		}

		// ============================================================
		// IMPORTANTE
		// ============================================================
		//
		// Não zeramos CommonTaxableProfit inteiro aqui.
		//
		// Isso poderia eliminar imposto devido por opções.
		//
		// A regra de isenção deve afetar somente o resultado
		// tributável das ações.
		// ============================================================

		var nonStockProfit =
			month.CommonProfit -
			month.CommonStockProfit;

		var nonStockLoss =
			month.CommonLoss -
			month.CommonStockLoss;

		var stockTaxableProfit =
			month.CommonStockProfit -
			month.CommonStockLoss;

		var nonStockTaxableProfit =
			Math.Max(
				0m,
				nonStockProfit - nonStockLoss);

		// Resultado das ações elegíveis fica isento.
		var exemptStockProfit =
			Math.Max(0m, stockTaxableProfit);

		month.CommonTaxableProfit =
			Math.Max(
				0m,
				nonStockTaxableProfit);

		month.CommonTax = 0m;
	}
}