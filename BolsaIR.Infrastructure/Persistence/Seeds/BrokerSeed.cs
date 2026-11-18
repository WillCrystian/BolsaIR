using BolsaIR.Domain.Entities;

namespace BolsaIR.Infrastructure.Persistence.Seeds;

public static class BrokerSeed
{
	public static void Seed(BolsaIRDbContext context)
	{
		if (context.Brokers.Any(x => x.Name == "BTG"))
			return;

		var btg = new Broker("BTG");

		context.Brokers.Add(btg);

		context.SaveChanges();
	}
}