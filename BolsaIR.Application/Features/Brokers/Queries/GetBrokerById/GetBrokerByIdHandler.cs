using BolsaIR.Application.Common;
using BolsaIR.Application.Features.Brokers.DTOs;
using BolsaIR.Domain.Entities;
using BolsaIR.Domain.Interfaces;
using MediatR;

namespace BolsaIR.Application.Features.Brokers.Queries.GetBrokerById;

public sealed class GetBrokerByIdHandler : IRequestHandler<GetBrokerByIdQuery, Result<BrokerDetailsDto>>
{
	private readonly IRepository<Broker> _repository;

	public GetBrokerByIdHandler(IRepository<Broker> repository)
	{
		_repository = repository;
	}

	public async Task<Result<BrokerDetailsDto>> Handle(GetBrokerByIdQuery request, CancellationToken cancellationToken)
	{
		var broker = await _repository.GetByIdAsync(
			request.Id,
			cancellationToken);

		if (broker is null)
			return Result<BrokerDetailsDto>.Failure(
				BrokerErrors.NotFound);

		return Result<BrokerDetailsDto>.Success(
			new BrokerDetailsDto
			{
				Id = broker.Id,
				Name = broker.Name,
				Cnpj = broker.Cnpj,
				Website = broker.Website,
				ImporterName = broker.ImporterName,
				IsActive = broker.IsActive
			});
	}
}