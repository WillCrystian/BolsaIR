using BolsaIR.Application.Features.Brokers.DTOs;
using BolsaIR.Application.Features.Brokers.Services;
using BolsaIR.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BolsaIR.Infrastructure.ReadServices;

public class BrokerReadService : IBrokerReadService
{
	private readonly BolsaIRDbContext _context;

	public BrokerReadService(BolsaIRDbContext context)
	{
		_context = context;
	}

	public async Task<BrokerDetailsDto?> GetByIdAsync(Guid id)
	{
		return await _context.Brokers
			.AsNoTracking()
			.Where(x => x.Id == id)
			.Select(x => new BrokerDetailsDto
			{
				Id = x.Id,
				Name = x.Name,
				Cnpj = x.Cnpj,
				Website = x.Website,
				ImporterName = x.ImporterName,
				IsActive = x.IsActive
			})
			.FirstOrDefaultAsync();
	}

	public async Task<List<BrokerListDto>> GetListAsync()
	{
		return await _context.Brokers
			.AsNoTracking()
			.OrderBy(x => x.Name)
			.Select(x => new BrokerListDto
			{
				Id = x.Id,
				Name = x.Name,
				IsActive = x.IsActive
			})
			.ToListAsync();
	}

	public async Task<bool> ExistsAsync(string name)
	{
		name = name.Trim().ToUpperInvariant();

		return await _context.Brokers
			.AsNoTracking()
			.AnyAsync(x => x.Name == name);
	}
}