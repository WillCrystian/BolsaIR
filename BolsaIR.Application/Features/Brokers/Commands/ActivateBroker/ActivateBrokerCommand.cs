using BolsaIR.Application.Common;
using MediatR;

namespace BolsaIR.Application.Features.Brokers.Commands.ActivateBroker;

public sealed record ActivateBrokerCommand(Guid Id)	: IRequest<Result>;