using BolsaIR.Application.Common;
using MediatR;

namespace BolsaIR.Application.Features.Companies.Commands.InactivateCompany;

public sealed class InactivateCompanyCommand : IRequest<Result>
{
	public Guid Id { get; init; }
}