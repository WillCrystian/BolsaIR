using BolsaIR.Application.Features.CorporateActions.DTOs;
using BolsaIR.Domain.Enums;

namespace BolsaIR.Application.Features.CorporateActions.Services;

public interface ICorporateActionReadService
{
	Task<CorporateActionDetailsDto?> GetByIdAsync(Guid id);

	Task<List<CorporateActionListDto>> GetListAsync();

	Task<bool> ExistsAsync(Guid assetId, CorporateActionType type, DateOnly effectiveDate, Guid? ignoreId = null);
}