using BolsaIR.Application.Common;
using BolsaIR.Application.Features.Dividends.DTOs;
using MediatR;

namespace BolsaIR.Application.Features.Dividends.Queries.GetDividendById;

public sealed record GetDividendByIdQuery(Guid Id) : IRequest<Result<DividendDetailsDto>>;