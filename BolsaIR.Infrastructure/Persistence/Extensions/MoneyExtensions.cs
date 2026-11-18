using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BolsaIR.Infrastructure.Persistence.Extensions;

public static class MoneyExtensions
{
	public static PropertyBuilder<decimal> HasMoney(this PropertyBuilder<decimal> builder)
	{
		return builder.HasPrecision(18, 6);
	}

	public static PropertyBuilder<decimal?> HasMoney(this PropertyBuilder<decimal?> builder)
	{
		return builder.HasPrecision(18, 6);
	}
}