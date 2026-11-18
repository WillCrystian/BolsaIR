using BolsaIR.Infrastructure.Importers.BTG.Helpers;

namespace BolsaIR.Infrastructure.Importers.BTG;

internal sealed class BtgFeeReader
{
	public void Read(BtgImportContext context)
	{
		ArgumentNullException.ThrowIfNull(context);

		context.Note.BrokerageFee =
			GetBrokerageFee(context.Lines);

		context.Note.ExchangeFee =
			GetExchangeFee(context.Lines);

		context.Note.RegistrationFee =
			GetRegistrationFee(context.Lines);

		context.Note.SettlementFee =
			GetSettlementFee(context.Lines);

		context.Note.Emoluments =
			GetEmoluments(context.Lines);

		context.Note.OtherFees =
			GetOtherFees(context.Lines);
	}

	private static decimal GetBrokerageFee(
		IEnumerable<string> lines)
	{
		return BtgValueParser.GetValue(
			lines,
			BtgConstants.Corretagem);
	}

	private static decimal GetExchangeFee(
		IEnumerable<string> lines)
	{
		// Algumas notas BTG não destacam esse valor.
		return 0m;
	}

	private static decimal GetRegistrationFee(
		IEnumerable<string> lines)
	{
		return BtgValueParser.GetValue(
			lines,
			BtgConstants.Registro);
	}

	private static decimal GetSettlementFee(
		IEnumerable<string> lines)
	{
		return BtgValueParser.GetValue(
			lines,
			BtgConstants.Liquidacao);
	}

	private static decimal GetEmoluments(
		IEnumerable<string> lines)
	{
		return BtgValueParser.GetValue(
			lines,
			BtgConstants.Emolumentos);
	}

	private static decimal GetOtherFees(
		IEnumerable<string> lines)
	{
		var outhersFee = BtgValueParser.GetValue(
			lines,
			BtgConstants.OutrasBovespa);

		var AssetTransferFee = BtgValueParser.GetValue(
			lines,
			BtgConstants.AssetTransferFee);

		//var AnaFee = BtgValueParser.GetValue(
		//	lines,
		//	BtgConstants.AnaFee);



		return outhersFee + AssetTransferFee;
	}
}