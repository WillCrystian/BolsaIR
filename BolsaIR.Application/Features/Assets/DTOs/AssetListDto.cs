using BolsaIR.Domain.Enums;

namespace BolsaIR.Application.Features.Assets.DTOs;

public sealed class AssetListDto
{
	public Guid Id { get; init; }

	public string Ticker { get; init; } = string.Empty;

	public string TradingName { get; init; } = string.Empty;

	public AssetType AssetType { get; init; }

	public bool IsActive { get; init; }
}