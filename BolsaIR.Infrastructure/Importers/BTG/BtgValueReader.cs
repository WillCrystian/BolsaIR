using BolsaIR.Infrastructure.Importers.BTG.Helpers;

namespace BolsaIR.Infrastructure.Importers.BTG;

internal sealed class BtgValueReader
{
	public void Read(BtgImportContext context)
	{
		ArgumentNullException.ThrowIfNull(context);

		context.Note.TotalValue =
			GetTotalValue(context.Lines);

		context.Note.NetValue =
			GetNetValue(context.Lines);

		context.Note.LiquidValue =
			GetLiquidValue(context.Lines);

		context.Note.Irrf =
			GetIrrf(context.Lines);
	}

	private static decimal GetTotalValue(
		IEnumerable<string> lines)
	{
		return BtgValueParser.GetValue(
			lines,
			BtgConstants.ValorOperacoes);
	}

	private static decimal GetNetValue(
		IEnumerable<string> lines)
	{
		return BtgValueParser.GetValue(
			lines,
			BtgConstants.ValorLiquidoOperacoes);
	}

	private static decimal GetLiquidValue(
		IEnumerable<string> lines)
	{
		return BtgValueParser.GetValue(
			lines,
			BtgConstants.LiquidoPara);
	}

	private static decimal GetIrrf(
		IEnumerable<string> lines)
	{
		return BtgValueParser.GetValue(
			lines,
			BtgConstants.Irrf);
	}
}