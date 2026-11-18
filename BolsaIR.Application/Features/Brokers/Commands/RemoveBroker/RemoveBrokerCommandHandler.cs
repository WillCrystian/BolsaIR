using BolsaIR.Application.Common;
using BolsaIR.Application.Features.BrokerageNotes.Services;
using BolsaIR.Domain.Entities;
using BolsaIR.Domain.Interfaces;
using MediatR;

namespace BolsaIR.Application.Features.Brokers.Commands.RemoveBroker;

public sealed class RemoveBrokerCommandHandler : IRequestHandler<RemoveBrokerCommand, Result>
{
	private readonly IRepository<Broker> _repository;
	private readonly IBrokerageNoteReadService _brokerageNoteReadService;
	private readonly IUnitOfWork _unitOfWork;

	public RemoveBrokerCommandHandler(
		IRepository<Broker> repository,
		IBrokerageNoteReadService brokerageNoteReadService,
		IUnitOfWork unitOfWork)
	{
		_repository = repository;
		_brokerageNoteReadService = brokerageNoteReadService;
		_unitOfWork = unitOfWork;
	}

	public async Task<Result> Handle(RemoveBrokerCommand request, CancellationToken cancellationToken)
	{
		var broker = await _repository.GetByIdAsync(
			request.Id,
			cancellationToken);

		if (broker is null)
			return Result.Failure(BrokerErrors.NotFound);

		var hasNotes = await _brokerageNoteReadService
			.ExistsForBrokerAsync(request.Id);

		if (hasNotes)
			return Result.Failure(BrokerErrors.HasBrokerageNotes);

		_repository.Remove(broker);

		await _unitOfWork.SaveChangesAsync(cancellationToken);

		return Result.Success();
	}
}