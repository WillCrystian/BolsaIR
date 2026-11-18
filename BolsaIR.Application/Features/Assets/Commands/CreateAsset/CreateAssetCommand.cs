using BolsaIR.Application.Common;
using BolsaIR.Domain.Enums;
using MediatR;

namespace BolsaIR.Application.Features.Assets.Commands.CreateAsset;

public sealed class CreateAssetCommand	: IRequest<Result<Guid>>
{
	public string Ticker { get; init; } = string.Empty;

	public string TradingName { get; init; } = string.Empty;

	public AssetType AssetType { get; init; }

	public string? CompanyName { get; init; }

	public string? Cnpj { get; init; }

	public string? Isin { get; init; }

	public string? Sector { get; init; }

	public string? Segment { get; init; }
}