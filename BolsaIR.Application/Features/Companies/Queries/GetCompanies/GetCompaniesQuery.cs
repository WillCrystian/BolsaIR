using BolsaIR.Application.Common;
using BolsaIR.Application.Features.Companies.DTOs;
using MediatR;

namespace BolsaIR.Application.Features.Companies.Queries.GetCompanies;

public sealed record GetCompaniesQuery : IRequest<Result<List<CompanyListDto>>>;