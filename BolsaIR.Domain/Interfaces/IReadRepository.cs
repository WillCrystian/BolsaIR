using System.Linq.Expressions;

namespace BolsaIR.Domain.Interfaces;

public interface IReadRepository<T>
	where T : class
{
	Task<T?> FirstOrDefaultAsync(
		Expression<Func<T, bool>> predicate,
		CancellationToken cancellationToken = default);

	Task<List<T>> ListAsync(
		Expression<Func<T, bool>>? predicate = null,
		CancellationToken cancellationToken = default);

	Task<bool> AnyAsync(
		Expression<Func<T, bool>> predicate,
		CancellationToken cancellationToken = default);

	IQueryable<T> Query();
}