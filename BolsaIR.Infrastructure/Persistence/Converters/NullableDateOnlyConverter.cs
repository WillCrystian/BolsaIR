using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BolsaIR.Infrastructure.Persistence.Converters;

public sealed class NullableDateOnlyConverter : ValueConverter<DateOnly?, DateTime?>
{
	public NullableDateOnlyConverter()
		: base(
			date => date.HasValue
				? date.Value.ToDateTime(TimeOnly.MinValue)
				: null,

			date => date.HasValue
				? DateOnly.FromDateTime(date.Value)
				: null)
	{
	}
}