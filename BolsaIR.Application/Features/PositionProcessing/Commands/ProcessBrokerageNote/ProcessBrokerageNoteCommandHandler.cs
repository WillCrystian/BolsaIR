using BolsaIR.Application.Common;
using BolsaIR.Application.Features.BrokerageNotes;
using BolsaIR.Application.Features.BrokerageNotes.Services;
using BolsaIR.Application.Features.PositionProcessing.Services;
using BolsaIR.Domain.Entities;
using BolsaIR.Domain.Interfaces;
using MediatR;

namespace BolsaIR.Application.Features.PositionProcessing.Commands.ProcessBrokerageNote;

public sealed class ProcessBrokerageNoteCommandHandler : IRequestHandler<ProcessBrokerageNoteCommand, Result>
{
	private readonly IBrokerageNoteReadService _brokerageNoteReadService;
	private readonly IPositionProcessor _positionProcessor;
	private readonly IUnitOfWork _unitOfWork;

	public ProcessBrokerageNoteCommandHandler(
		IBrokerageNoteReadService brokerageNoteReadService,
		IPositionProcessor positionProcessor,
		IUnitOfWork unitOfWork)
	{
		_brokerageNoteReadService = brokerageNoteReadService;
		_positionProcessor = positionProcessor;
		_unitOfWork = unitOfWork;
	}

	public async Task<Result> Handle(ProcessBrokerageNoteCommand request, CancellationToken cancellationToken)
	{
		var note = await _brokerageNoteReadService.GetForProcessingAsync(
	request.BrokerageNoteId,
	cancellationToken);

		if (note is null)
			return Result.Failure(BrokerageNoteErrors.NotFound);

		await _positionProcessor.ProcessAsync(
			note,
			cancellationToken);

		await _unitOfWork.SaveChangesAsync(cancellationToken);

		return Result.Success();
	}
}