using BolsaIR.Application.Common;
using BolsaIR.Application.Features.Companies.DTOs;
using BolsaIR.Application.Features.Companies.Services;
using MediatR;

namespace BolsaIR.Application.Features.Companies.Queries.GetCompanyById;

public sealed class GetCompanyByIdHandler : IRequestHandler<GetCompanyByIdQuery, Result<CompanyDetailsDto>>
{
	private readonly ICompanyReadService _readService;

	public GetCompanyByIdHandler(ICompanyReadService readService)
	{
		_readService = readService;
	}

	public async Task<Result<CompanyDetailsDto>> Handle(GetCompanyByIdQuery request, CancellationToken cancellationToken)
	{
		var company = await _readService.GetByIdAsync(request.Id);

		if (company is null)
			return Result<CompanyDetailsDto>.Failure(CompanyErrors.NotFound);

		return Result<CompanyDetailsDto>.Success(company);
	}
}