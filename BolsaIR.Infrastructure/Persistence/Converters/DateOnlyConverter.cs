using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BolsaIR.Infrastructure.Persistence.Converters;

public sealed class DateOnlyConverter : ValueConverter<DateOnly, DateTime>
{
	public DateOnlyConverter()
		: base(
			date => date.ToDateTime(TimeOnly.MinValue),
			date => DateOnly.FromDateTime(date))
	{
	}
}