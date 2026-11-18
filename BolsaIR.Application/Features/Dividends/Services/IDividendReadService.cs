using BolsaIR.Application.Features.Dividends.DTOs;
using BolsaIR.Domain.Enums;

namespace BolsaIR.Application.Features.Dividends.Services;

public interface IDividendReadService
{
	Task<DividendDetailsDto?> GetByIdAsync(Guid id);

	Task<List<DividendListDto>> GetListAsync();

	Task<bool> ExistsAsync(Guid assetId, DividendType type, DateOnly exDate, Guid? ignoreId = null);
}