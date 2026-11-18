using BolsaIR.Application.Common;
using BolsaIR.Application.Features.Companies.DTOs;
using MediatR;

public sealed class GetCompanyByIdQuery : IRequest<Result<CompanyDetailsDto>>
{
	public Guid Id { get; init; }
}