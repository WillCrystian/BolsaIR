using BolsaIR.Domain.Entities;
using BolsaIR.Infrastructure.Persistence.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BolsaIR.Infrastructure.Persistence.Configurations;

public sealed class CorporateActionConfiguration : BaseConfiguration<CorporateAction>
{
	protected override void ConfigureEntity(EntityTypeBuilder<CorporateAction> builder)
	{
		builder.ToTable("CorporateActions");

		builder.Property(x => x.ApprovedDate)
			.HasDateOnly();

		builder.Property(x => x.EffectiveDate)
			.HasDateOnly();

		builder.Property(x => x.Factor)
			.HasPrecision(18, 8);

		builder.Property(x => x.Description)
			.HasMaxLength(500);

		builder.HasOne(x => x.Asset)
			.WithMany(x => x.CorporateActions)
			.HasForeignKey(x => x.AssetId)
			.OnDelete(DeleteBehavior.Restrict);

		builder.HasIndex(x => new
		{
			x.AssetId,
			x.ApprovedDate,
			x.Type
		});

		builder.Property(x => x.Type)
			.HasConversion<int>();
	}
}