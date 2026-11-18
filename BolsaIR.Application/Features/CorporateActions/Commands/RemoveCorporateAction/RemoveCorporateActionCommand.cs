using BolsaIR.Application.Common;
using MediatR;

namespace BolsaIR.Application.Features.CorporateActions.Commands.RemoveCorporateAction;

public sealed class RemoveCorporateActionCommand : IRequest<Result>
{
	public Guid Id { get; init; }
}