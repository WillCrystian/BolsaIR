using BolsaIR.Application.Features.Brokers.DTOs;

namespace BolsaIR.Application.Features.Brokers.Services;

public interface IBrokerReadService
{
	Task<bool> ExistsAsync(string name);

	Task<BrokerDetailsDto?> GetByIdAsync(Guid id);

	Task<List<BrokerListDto>> GetListAsync();
}