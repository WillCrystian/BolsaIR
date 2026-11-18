using BolsaIR.Domain.Enums;

namespace BolsaIR.Application.Features.Dividends.DTOs;

public sealed class DividendDto
{
	public Guid Id { get; init; }

	public Guid AssetId { get; init; }

	public DividendType Type { get; init; }

	public DateOnly ExDate { get; init; }

	public DateOnly PaymentDate { get; init; }

	public decimal ValuePerShare { get; init; }
}