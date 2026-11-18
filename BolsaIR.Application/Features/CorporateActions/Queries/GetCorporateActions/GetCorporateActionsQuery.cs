using BolsaIR.Application.Common;
using BolsaIR.Application.Features.CorporateActions.DTOs;
using MediatR;

namespace BolsaIR.Application.Features.CorporateActions.Queries.GetCorporateActions;

public sealed record GetCorporateActionsQuery : IRequest<Result<List<CorporateActionListDto>>>;