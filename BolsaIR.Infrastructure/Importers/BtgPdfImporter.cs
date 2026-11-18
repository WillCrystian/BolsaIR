using BolsaIR.Application.Features.BrokerageNotes.DTOs;
using BolsaIR.Infrastructure.Importers.BTG;

namespace BolsaIR.Infrastructure.Importers;

public sealed class BtgPdfImporter : BasePdfImporter
{
	public override string BrokerName => "BTG";

	public override bool CanRead(byte[] pdfBytes)
	{
		var pages = ReadPages(pdfBytes);

		return pages.Any(page =>
			page.Words.Any(word =>
				word.Text.Contains("BTG", StringComparison.OrdinalIgnoreCase)));
	}

	public override Task<ImportBrokerageNoteDto> ImportAsync(
		byte[] pdfBytes,
		CancellationToken cancellationToken = default)
	{
		var pages = ReadPages(pdfBytes);

		var context = new BtgImportContext
		{
			Lines = BuildLines(pages.First())
		};

		new BtgHeaderReader()
			.Read(context);

		new BtgValueReader()
			.Read(context);

		new BtgFeeReader()
			.Read(context);

		new BtgOperationReader()
			.Read(context);

		new BtgFeeAllocator()
			.Allocate(context);

		return Task.FromResult(context.Note);
	}

}