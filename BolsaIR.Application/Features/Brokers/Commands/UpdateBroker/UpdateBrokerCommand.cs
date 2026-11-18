using BolsaIR.Application.Common;
using MediatR;

namespace BolsaIR.Application.Features.Brokers.Commands.UpdateBroker;

public sealed record UpdateBrokerCommand(
	Guid Id,
	string Name,
	string? Cnpj,
	string? Website,
	string? ImporterName
) : IRequest<Result>;