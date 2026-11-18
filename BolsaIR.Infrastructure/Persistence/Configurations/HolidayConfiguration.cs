using BolsaIR.Domain.Entities;
using BolsaIR.Infrastructure.Persistence.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BolsaIR.Infrastructure.Persistence.Configurations;

public sealed class HolidayConfiguration : BaseConfiguration<Holiday>
{
	protected override void ConfigureEntity(EntityTypeBuilder<Holiday> builder)
	{
		builder.ToTable("Holidays");

		builder.Property(x => x.Date)
			.HasDateOnly();

		builder.Property(x => x.Description)
			.HasMaxLength(150)
			.IsRequired();

		builder.HasIndex(x => x.Date)
			.IsUnique();
	}
}