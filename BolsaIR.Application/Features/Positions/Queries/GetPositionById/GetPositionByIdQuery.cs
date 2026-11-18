using BolsaIR.Application.Features.Positions.DTOs;
using MediatR;

namespace BolsaIR.Application.Features.Positions.Queries.GetPositionById;

public sealed record GetPositionByIdQuery(Guid Id)
	: IRequest<PositionDetailsDto?>;