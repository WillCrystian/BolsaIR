using BolsaIR.Application.Features.Companies.DTOs;

namespace BolsaIR.Application.Features.Companies.Services;

public interface ICompanyReadService
{
	Task<CompanyDetailsDto?> GetByIdAsync(Guid id);

	Task<List<CompanyListDto>> GetListAsync();

	Task<bool> ExistsAsync(string cnpj);

	Task<bool> HasAssetsAsync(Guid companyId);
}