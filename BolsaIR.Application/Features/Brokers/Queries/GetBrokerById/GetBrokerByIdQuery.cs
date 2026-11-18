using BolsaIR.Application.Common;
using BolsaIR.Application.Features.Brokers.DTOs;
using MediatR;

namespace BolsaIR.Application.Features.Brokers.Queries.GetBrokerById;

public sealed record GetBrokerByIdQuery(Guid Id) : IRequest<Result<BrokerDetailsDto>>;
