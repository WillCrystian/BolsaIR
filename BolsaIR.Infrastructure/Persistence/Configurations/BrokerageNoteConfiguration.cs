using BolsaIR.Domain.Entities;
using BolsaIR.Infrastructure.Persistence.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BolsaIR.Infrastructure.Persistence.Configurations;

public sealed class BrokerageNoteConfiguration : BaseConfiguration<BrokerageNote>
{
	protected override void ConfigureEntity(EntityTypeBuilder<BrokerageNote> builder)
	{
		builder.ToTable("BrokerageNotes");		

		builder.Property(x => x.NoteNumber)
			.HasMaxLength(50)
			.IsRequired();

		builder.Property(x => x.TradeDate)
			.HasDateOnly();

		builder.Property(x => x.FileName)
			.HasMaxLength(250);

		builder.Property(x => x.Observation)
			.HasMaxLength(500);

		builder.Property(x => x.SettlementDate)
			.HasDateOnly();

		builder.Property(x => x.TotalValue).HasMoney();
		builder.Property(x => x.NetValue).HasMoney();
		builder.Property(x => x.LiquidValue).HasMoney();

		builder.Property(x => x.BrokerageFee).HasMoney();
		builder.Property(x => x.ExchangeFee).HasMoney();
		builder.Property(x => x.RegistrationFee).HasMoney();
		builder.Property(x => x.SettlementFee).HasMoney();
		builder.Property(x => x.Emoluments).HasMoney();
		builder.Property(x => x.OtherFees).HasMoney();
		builder.Property(x => x.Irrf).HasMoney();

		builder.Ignore(x => x.TotalFees);
		builder.Ignore(x => x.OperationsCount);

		builder.HasOne(x => x.Broker)
			.WithMany(x => x.BrokerageNotes)
			.HasForeignKey(x => x.BrokerId)
			.OnDelete(DeleteBehavior.Restrict);

		builder.HasMany(x => x.Operations)
			.WithOne(x => x.BrokerageNote)
			.HasForeignKey(x => x.BrokerageNoteId)
			.OnDelete(DeleteBehavior.Restrict);

		builder.HasIndex(x => new
		{
			x.BrokerId,
			x.NoteNumber
		}).IsUnique();
	}
}