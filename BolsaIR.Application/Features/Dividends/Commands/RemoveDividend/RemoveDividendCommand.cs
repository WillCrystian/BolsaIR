using BolsaIR.Application.Common;
using MediatR;

namespace BolsaIR.Application.Features.Dividends.Commands.RemoveDividend;

public sealed record RemoveDividendCommand(Guid Id) : IRequest<Result>;