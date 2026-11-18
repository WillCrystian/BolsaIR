using BolsaIR.Domain.Interfaces;
using BolsaIR.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

namespace BolsaIR.Infrastructure.Repositories;

public class Repository<TEntity> : IRepository<TEntity>
	where TEntity : class
{
	protected readonly BolsaIRDbContext _context;

	protected readonly DbSet<TEntity> DbSet;

	public Repository(BolsaIRDbContext context)
	{
		_context = context;
		DbSet = context.Set<TEntity>();
	}
	public async Task<TEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
	{
		return await DbSet
		   .AsNoTracking()
		   .FirstOrDefaultAsync(
			   e => EF.Property<Guid>(e, "Id") == id,
			   cancellationToken);
	}
	public async Task AddAsync(TEntity entity, CancellationToken cancellationToken = default)
	{
		await DbSet.AddAsync(entity, cancellationToken);
	}

	public void Attach(TEntity entity)
	{
		_context.Attach(entity);
	}

	public void Update(TEntity entity)
	{
		DbSet.Update(entity);
	}

	public void Remove(TEntity entity)
	{
		DbSet.Remove(entity);
	}

	public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
	{
		return await DbSet
			.AsNoTracking()
			.AnyAsync(predicate, cancellationToken);
	}
}