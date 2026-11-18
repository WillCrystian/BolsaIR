using BolsaIR.Domain.Enums;

namespace BolsaIR.Infrastructure.Importers.BTG;

internal sealed class BtgMarketInfo
{
	public AssetType AssetType { get; init; }

	public TradeType TradeType { get; init; }

	public string Description { get; init; } = string.Empty;
}