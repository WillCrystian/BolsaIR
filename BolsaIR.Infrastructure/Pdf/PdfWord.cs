namespace BolsaIR.Infrastructure.Pdf;

public sealed class PdfWord
{
	public int X { get; init; }

	public int Y { get; init; }

	public string Text { get; init; } = string.Empty;
}