using BolsaIR.Application.Common;
using BolsaIR.Domain.Enums;
using MediatR;

namespace BolsaIR.Application.Features.Dividends.Commands.CreateDividend;

public sealed class CreateDividendCommand : IRequest<Result<Guid>>
{
	public Guid AssetId { get; init; }

	public DividendType Type { get; init; }

	public DateOnly ExDate { get; init; }

	public DateOnly PaymentDate { get; init; }

	public decimal ValuePerShare { get; init; }

	public string? Description { get; init; }

	public string? ExternalId { get; init; }
}