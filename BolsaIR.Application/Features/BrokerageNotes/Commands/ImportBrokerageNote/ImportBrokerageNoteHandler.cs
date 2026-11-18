using BolsaIR.Application.Common;
using BolsaIR.Application.Features.BrokerageNotes.Services;
using MediatR;

namespace BolsaIR.Application.Features.BrokerageNotes.Commands.ImportBrokerageNote;

public sealed class ImportBrokerageNoteHandler : IRequestHandler<ImportBrokerageNoteCommand, Result>
{
	private readonly IImportBrokerageNoteService _service;

	public ImportBrokerageNoteHandler(
		IImportBrokerageNoteService service)
	{
		_service = service;
	}

	public async Task<Result> Handle(ImportBrokerageNoteCommand request, CancellationToken cancellationToken)
	{
		return await _service.ImportAsync(
			request.File,
			request.FileName,
			cancellationToken);
	}
}