using BolsaIR.Application.Features.Brokers.DTOs;
using BolsaIR.Application.Features.Brokers.Queries.GetBrokers;
using BolsaIR.Application.Features.Brokers.Services;
using MediatR;

public class GetBrokersHandler : IRequestHandler<GetBrokersQuery, List<BrokerListDto>>
{
	private readonly IBrokerReadService _service;

	public GetBrokersHandler(IBrokerReadService service)
	{
		_service = service;
	}

	public async Task<List<BrokerListDto>> Handle(
		GetBrokersQuery request,
		CancellationToken cancellationToken)
	{
		return await _service.GetListAsync();
	}
}