using BolsaIR.Application.Features.Positions.DTOs;
using MediatR;

namespace BolsaIR.Application.Features.Positions.Queries.GetPositionByAsset;

public sealed record GetPositionByAssetQuery(Guid AssetId)
	: IRequest<PositionDetailsDto?>;