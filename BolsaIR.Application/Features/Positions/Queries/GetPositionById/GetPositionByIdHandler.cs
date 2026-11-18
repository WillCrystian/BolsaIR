using BolsaIR.Application.Features.Positions.DTOs;
using BolsaIR.Application.Features.Positions.Services;
using MediatR;

namespace BolsaIR.Application.Features.Positions.Queries.GetPositionById;

public sealed class GetPositionByIdHandler
	: IRequestHandler<GetPositionByIdQuery, PositionDetailsDto?>
{
	private readonly IPositionReadService _readService;

	public GetPositionByIdHandler(IPositionReadService readService)
	{
		_readService = readService;
	}

	public async Task<PositionDetailsDto?> Handle(
		GetPositionByIdQuery request,
		CancellationToken cancellationToken)
	{
		return await _readService.GetByIdAsync(request.Id);
	}
}