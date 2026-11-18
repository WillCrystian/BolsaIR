using BolsaIR.Domain.Enums;

namespace BolsaIR.Application.Features.Dividends.DTOs;

public sealed class DividendDetailsDto
{
	public Guid Id { get; init; }

	public Guid AssetId { get; init; }

	public string AssetTicker { get; init; } = string.Empty;

	public DividendType Type { get; init; }

	public DateOnly ExDate { get; init; }

	public DateOnly PaymentDate { get; init; }

	public decimal ValuePerShare { get; init; }

	public string? Description { get; init; }

	public string? ExternalId { get; init; }
}