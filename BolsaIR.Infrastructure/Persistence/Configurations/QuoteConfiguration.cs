using BolsaIR.Domain.Entities;
using BolsaIR.Infrastructure.Persistence.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BolsaIR.Infrastructure.Persistence.Configurations;

public sealed class QuoteConfiguration : BaseConfiguration<Quote>
{
	protected override void ConfigureEntity(EntityTypeBuilder<Quote> builder)
	{
		builder.ToTable("Quotes");

		builder.Property(x => x.TradingDate)
			.HasDateOnly();

		builder.Property(x => x.Open)
			.HasMoney();

		builder.Property(x => x.High)
			.HasMoney();

		builder.Property(x => x.Low)
			.HasMoney();

		builder.Property(x => x.Close)
			.HasMoney();

		builder.Property(x => x.Volume);

		builder.HasOne(x => x.Asset)
			.WithMany(x => x.Quotes)
			.HasForeignKey(x => x.AssetId)
			.OnDelete(DeleteBehavior.Restrict);

		builder.HasIndex(x => new
		{
			x.AssetId,
			x.TradingDate
		}).IsUnique();
	}
}