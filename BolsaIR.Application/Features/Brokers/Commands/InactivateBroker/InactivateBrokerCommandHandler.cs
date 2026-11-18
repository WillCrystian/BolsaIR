using BolsaIR.Application.Common;
using BolsaIR.Domain.Entities;
using BolsaIR.Domain.Interfaces;
using MediatR;

namespace BolsaIR.Application.Features.Brokers.Commands.InactivateBroker;

public sealed class InactivateBrokerCommandHandler : IRequestHandler<InactivateBrokerCommand, Result>
{
	private readonly IRepository<Broker> _repository;
	private readonly IUnitOfWork _unitOfWork;

	public InactivateBrokerCommandHandler(
		IRepository<Broker> repository,
		IUnitOfWork unitOfWork)
	{
		_repository = repository;
		_unitOfWork = unitOfWork;
	}

	public async Task<Result> Handle(
		InactivateBrokerCommand request,
		CancellationToken cancellationToken)
	{
		var broker = await _repository.GetByIdAsync(
			request.Id,
			cancellationToken);

		if (broker is null)
			return Result.Failure(BrokerErrors.NotFound);

		broker.Inactivate();

		await _unitOfWork.SaveChangesAsync(cancellationToken);

		return Result.Success();
	}
}