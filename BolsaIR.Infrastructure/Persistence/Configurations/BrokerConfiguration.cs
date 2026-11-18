using BolsaIR.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BolsaIR.Infrastructure.Persistence.Configurations;

public sealed class BrokerConfiguration : BaseConfiguration<Broker>
{
	protected override void ConfigureEntity(EntityTypeBuilder<Broker> builder)
	{
		builder.ToTable("Brokers");

		builder.Property(x => x.Name)
			.HasMaxLength(150)
			.IsRequired();

		builder.Property(x => x.Cnpj)
			.HasMaxLength(20);

		builder.Property(x => x.Website)
			.HasMaxLength(250);

		builder.Property(x => x.ImporterName)
			.HasMaxLength(100);

		builder.HasIndex(x => x.Name);		
	}
}