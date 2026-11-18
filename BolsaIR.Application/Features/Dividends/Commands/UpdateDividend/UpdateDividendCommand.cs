using BolsaIR.Application.Common;
using BolsaIR.Domain.Enums;
using MediatR;

namespace BolsaIR.Application.Features.Dividends.Commands.UpdateDividend;

public sealed class UpdateDividendCommand : IRequest<Result>
{
	public Guid Id { get; init; }

	public DividendType Type { get; init; }

	public DateOnly ExDate { get; init; }

	public DateOnly PaymentDate { get; init; }

	public decimal ValuePerShare { get; init; }

	public string? Description { get; init; }
}