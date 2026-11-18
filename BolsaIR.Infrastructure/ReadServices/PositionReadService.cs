using BolsaIR.Application.Features.Positions.DTOs;
using BolsaIR.Application.Features.Positions.Services;
using BolsaIR.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BolsaIR.Infrastructure.ReadServices;

public sealed class PositionReadService : IPositionReadService
{
	private readonly BolsaIRDbContext _context;

	public PositionReadService(BolsaIRDbContext context)
	{
		_context = context;
	}

	public async Task<PositionDetailsDto?> GetByIdAsync(Guid id)
	{
		return await _context.Positions
			.AsNoTracking()
			.Where(x => x.Id == id)
			.Select(x => new PositionDetailsDto
			{
				Id = x.Id,
				AssetId = x.AssetId,
				AssetTicker = x.Asset.Ticker,
				TradingName = x.Asset.TradingName,
				CompanyName = x.Asset.CompanyName,

				Quantity = x.Quantity,
				AveragePrice = x.AveragePrice,
				TotalCost = x.TotalCost,

				LastMovementDate = x.LastMovementDate,

				IsClosed = x.IsClosed
			})
			.FirstOrDefaultAsync();
	}

	public async Task<PositionDetailsDto?> GetByAssetAsync(Guid assetId)
	{
		return await _context.Positions
			.AsNoTracking()
			.Where(x => x.AssetId == assetId)
			.Select(x => new PositionDetailsDto
			{
				Id = x.Id,
				AssetId = x.AssetId,
				AssetTicker = x.Asset.Ticker,
				TradingName = x.Asset.TradingName,
				CompanyName = x.Asset.CompanyName,

				Quantity = x.Quantity,
				AveragePrice = x.AveragePrice,
				TotalCost = x.TotalCost,

				LastMovementDate = x.LastMovementDate,

				IsClosed = x.IsClosed
			})
			.FirstOrDefaultAsync();
	}

	public async Task<List<PositionListDto>> GetListAsync()
	{
		return await _context.Positions
			.AsNoTracking()
			.OrderBy(x => x.Asset.Ticker)
			.Select(x => new PositionListDto
			{
				Id = x.Id,
				AssetId = x.AssetId,
				AssetTicker = x.Asset.Ticker,

				Quantity = x.Quantity,
				AveragePrice = x.AveragePrice,
				TotalCost = x.TotalCost,

				IsClosed = x.IsClosed
			})
			.ToListAsync();
	}

	public async Task<List<PositionListDto>> GetOpenPositionsAsync()
	{
		return await _context.Positions
			.AsNoTracking()
			.Where(x => !x.IsClosed)
			.OrderBy(x => x.Asset.Ticker)
			.Select(x => new PositionListDto
			{
				Id = x.Id,
				AssetId = x.AssetId,
				AssetTicker = x.Asset.Ticker,

				Quantity = x.Quantity,
				AveragePrice = x.AveragePrice,
				TotalCost = x.TotalCost,

				IsClosed = x.IsClosed
			})
			.ToListAsync();
	}

	public async Task<List<PositionListDto>> GetClosedPositionsAsync()
	{
		return await _context.Positions
			.AsNoTracking()
			.Where(x => x.IsClosed)
			.OrderBy(x => x.Asset.Ticker)
			.Select(x => new PositionListDto
			{
				Id = x.Id,
				AssetId = x.AssetId,
				AssetTicker = x.Asset.Ticker,

				Quantity = x.Quantity,
				AveragePrice = x.AveragePrice,
				TotalCost = x.TotalCost,

				IsClosed = x.IsClosed
			})
			.ToListAsync();
	}

	public async Task<bool> ExistsAsync(Guid id)
	{
		return await _context.Positions
			.AsNoTracking()
			.AnyAsync(x => x.Id == id);
	}
}