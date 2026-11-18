using BolsaIR.Domain.Entities;
using BolsaIR.Infrastructure.Persistence.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BolsaIR.Infrastructure.Persistence.Configurations;

public sealed class PositionConfiguration : BaseConfiguration<Position>
{
	protected override void ConfigureEntity(EntityTypeBuilder<Position> builder)
	{
		builder.ToTable("Positions");

		builder.Property(x => x.Quantity)
			.HasPrecision(18, 8);

		builder.Property(x => x.AveragePrice)
			.HasMoney();

		builder.Property(x => x.TotalCost)
			.HasMoney();

		builder.Property(x => x.LastMovementDate)
			.HasNullableDateOnly();

		builder.Ignore(x => x.IsClosed);

		builder.HasOne(x => x.Asset)
			.WithMany(x => x.Positions)
			.HasForeignKey(x => x.AssetId)
			.OnDelete(DeleteBehavior.Restrict);

		builder.HasIndex(x => x.AssetId)
			.IsUnique();
	}
}