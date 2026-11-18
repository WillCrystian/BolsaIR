using BolsaIR.Application.Common;
using BolsaIR.Application.Features.Dividends.DTOs;
using BolsaIR.Application.Features.Dividends.Services;
using MediatR;

namespace BolsaIR.Application.Features.Dividends.Queries.GetDividends;

public sealed class GetDividendsHandler	: IRequestHandler<GetDividendsQuery, Result<List<DividendListDto>>>
{
	private readonly IDividendReadService _readService;

	public GetDividendsHandler(
		IDividendReadService readService)
	{
		_readService = readService;
	}

	public async Task<Result<List<DividendListDto>>> Handle(		GetDividendsQuery request,		CancellationToken cancellationToken)
	{
		var list = await _readService.GetListAsync();

		return Result<List<DividendListDto>>.Success(list);
	}
}