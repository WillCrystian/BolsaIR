using BolsaIR.Application.Common;
using MediatR;

namespace BolsaIR.Application.Features.Brokers.Commands.CreateBroker;

public sealed record CreateBrokerCommand(
	string Name,
	string? Cnpj,
	string? Website,
	string? ImporterName
) : IRequest<Result<Guid>>;