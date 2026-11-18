using BolsaIR.Application.Features.BrokerageNotes.DTOs;

namespace BolsaIR.Application.Importers.Interfaces;

public interface IPdfImporter
{
	string BrokerName { get; }

	bool CanRead(byte[] pdfBytes);

	Task<ImportBrokerageNoteDto> ImportAsync(
		byte[] pdfBytes,
		CancellationToken cancellationToken = default);
}