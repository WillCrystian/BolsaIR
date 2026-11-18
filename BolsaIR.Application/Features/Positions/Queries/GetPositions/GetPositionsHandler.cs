using BolsaIR.Application.Features.Positions.DTOs;
using BolsaIR.Application.Features.Positions.Services;
using MediatR;

namespace BolsaIR.Application.Features.Positions.Queries.GetPositions;

public sealed class GetPositionsHandler : IRequestHandler<GetPositionsQuery, List<PositionListDto>>
{
	private readonly IPositionReadService _readService;

	public GetPositionsHandler(IPositionReadService readService)
	{
		_readService = readService;
	}

	public async Task<List<PositionListDto>> Handle(
		GetPositionsQuery request,
		CancellationToken cancellationToken)
	{
		return await _readService.GetListAsync();
	}
}