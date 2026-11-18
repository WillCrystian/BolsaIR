using BolsaIR.Application.Common;
using MediatR;

namespace BolsaIR.Application.Features.Brokers.Commands.RemoveBroker;

public sealed record RemoveBrokerCommand(Guid Id) : IRequest<Result>;