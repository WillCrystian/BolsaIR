using BolsaIR.Domain.Enums;

namespace BolsaIR.Application.Features.CorporateActions.DTOs;

public sealed class CorporateActionDto
{
	public Guid Id { get; init; }

	public Guid AssetId { get; init; }

	public string AssetTicker { get; init; } = string.Empty;

	public CorporateActionType Type { get; init; }

	public DateOnly ApprovedDate { get; init; }

	public DateOnly EffectiveDate { get; init; }

	public decimal Factor { get; init; }

	public string? Description { get; init; }
}