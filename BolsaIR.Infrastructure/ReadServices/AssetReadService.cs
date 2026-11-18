using BolsaIR.Application.Features.Assets.DTOs;
using BolsaIR.Application.Features.Assets.Services;
using BolsaIR.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BolsaIR.Infrastructure.ReadServices;

public sealed class AssetReadService : IAssetReadService
{
	private readonly BolsaIRDbContext _context;

	public AssetReadService(BolsaIRDbContext context)
	{
		_context = context;
	}

	public async Task<AssetDetailsDto?> GetByIdAsync(Guid id)
	{
		return await _context.Assets
			.AsNoTracking()
			.Where(x => x.Id == id)
			.Select(x => new AssetDetailsDto
			{
				Id = x.Id,
				Ticker = x.Ticker,
				TradingName = x.TradingName,
				CompanyName = x.CompanyName,
				Cnpj = x.Cnpj,
				Isin = x.Isin,
				AssetType = x.AssetType,
				Sector = x.Sector,
				Segment = x.Segment,
				IsActive = x.IsActive
			})
			.FirstOrDefaultAsync();
	}

	public async Task<List<AssetListDto>> GetListAsync()
	{
		return await _context.Assets
			.AsNoTracking()
			.OrderBy(x => x.Ticker)
			.Select(x => new AssetListDto
			{
				Id = x.Id,
				Ticker = x.Ticker,
				TradingName = x.TradingName,
				AssetType = x.AssetType,
				IsActive = x.IsActive
			})
			.ToListAsync();
	}

	public async Task<bool> ExistsByTickerAsync(string ticker, Guid? ignoreId = null)
	{
		ticker = ticker.Trim().ToUpperInvariant();

		var query = _context.Assets
			.AsNoTracking()
			.Where(x => x.Ticker == ticker);

		if (ignoreId.HasValue)
			query = query.Where(x => x.Id != ignoreId.Value);

		return await query.AnyAsync();
	}

	public async Task<bool> HasOperationsAsync(Guid assetId)
	{
		return await _context.Operations
			.AsNoTracking()
			.AnyAsync(x => x.AssetId == assetId);
	}

	public async Task<bool> HasPositionsAsync(Guid assetId)
	{
		return await _context.Positions
			.AsNoTracking()
			.AnyAsync(x => x.AssetId == assetId);
	}

	public async Task<bool> HasQuotesAsync(Guid assetId)
	{
		return await _context.Quotes
			.AsNoTracking()
			.AnyAsync(x => x.AssetId == assetId);
	}

	public async Task<bool> HasDividendsAsync(Guid assetId)
	{
		return await _context.Dividends
			.AsNoTracking()
			.AnyAsync(x => x.AssetId == assetId);
	}

	public async Task<bool> HasCorporateActionsAsync(Guid assetId)
	{
		return await _context.CorporateActions
			.AsNoTracking()
			.AnyAsync(x => x.AssetId == assetId);
	}
}