using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace BolsaIR.Infrastructure.Persistence;

public class BolsaIRDbContextFactory : IDesignTimeDbContextFactory<BolsaIRDbContext>
{
	public BolsaIRDbContext CreateDbContext(string[] args)
	{
		var optionsBuilder = new DbContextOptionsBuilder<BolsaIRDbContext>();

		optionsBuilder.UseSqlite("Data Source=BolsaIR.db");

		return new BolsaIRDbContext(optionsBuilder.Options);
	}
}