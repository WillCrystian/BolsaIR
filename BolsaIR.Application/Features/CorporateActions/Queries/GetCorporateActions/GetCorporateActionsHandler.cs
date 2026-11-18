using BolsaIR.Application.Common;
using BolsaIR.Application.Features.CorporateActions.DTOs;
using BolsaIR.Application.Features.CorporateActions.Services;
using MediatR;

namespace BolsaIR.Application.Features.CorporateActions.Queries.GetCorporateActions;

public sealed class GetCorporateActionsHandler : IRequestHandler<GetCorporateActionsQuery, Result<List<CorporateActionListDto>>>
{
	private readonly ICorporateActionReadService _readService;

	public GetCorporateActionsHandler(
		ICorporateActionReadService readService)
	{
		_readService = readService;
	}

	public async Task<Result<List<CorporateActionListDto>>> Handle(
		GetCorporateActionsQuery request,
		CancellationToken cancellationToken)
	{
		var list = await _readService.GetListAsync();

		return Result<List<CorporateActionListDto>>.Success(list);
	}
}