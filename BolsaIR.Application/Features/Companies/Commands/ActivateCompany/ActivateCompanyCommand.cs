using BolsaIR.Application.Common;
using MediatR;

namespace BolsaIR.Application.Features.Companies.Commands.ActivateCompany;

public sealed class ActivateCompanyCommand : IRequest<Result>
{
	public Guid Id { get; init; }
}