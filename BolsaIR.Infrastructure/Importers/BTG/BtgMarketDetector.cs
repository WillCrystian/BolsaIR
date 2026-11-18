using BolsaIR.Domain.Enums;

namespace BolsaIR.Infrastructure.Importers.BTG;

internal static class BtgMarketDetector
{
	public static BtgMarketInfo Detect(string line)
	{
		ArgumentNullException.ThrowIfNull(line);

		line = line.ToUpperInvariant();

		//-------------------------------------------------
		// OPÇÃO DE COMPRA
		//-------------------------------------------------

		if (line.Contains("OPCAO DE COMPRA"))
		{
			return new BtgMarketInfo
			{
				AssetType = AssetType.Option,
				TradeType = TradeType.SwingTrade,
				Description = "OPCAO DE COMPRA"
			};
		}

		//-------------------------------------------------
		// OPÇÃO DE VENDA
		//-------------------------------------------------

		if (line.Contains("OPCAO DE VENDA"))
		{
			return new BtgMarketInfo
			{
				AssetType = AssetType.Option,
				TradeType = TradeType.SwingTrade,
				Description = "OPCAO DE VENDA"
			};
		}

		//-------------------------------------------------
		// ETF
		//-------------------------------------------------

		if (line.Contains("ETF"))
		{
			return new BtgMarketInfo
			{
				AssetType = AssetType.Etf,
				TradeType = TradeType.SwingTrade,
				Description = "ETF"
			};
		}

		//-------------------------------------------------
		// FII
		//-------------------------------------------------

		if (line.Contains("FII"))
		{
			return new BtgMarketInfo
			{
				AssetType = AssetType.Fii,
				TradeType = TradeType.SwingTrade,
				Description = "FII"
			};
		}

		//-------------------------------------------------
		// VISTA
		//-------------------------------------------------

		if (line.Contains("VISTA"))
		{
			return new BtgMarketInfo
			{
				AssetType = AssetType.Stock,
				TradeType = TradeType.SwingTrade,
				Description = "VISTA"
			};
		}

		//-------------------------------------------------
		// PADRÃO
		//-------------------------------------------------

		return new BtgMarketInfo
		{
			AssetType = AssetType.Stock,
			TradeType = TradeType.SwingTrade,
			Description = string.Empty
		};
	}
}