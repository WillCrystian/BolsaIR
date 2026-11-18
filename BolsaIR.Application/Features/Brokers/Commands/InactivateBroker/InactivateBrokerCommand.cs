using BolsaIR.Application.Common;
using MediatR;

namespace BolsaIR.Application.Features.Brokers.Commands.InactivateBroker;

public sealed record InactivateBrokerCommand(Guid Id) : IRequest<Result>;