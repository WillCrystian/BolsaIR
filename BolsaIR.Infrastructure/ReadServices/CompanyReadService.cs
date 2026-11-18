using BolsaIR.Application.Features.Companies.DTOs;
using BolsaIR.Application.Features.Companies.Services;
using BolsaIR.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BolsaIR.Infrastructure.ReadServices;

public sealed class CompanyReadService : ICompanyReadService
{
	private readonly BolsaIRDbContext _context;

	public CompanyReadService(BolsaIRDbContext context)
	{
		_context = context;
	}

	public async Task<CompanyDetailsDto?> GetByIdAsync(Guid id)
	{
		return await _context.Companies
			.AsNoTracking()
			.Where(x => x.Id == id)
			.Select(x => new CompanyDetailsDto
			{
				Id = x.Id,
				Name = x.Name,
				TradingName = x.TradingName,
				Cnpj = x.Cnpj,
				Sector = x.Sector,
				Segment = x.Segment,
				Website = x.Website,
				IsActive = x.IsActive
			})
			.FirstOrDefaultAsync();
	}

	public async Task<List<CompanyListDto>> GetListAsync()
	{
		return await _context.Companies
			.AsNoTracking()
			.OrderBy(x => x.Name)
			.Select(x => new CompanyListDto
			{
				Id = x.Id,
				Name = x.Name,
				TradingName = x.TradingName,
				IsActive = x.IsActive
			})
			.ToListAsync();
	}

	public async Task<bool> ExistsAsync(string cnpj)
	{
		return await _context.Companies
			.AsNoTracking()
			.AnyAsync(x => x.Cnpj == cnpj);
	}

	public async Task<bool> HasAssetsAsync(Guid companyId)
	{
		return await _context.Assets
			.AsNoTracking()
			.AnyAsync(x => x.CompanyId == companyId);
	}
}