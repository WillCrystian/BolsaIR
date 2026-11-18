using BolsaIR.Application.Common;
using MediatR;

namespace BolsaIR.Application.Features.Companies.Commands.RemoveCompany;

public sealed class RemoveCompanyCommand : IRequest<Result>
{
	public Guid Id { get; init; }
}