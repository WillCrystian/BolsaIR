using BolsaIR.Application.Features.Positions.DTOs;

namespace BolsaIR.Application.Features.Positions.Services;

public interface IPositionReadService
{
	Task<PositionDetailsDto?> GetByIdAsync(Guid id);

	Task<List<PositionListDto>> GetListAsync();

	Task<bool> ExistsAsync(Guid id);

	Task<List<PositionListDto>> GetOpenPositionsAsync();

	Task<List<PositionListDto>> GetClosedPositionsAsync();

	Task<PositionDetailsDto?> GetByAssetAsync(Guid assetId);
}