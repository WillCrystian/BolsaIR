using BolsaIR.Application.Common;
using BolsaIR.Domain.Entities;
using BolsaIR.Domain.Interfaces;
using MediatR;

namespace BolsaIR.Application.Features.Brokers.Commands.CreateBroker;

public sealed class CreateBrokerCommandHandler : IRequestHandler<CreateBrokerCommand, Result<Guid>>
{
	private readonly IRepository<Broker> _repository;
	private readonly IReadRepository<Broker> _readRepository;
	private readonly IUnitOfWork _unitOfWork;

	public CreateBrokerCommandHandler(
		IRepository<Broker> repository,
		IReadRepository<Broker> readRepository,
		IUnitOfWork unitOfWork)
	{
		_repository = repository;
		_readRepository = readRepository;
		_unitOfWork = unitOfWork;
	}

	public async Task<Result<Guid>> Handle(CreateBrokerCommand request, CancellationToken cancellationToken)
	{
		var exists = await _readRepository.AnyAsync(
			x => x.Name == request.Name,
			cancellationToken);

		if (exists)
			return Result<Guid>.Failure(BrokerErrors.AlreadyExists);

		var broker = new Broker(request.Name);

		broker.UpdateInformation(request.Cnpj, request.Website);

		if (!string.IsNullOrWhiteSpace(request.ImporterName))
			broker.ConfigureImporter(request.ImporterName);

		await _repository.AddAsync(
			broker,
			cancellationToken);

		await _unitOfWork.SaveChangesAsync(
			cancellationToken);

		return Result<Guid>.Success(broker.Id);
	}
}