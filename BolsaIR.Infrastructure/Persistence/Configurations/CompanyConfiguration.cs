using BolsaIR.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BolsaIR.Infrastructure.Persistence.Configurations;

public sealed class CompanyConfiguration : BaseConfiguration<Company>
{
	protected override void ConfigureEntity(EntityTypeBuilder<Company> builder)
	{
		builder.ToTable("Companies");

		builder.Property(x => x.Name)
			.HasMaxLength(200)
			.IsRequired();

		builder.Property(x => x.TradingName)
			.HasMaxLength(150)
			.IsRequired();

		builder.Property(x => x.Cnpj)
			.HasMaxLength(20);

		builder.Property(x => x.Sector)
			.HasMaxLength(100);

		builder.Property(x => x.Segment)
			.HasMaxLength(100);

		builder.Property(x => x.Website)
			.HasMaxLength(250);

		builder.HasIndex(x => x.Cnpj)
			.IsUnique();
	}
}