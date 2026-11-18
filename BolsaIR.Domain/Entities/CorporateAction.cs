using BolsaIR.Domain.Common;
using BolsaIR.Domain.Enums;

namespace BolsaIR.Domain.Entities;

public class CorporateAction : EntityBase
{
	private CorporateAction()
	{
	}

	public CorporateAction(Asset asset, CorporateActionType type, DateOnly approvedDate, DateOnly effectiveDate, decimal factor, string? description, string? externalId)
	{
		Asset = asset ?? throw new ArgumentNullException(nameof(asset));
		AssetId = asset.Id;

		ExternalId = string.IsNullOrWhiteSpace(externalId)
			? null
			: externalId.Trim();

		Update(type, approvedDate, effectiveDate, factor, description);
	}

	public Guid AssetId { get; private set; }

	public Asset Asset { get; private set; } = null!;

	public CorporateActionType Type { get; private set; }

	public DateOnly ApprovedDate { get; private set; }

	public DateOnly EffectiveDate { get; private set; }

	/// <summary>
	/// 2.0 = desdobramento 1:2
	/// 0.5 = grupamento 2:1
	/// 1.1 = bonificação de 10%
	/// </summary>
	public decimal Factor { get; private set; }

	public string? Description { get; private set; }

	public string? ExternalId { get; private set; }

	public void Update(CorporateActionType type, DateOnly approvedDate, DateOnly effectiveDate, decimal factor, string? description)
	{
		if (factor <= 0)
			throw new ArgumentOutOfRangeException(nameof(factor));

		Type = type;
		ApprovedDate = approvedDate;
		EffectiveDate = effectiveDate;
		Factor = factor;

		Description = string.IsNullOrWhiteSpace(description)
			? null
			: description.Trim();

		Touch();
	}
}