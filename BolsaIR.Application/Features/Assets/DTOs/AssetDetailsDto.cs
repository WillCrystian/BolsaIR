using BolsaIR.Domain.Enums;

namespace BolsaIR.Application.Features.Assets.DTOs;

public sealed class AssetDetailsDto
{
	public Guid Id { get; init; }

	public string Ticker { get; init; } = string.Empty;

	public string TradingName { get; init; } = string.Empty;

	public string? CompanyName { get; init; }

	public string? Cnpj { get; init; }

	public string? Isin { get; init; }

	public AssetType AssetType { get; init; }

	public string? Sector { get; init; }

	public string? Segment { get; init; }

	public bool IsActive { get; init; }
}