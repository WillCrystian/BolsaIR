using System.Globalization;
using System.Text.RegularExpressions;

namespace BolsaIR.Infrastructure.Importers.BTG.Helpers;

internal static class BtgValueParser
{
	private static readonly CultureInfo PtBr = new("pt-BR");

	public static decimal GetValue(
		IEnumerable<string> lines,
		string identifier)
	{
		var line = lines.FirstOrDefault(
			x => x.Contains(
				identifier,
				StringComparison.OrdinalIgnoreCase));

		if (line is null)
			return 0m;

		return GetValueFromLine(
			line,
			identifier);
	}

	public static decimal GetValueFromLine(
		string line,
		string identifier)
	{
		if (string.IsNullOrWhiteSpace(line))
			return 0m;

		var index = line.IndexOf(
			identifier,
			StringComparison.OrdinalIgnoreCase);

		if (index < 0)
			return 0m;

		var valuePart =
			line[(index + identifier.Length)..];

		var match =
			Regex.Match(
				valuePart,
				BtgRegex.Decimal);

		if (!match.Success)
			return 0m;

		return decimal.Parse(
			match.Value,
			PtBr);
	}

	public static DateOnly? GetDate(string line)
	{
		if (string.IsNullOrWhiteSpace(line))
			return null;

		var match =
			Regex.Match(
				line,
				BtgRegex.Date);

		if (!match.Success)
			return null;

		if (DateOnly.TryParseExact(
			match.Value,
			"dd/MM/yyyy",
			CultureInfo.InvariantCulture,
			DateTimeStyles.None,
			out var date))
		{
			return date;
		}

		return null;
	}


}