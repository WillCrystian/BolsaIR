using BolsaIR.Application.Features.Positions.DTOs;
using BolsaIR.Application.Features.Positions.Services;
using MediatR;

namespace BolsaIR.Application.Features.Positions.Queries.GetPositionByAsset;

public sealed class GetPositionByAssetHandler
	: IRequestHandler<GetPositionByAssetQuery, PositionDetailsDto?>
{
	private readonly IPositionReadService _readService;

	public GetPositionByAssetHandler(IPositionReadService readService)
	{
		_readService = readService;
	}

	public async Task<PositionDetailsDto?> Handle(
		GetPositionByAssetQuery request,
		CancellationToken cancellationToken)
	{
		return await _readService.GetByAssetAsync(request.AssetId);
	}
}