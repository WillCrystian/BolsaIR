namespace BolsaIR.Domain.Taxation;

public static class TaxConstants
{
	/// <summary>
	/// Limite de isenção mensal para Swing Trade.
	/// </summary>
	public const decimal SwingTradeExemptionLimit = 20_000m;

	/// <summary>
	/// Alíquota de IRRF sobre Swing Trade.
	/// </summary>
	public const decimal SwingTradeWithholdingRate = 0.00005m;

	/// <summary>
	/// Alíquota de IRRF sobre Day Trade.
	/// </summary>
	public const decimal DayTradeWithholdingRate = 0.01m;
}