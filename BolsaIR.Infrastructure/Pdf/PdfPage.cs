namespace BolsaIR.Infrastructure.Pdf;

public sealed class PdfPage
{
	public int PageNumber { get; init; }

	public List<PdfWord> Words { get; } = [];
}