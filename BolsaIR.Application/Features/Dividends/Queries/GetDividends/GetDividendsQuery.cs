using BolsaIR.Application.Common;
using BolsaIR.Application.Features.Dividends.DTOs;
using MediatR;

namespace BolsaIR.Application.Features.Dividends.Queries.GetDividends;

public sealed record GetDividendsQuery : IRequest<Result<List<DividendListDto>>>;