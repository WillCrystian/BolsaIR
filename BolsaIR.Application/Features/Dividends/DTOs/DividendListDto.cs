using BolsaIR.Domain.Enums;

namespace BolsaIR.Application.Features.Dividends.DTOs;

public sealed class DividendListDto
{
	public Guid Id { get; init; }

	public string AssetTicker { get; init; } = string.Empty;

	public DividendType Type { get; init; }

	public DateOnly ExDate { get; init; }

	public decimal ValuePerShare { get; init; }
}