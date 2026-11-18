using BolsaIR.Application.Common;
using BolsaIR.Domain.Entities;
using BolsaIR.Domain.Interfaces;
using MediatR;

namespace BolsaIR.Application.Features.Brokers.Commands.UpdateBroker;

public sealed class UpdateBrokerCommandHandler : IRequestHandler<UpdateBrokerCommand, Result>
{
	private readonly IRepository<Broker> _repository;
	private readonly IReadRepository<Broker> _readRepository;
	private readonly IUnitOfWork _unitOfWork;

	public UpdateBrokerCommandHandler(
		IRepository<Broker> repository,
		IReadRepository<Broker> readRepository,
		IUnitOfWork unitOfWork)
	{
		_repository = repository;
		_readRepository = readRepository;
		_unitOfWork = unitOfWork;
	}

	public async Task<Result> Handle(UpdateBrokerCommand request, CancellationToken cancellationToken)
	{
		var broker = await _repository.GetByIdAsync(
			request.Id,
			cancellationToken);

		if (broker is null)
			return Result.Failure(BrokerErrors.NotFound);

		var duplicated = await _readRepository.AnyAsync(
			x => x.Name == request.Name &&
				 x.Id != request.Id,
			cancellationToken);

		if (duplicated)
			return Result.Failure(BrokerErrors.AlreadyExists);

		broker.Update(
			request.Name,
			request.Cnpj,
			request.Website,
			request.ImporterName);

		_repository.Update(broker);

		await _unitOfWork.SaveChangesAsync(cancellationToken);

		return Result.Success();
	}
}