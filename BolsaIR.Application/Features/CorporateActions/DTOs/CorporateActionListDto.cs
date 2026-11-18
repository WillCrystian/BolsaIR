using BolsaIR.Domain.Enums;

namespace BolsaIR.Application.Features.CorporateActions.DTOs;

public sealed class CorporateActionListDto
{
	public Guid Id { get; init; }

	public string AssetTicker { get; init; } = string.Empty;

	public CorporateActionType Type { get; init; }

	public DateOnly EffectiveDate { get; init; }
}