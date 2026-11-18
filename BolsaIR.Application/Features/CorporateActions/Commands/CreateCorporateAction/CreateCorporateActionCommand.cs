using BolsaIR.Application.Common;
using BolsaIR.Domain.Enums;
using MediatR;

namespace BolsaIR.Application.Features.CorporateActions.Commands.CreateCorporateAction;

public sealed record CreateCorporateActionCommand : IRequest<Result<Guid>>
{
	public Guid AssetId { get; init; }

	public CorporateActionType Type { get; init; }

	public DateOnly ApprovedDate { get; init; }

	public DateOnly EffectiveDate { get; init; }

	public decimal Factor { get; init; }

	public string? Description { get; init; }

	public string? ExternalId { get; init; }
}