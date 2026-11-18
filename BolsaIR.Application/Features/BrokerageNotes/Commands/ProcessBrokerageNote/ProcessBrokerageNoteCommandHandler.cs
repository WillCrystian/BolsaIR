using BolsaIR.Application.Common;
using BolsaIR.Application.Features.BrokerageNotes.Commands.CreateBrokerageNote;
using BolsaIR.Application.Features.BrokerageNotes.Services;
using BolsaIR.Application.Features.PositionProcessing.Services;
using BolsaIR.Domain.Interfaces;
using MediatR;

namespace BolsaIR.Application.Features.BrokerageNotes.Commands.ProcessBrokerageNote;

public class ProcessBrokerageNoteCommandHandler : IRequestHandler<ProcessBrokerageNoteCommand, Result>
{
	private readonly IBrokerageNoteReadService _brokerageNoteReadService;
	private readonly IPositionProcessor _positionProcessor;
	private readonly IUnitOfWork _unitOfWork;
	public ProcessBrokerageNoteCommandHandler(IBrokerageNoteReadService brokerageNoteReadService, IPositionProcessor positionProcessor, IUnitOfWork unitOfWork)
	{
		_brokerageNoteReadService = brokerageNoteReadService;
		_positionProcessor = positionProcessor;
		_unitOfWork = unitOfWork;
	}

	public async Task<Result> Handle(ProcessBrokerageNoteCommand request, CancellationToken cancellationToken)
	{
		var brokerageNote =
			await _brokerageNoteReadService.GetForProcessingAsync(
				request.BrokerageNoteId,
				cancellationToken);

		if (brokerageNote is null)
			return Result.Failure(BrokerageNoteErrors.NotFound);

		await _positionProcessor.ProcessAsync(
			brokerageNote,
			cancellationToken);

		await _unitOfWork.SaveChangesAsync(cancellationToken);

		return Result.Success();
	}
}
