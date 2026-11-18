using BolsaIR.Application.Common;
using BolsaIR.Application.Features.Dividends.DTOs;
using BolsaIR.Application.Features.Dividends.Services;
using MediatR;

namespace BolsaIR.Application.Features.Dividends.Queries.GetDividendById;

public sealed class GetDividendByIdHandler : IRequestHandler<GetDividendByIdQuery, Result<DividendDetailsDto>>
{
	private readonly IDividendReadService _readService;

	public GetDividendByIdHandler(IDividendReadService readService)
	{
		_readService = readService;
	}

	public async Task<Result<DividendDetailsDto>> Handle(GetDividendByIdQuery request, CancellationToken cancellationToken)
	{
		var dividend = await _readService.GetByIdAsync(request.Id);

		if (dividend is null)
			return Result<DividendDetailsDto>.Failure(
				DividendErrors.NotFound);

		return Result<DividendDetailsDto>.Success(dividend);
	}
}