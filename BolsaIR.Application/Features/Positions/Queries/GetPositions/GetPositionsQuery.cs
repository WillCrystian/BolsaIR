using BolsaIR.Application.Features.Positions.DTOs;
using MediatR;

namespace BolsaIR.Application.Features.Positions.Queries.GetPositions;

public sealed record GetPositionsQuery() : IRequest<List<PositionListDto>>;