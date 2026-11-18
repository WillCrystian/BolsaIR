using BolsaIR.Domain.Common;
using BolsaIR.Domain.Enums;

namespace BolsaIR.Domain.Entities;

public class Dividend : EntityBase
{
	private Dividend()
	{
	}

	public Dividend(Asset asset, DividendType type, DateOnly exDate, DateOnly paymentDate, decimal valuePerShare, string? description, string? externalId)
	{
		Asset = asset ?? throw new ArgumentNullException(nameof(asset));
		AssetId = asset.Id;

		ExternalId = string.IsNullOrWhiteSpace(externalId)
			? null
			: externalId.Trim();

		Update(type, exDate, paymentDate, valuePerShare, description);
	}

	public Guid AssetId { get; private set; }

	public Asset Asset { get; private set; } = null!;

	public DividendType Type { get; private set; }

	public DateOnly ExDate { get; private set; }

	public DateOnly PaymentDate { get; private set; }

	public decimal ValuePerShare { get; private set; }

	public string? Description { get; private set; }

	public string? ExternalId { get; private set; }

	public void Update(DividendType type, DateOnly exDate, DateOnly paymentDate, decimal valuePerShare, string? description)
	{
		if (valuePerShare <= 0)
			throw new ArgumentOutOfRangeException(nameof(valuePerShare));

		Type = type;
		ExDate = exDate;
		PaymentDate = paymentDate;
		ValuePerShare = valuePerShare;

		Description = string.IsNullOrWhiteSpace(description)
			? null
			: description.Trim();

		Touch();
	}
}