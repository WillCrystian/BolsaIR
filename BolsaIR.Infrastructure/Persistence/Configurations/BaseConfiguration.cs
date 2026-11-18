using BolsaIR.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BolsaIR.Infrastructure.Persistence.Configurations;

public abstract class BaseConfiguration<TEntity> : IEntityTypeConfiguration<TEntity>
	where TEntity : EntityBase
{
	public virtual void Configure(EntityTypeBuilder<TEntity> builder)
	{
		builder.HasKey(x => x.Id);

		builder.Property(x => x.CreatedAt)
			.IsRequired();

		builder.Property(x => x.UpdatedAt);

		ConfigureEntity(builder);
	}

	protected abstract void ConfigureEntity(EntityTypeBuilder<TEntity> builder);
}