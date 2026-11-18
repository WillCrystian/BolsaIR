using BolsaIR.Application.Common;
using BolsaIR.Application.Features.Companies.DTOs;
using BolsaIR.Application.Features.Companies.Services;
using MediatR;

namespace BolsaIR.Application.Features.Companies.Queries.GetCompanies;

public sealed class GetCompaniesHandler : IRequestHandler<GetCompaniesQuery, Result<List<CompanyListDto>>>
{
	private readonly ICompanyReadService _readService;

	public GetCompaniesHandler(ICompanyReadService readService)
	{
		_readService = readService;
	}

	public async Task<Result<List<CompanyListDto>>> Handle(GetCompaniesQuery request, CancellationToken cancellationToken)
	{
		var companies = await _readService.GetListAsync();

		return Result<List<CompanyListDto>>.Success(companies);
	}
}