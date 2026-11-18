using BolsaIR.Application.Features.Brokers.DTOs;
using MediatR;

namespace BolsaIR.Application.Features.Brokers.Queries.GetBrokers;

public sealed record GetBrokersQuery : IRequest<List<BrokerListDto>>;