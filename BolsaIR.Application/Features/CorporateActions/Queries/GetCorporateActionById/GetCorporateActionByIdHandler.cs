using BolsaIR.Application.Common;
using BolsaIR.Application.Features.CorporateActions.DTOs;
using BolsaIR.Application.Features.CorporateActions.Services;
using MediatR;

namespace BolsaIR.Application.Features.CorporateActions.Queries.GetCorporateActionById;

public sealed class GetCorporateActionByIdHandler : IRequestHandler<GetCorporateActionByIdQuery, Result<CorporateActionDetailsDto>>
{
	private readonly ICorporateActionReadService _readService;

	public GetCorporateActionByIdHandler(
		ICorporateActionReadService readService)
	{
		_readService = readService;
	}

	public async Task<Result<CorporateActionDetailsDto>> Handle(
		GetCorporateActionByIdQuery request,
		CancellationToken cancellationToken)
	{
		var action = await _readService.GetByIdAsync(request.Id);

		if (action is null)
			return Result<CorporateActionDetailsDto>
				.Failure(CorporateActionErrors.NotFound);

		return Result<CorporateActionDetailsDto>.Success(action);
	}
}