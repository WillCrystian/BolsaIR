using BolsaIR.Domain.Entities;
using BolsaIR.Domain.Enums;

namespace BolsaIR.Application.Features.BrokerageNotes.Factories;

public static class AssetFactory
{
	public static Asset Create(
		string ticker,
		string tradingName,
		AssetType assetType)
	{
		return new Asset(
			ticker,
			tradingName,
			assetType);
	}
}