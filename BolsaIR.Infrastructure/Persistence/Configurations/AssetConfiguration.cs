using BolsaIR.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BolsaIR.Infrastructure.Persistence.Configurations;

public sealed class AssetConfiguration : BaseConfiguration<Asset>
{
	protected override void ConfigureEntity(EntityTypeBuilder<Asset> builder)
	{
		builder.ToTable("Assets");

		builder.Property(x => x.Ticker)
			.HasMaxLength(20)
			.IsRequired();

		builder.Property(x => x.TradingName)
			.HasMaxLength(150)
			.IsRequired();

		builder.Property(x => x.CompanyName)
			.HasMaxLength(150);

		builder.Property(x => x.Cnpj)
			.HasMaxLength(20);

		builder.Property(x => x.Isin)
			.HasMaxLength(20);

		builder.Property(x => x.Sector)
			.HasMaxLength(100);

		builder.Property(x => x.Segment)
			.HasMaxLength(100);

		builder.HasIndex(x => x.Ticker)
			.IsUnique();

		builder.HasOne(x => x.Company)
			.WithMany(x => x.Assets)
			.HasForeignKey(x => x.CompanyId)
			.OnDelete(DeleteBehavior.Restrict);

		builder.Property(x => x.AssetType)
			.HasConversion<int>();
	}
}