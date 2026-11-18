using BolsaIR.Application.Common;
using BolsaIR.Domain.Enums;
using MediatR;

namespace BolsaIR.Application.Features.Assets.Commands.UpdateAsset;

public sealed class UpdateAssetCommand : IRequest<Result>
{
	public Guid Id { get; init; }

	public string TradingName { get; init; } = string.Empty;

	public string? CompanyName { get; init; }

	public string? Cnpj { get; init; }

	public string? Isin { get; init; }

	public AssetType AssetType { get; init; }

	public string? Sector { get; init; }

	public string? Segment { get; init; }
}