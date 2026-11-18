using BolsaIR.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BolsaIR.Infrastructure.Persistence;

public class BolsaIRDbContext : DbContext
{
	public BolsaIRDbContext(DbContextOptions<BolsaIRDbContext> options)
		: base(options)
	{
	}

	public DbSet<Asset> Assets => Set<Asset>();

	public DbSet<Broker> Brokers => Set<Broker>();

	public DbSet<BrokerageNote> BrokerageNotes => Set<BrokerageNote>();

	public DbSet<Company> Companies => Set<Company>();

	public DbSet<CorporateAction> CorporateActions => Set<CorporateAction>();

	public DbSet<Dividend> Dividends => Set<Dividend>();

	public DbSet<Holiday> Holidays => Set<Holiday>();

	public DbSet<Operation> Operations => Set<Operation>();

	public DbSet<Position> Positions => Set<Position>();

	public DbSet<Quote> Quotes => Set<Quote>();

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfigurationsFromAssembly(typeof(BolsaIRDbContext).Assembly);

		base.OnModelCreating(modelBuilder);
	}
	public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
	{
		return await base.SaveChangesAsync(cancellationToken);
	}
}