using BolsaIR.Domain.Entities;
using BolsaIR.Infrastructure.Persistence.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BolsaIR.Infrastructure.Persistence.Configurations;

public sealed class DividendConfiguration : BaseConfiguration<Dividend>
{
	protected override void ConfigureEntity(EntityTypeBuilder<Dividend> builder)
	{
		builder.ToTable("Dividends");

		builder.Property(x => x.ExDate)
			.HasDateOnly();

		builder.Property(x => x.PaymentDate)
			.HasDateOnly();

		builder.Property(x => x.ValuePerShare)
			.HasMoney();

		builder.HasOne(x => x.Asset)
			.WithMany(x => x.Dividends)
			.HasForeignKey(x => x.AssetId)
			.OnDelete(DeleteBehavior.Restrict);

		builder.HasIndex(x => new
		{
			x.AssetId,
			x.ExDate,
			x.Type
		});

		builder.Property(x => x.Type)
			.HasConversion<int>();
	}
}