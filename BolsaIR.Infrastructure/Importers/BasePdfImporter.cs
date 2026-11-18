using BolsaIR.Application.Features.BrokerageNotes.DTOs;
using BolsaIR.Application.Importers.Interfaces;
using BolsaIR.Infrastructure.Pdf;

namespace BolsaIR.Infrastructure.Importers;

public abstract class BasePdfImporter : IPdfImporter
{
	public abstract string BrokerName { get; }

	public abstract bool CanRead(byte[] pdfBytes);

	public abstract Task<ImportBrokerageNoteDto> ImportAsync(
		byte[] pdfBytes,
		CancellationToken cancellationToken = default);

	protected List<PdfPage> ReadPages(byte[] pdfBytes)
	{
		using var stream = new MemoryStream(pdfBytes);

		var reader = new PdfPigReaderService();

		return reader.ExtractPages(stream);
	}

	protected static List<string> BuildLines(PdfPage page)
	{
		return PdfLineBuilder.BuildLines(page);
	}
}