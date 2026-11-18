using BolsaIR.Domain.Interfaces;
using BolsaIR.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BolsaIR.Infrastructure.Repositories;

public class ReadRepository<TEntity> : IReadRepository<TEntity>
	where TEntity : class
{
	protected readonly BolsaIRDbContext Context;

	protected readonly DbSet<TEntity> DbSet;

	public ReadRepository(BolsaIRDbContext context)
	{
		Context = context;
		DbSet = context.Set<TEntity>();
	}

	public IQueryable<TEntity> Query()
	{
		return DbSet.AsNoTracking();
	}

	public async Task<TEntity?> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
	{
		return await DbSet
			.AsNoTracking()
			.FirstOrDefaultAsync(predicate, cancellationToken);
	}

	public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
	{
		return await DbSet.AnyAsync(predicate, cancellationToken);
	}	

	public async Task<List<TEntity>> ListAsync(Expression<Func<TEntity, bool>>? predicate = null, CancellationToken cancellationToken = default)
	{
		IQueryable<TEntity> query = DbSet.AsNoTracking();

		if (predicate != null)
			query = query.Where(predicate);

		return await query.ToListAsync(cancellationToken);
	}
}