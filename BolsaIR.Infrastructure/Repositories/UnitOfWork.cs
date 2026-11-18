using BolsaIR.Domain.Interfaces;
using BolsaIR.Infrastructure.Persistence;

namespace BolsaIR.Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork
{
	private readonly BolsaIRDbContext _context;

	public UnitOfWork(BolsaIRDbContext context)
	{
		_context = context;
	}

	public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
	{
		//Console.WriteLine("========== CHANGE TRACKER ==========");

		//foreach (var entry in _context.ChangeTracker.Entries())
		//{
		//	Console.WriteLine(
		//		$"{entry.Entity.GetType().Name} | {entry.State}");
		//}

		return _context.SaveChangesAsync(cancellationToken);
	}
}