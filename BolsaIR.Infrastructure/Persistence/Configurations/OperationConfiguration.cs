using BolsaIR.Domain.Entities;
using BolsaIR.Infrastructure.Persistence.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BolsaIR.Infrastructure.Persistence.Configurations;

public sealed class OperationConfiguration : BaseConfiguration<Operation>
{
	protected override void ConfigureEntity(EntityTypeBuilder<Operation> builder)
	{
		builder.ToTable("Operations");

		builder.Property(x => x.UnitPrice)
			.HasMoney();

		builder.Property(x => x.BrokerageFee)
			.HasMoney();

		builder.Property(x => x.ExchangeFee)
			.HasMoney();

		builder.Property(x => x.RegistrationFee)
			.HasMoney();

		builder.Property(x => x.SettlementFee)
			.HasMoney();

		builder.Property(x => x.Emoluments)
			.HasMoney();

		builder.Property(x => x.OtherFees)
			.HasMoney();

		builder.Property(x => x.Irrf)
			.HasMoney();

		builder.Property(x => x.SettlementDate)
			.HasDateOnly();

		builder.Property(x => x.Observation)
			.HasMaxLength(500);

		builder.Property(x => x.ExternalId)
			.HasMaxLength(100);

		builder.Property(x => x.OperationType)
			.HasConversion<int>();

		builder.Property(x => x.TradeType)
			.HasConversion<int>();

		builder.Property(x => x.Processed);

		builder.Property(x => x.ProcessedAt);

		// Propriedades calculadas
		builder.Ignore(x => x.GrossValue);
		builder.Ignore(x => x.TotalFees);
		builder.Ignore(x => x.NetValue);

		builder.HasOne(x => x.Asset)
			.WithMany(x => x.Operations)
			.HasForeignKey(x => x.AssetId)
			.OnDelete(DeleteBehavior.Restrict);

		builder.HasOne(x => x.BrokerageNote)
			.WithMany(x => x.Operations)
			.HasForeignKey(x => x.BrokerageNoteId)
			.OnDelete(DeleteBehavior.Restrict);

		// Índices para consultas por ativo
		builder.HasIndex(x => new
		{
			x.AssetId,
			x.SettlementDate
		});

		// Índice para consultas por nota
		builder.HasIndex(x => x.BrokerageNoteId);

		// Índice para processamento
		builder.HasIndex(x => new
		{
			x.Processed,
			x.SettlementDate
		});

		// Índice para importação
		builder.HasIndex(x => x.ExternalId);
	}
}