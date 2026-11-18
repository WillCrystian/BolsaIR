using BolsaIR.Application.Common;

namespace BolsaIR.Application.Features.BrokerageNotes.Services;

public interface IImportBrokerageNoteService
{
	Task<Result> ImportAsync(
		Stream pdf,
		string fileName,
		CancellationToken cancellationToken);
}