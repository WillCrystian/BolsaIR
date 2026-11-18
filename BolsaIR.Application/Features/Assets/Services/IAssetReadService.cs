using BolsaIR.Application.Features.Assets.DTOs;

namespace BolsaIR.Application.Features.Assets.Services;

public interface IAssetReadService
{
	Task<AssetDetailsDto?> GetByIdAsync(Guid id);

	Task<List<AssetListDto>> GetListAsync();

	Task<bool> ExistsByTickerAsync(
		string ticker,
		Guid? ignoreId = null);

	Task<bool> HasOperationsAsync(Guid assetId);

	Task<bool> HasPositionsAsync(Guid assetId);

	Task<bool> HasQuotesAsync(Guid assetId);

	Task<bool> HasDividendsAsync(Guid assetId);

	Task<bool> HasCorporateActionsAsync(Guid assetId);
}