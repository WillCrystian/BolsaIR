using BolsaIR.Application.Features.BrokerageNotes.DTOs;

namespace BolsaIR.Infrastructure.Importers.BTG;

public sealed class BtgImportContext
{
	public List<string> Lines { get; init; } = [];

	public ImportBrokerageNoteDto Note { get; } =
		new();
}