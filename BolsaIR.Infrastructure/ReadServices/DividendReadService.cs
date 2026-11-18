using BolsaIR.Application.Features.Dividends.DTOs;
using BolsaIR.Application.Features.Dividends.Services;
using BolsaIR.Domain.Enums;
using BolsaIR.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BolsaIR.Infrastructure.ReadServices;

public sealed class DividendReadService : IDividendReadService
{
	private readonly BolsaIRDbContext _context;

	public DividendReadService(BolsaIRDbContext context)
	{
		_context = context;
	}

	public async Task<DividendDetailsDto?> GetByIdAsync(Guid id)
	{
		return await _context.Dividends
			.AsNoTracking()
			.Where(x => x.Id == id)
			.Select(x => new DividendDetailsDto
			{
				Id = x.Id,
				AssetId = x.AssetId,
				AssetTicker = x.Asset.Ticker,
				Type = x.Type,
				ExDate = x.ExDate,
				PaymentDate = x.PaymentDate,
				ValuePerShare = x.ValuePerShare,
				Description = x.Description,
				ExternalId = x.ExternalId
			})
			.FirstOrDefaultAsync();
	}

	public async Task<List<DividendListDto>> GetListAsync()
	{
		return await _context.Dividends
			.AsNoTracking()
			.OrderByDescending(x => x.ExDate)
			.ThenBy(x => x.Asset.Ticker)
			.Select(x => new DividendListDto
			{
				Id = x.Id,
				AssetTicker = x.Asset.Ticker,
				Type = x.Type,
				ExDate = x.ExDate,
				ValuePerShare = x.ValuePerShare
			})
			.ToListAsync();
	}

	public async Task<bool> ExistsAsync(
		Guid assetId,
		DividendType type,
		DateOnly exDate,
		Guid? ignoreId = null)
	{
		var query = _context.Dividends
			.AsNoTracking()
			.Where(x =>
				x.AssetId == assetId &&
				x.Type == type &&
				x.ExDate == exDate);

		if (ignoreId.HasValue)
			query = query.Where(x => x.Id != ignoreId.Value);

		return await query.AnyAsync();
	}
}