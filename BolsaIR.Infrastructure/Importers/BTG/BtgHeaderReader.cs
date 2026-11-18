using BolsaIR.Infrastructure.Importers.BTG.Helpers;
using System.Globalization;

namespace BolsaIR.Infrastructure.Importers.BTG;

internal sealed class BtgHeaderReader 
{
	public void Read(BtgImportContext context)
	{
		ArgumentNullException.ThrowIfNull(context);

		context.Note.BrokerName = BtgConstants.BrokerName;

		context.Note.NoteNumber =
			GetNoteNumber(context.Lines);

		context.Note.TradeDate =
			GetTradeDate(context.Lines);

		context.Note.SettlementDate =
			GetSettlementDate(context.Lines);
	}

	private static string GetNoteNumber(List<string> lines)
	{
		var header =
			GetHeaderLine(lines);

		var parts =
			header.Split(
				' ',
				StringSplitOptions.RemoveEmptyEntries);

		return parts[0];
	}

	private static DateOnly GetTradeDate(List<string> lines)
	{
		var header =
			GetHeaderLine(lines);

		var parts =
			header.Split(
				' ',
				StringSplitOptions.RemoveEmptyEntries);

		return DateOnly.ParseExact(
			parts[2],
			"dd/MM/yyyy",
			CultureInfo.InvariantCulture);
	}

	private static DateOnly? GetSettlementDate(List<string> lines)
	{
		var line =
			lines.FirstOrDefault(x =>
				x.Contains(BtgConstants.LiquidoPara));

		if (line is null)
			return null;

		return BtgValueParser.GetDate(line);
	}

	private static string GetHeaderLine(List<string> lines)
	{
		if (lines.Count < 3)
			throw new InvalidOperationException(
				"Cabeçalho da nota não encontrado.");

		return lines[2];
	}
	
}