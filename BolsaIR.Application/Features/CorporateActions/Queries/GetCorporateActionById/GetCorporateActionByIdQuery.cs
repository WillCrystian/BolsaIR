using BolsaIR.Application.Common;
using BolsaIR.Application.Features.CorporateActions.DTOs;
using MediatR;

namespace BolsaIR.Application.Features.CorporateActions.Queries.GetCorporateActionById;

public sealed record GetCorporateActionByIdQuery(Guid Id) : IRequest<Result<CorporateActionDetailsDto>>;