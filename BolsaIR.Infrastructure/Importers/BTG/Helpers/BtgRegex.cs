namespace BolsaIR.Infrastructure.Importers.BTG.Helpers;

internal static class BtgRegex
{
	public const string Date = @"\d{2}/\d{2}/\d{4}";

	public const string Decimal = @"\d{1,3}(?:\.\d{3})*,\d{2}";

	public const string Ticker = @"^[A-Z]{4,8}[A-Z]?\d+$";
}