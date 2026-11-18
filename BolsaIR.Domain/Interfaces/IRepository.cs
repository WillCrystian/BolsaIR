namespace BolsaIR.Domain.Interfaces;

public interface IRepository<T>
	where T : class
{
	Task<T?> GetByIdAsync(
		Guid id,
		CancellationToken cancellationToken = default);

	Task AddAsync(
		T entity,
		CancellationToken cancellationToken = default);

	void Attach(T entity);

	void Update(T entity);

	void Remove(T entity);
}