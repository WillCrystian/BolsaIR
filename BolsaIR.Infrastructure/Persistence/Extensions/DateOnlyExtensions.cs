using BolsaIR.Infrastructure.Persistence.Converters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BolsaIR.Infrastructure.Persistence.Extensions;

public static class DateOnlyExtensions
{
	public static PropertyBuilder<DateOnly> HasDateOnly(
		this PropertyBuilder<DateOnly> builder)
	{
		return builder.HasConversion<DateOnlyConverter>();
	}

	public static PropertyBuilder<DateOnly?> HasDateOnly(
		this PropertyBuilder<DateOnly?> builder)
	{
		return builder.HasConversion<NullableDateOnlyConverter>();
	}

	public static PropertyBuilder<DateOnly?> HasNullableDateOnly(
		this PropertyBuilder<DateOnly?> builder)
	{
		builder.HasConversion(
			v => v,
			v => v);

		builder.HasColumnType("TEXT");

		return builder;
	}
}