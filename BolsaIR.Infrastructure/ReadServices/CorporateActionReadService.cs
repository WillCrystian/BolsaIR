using BolsaIR.Application.Features.CorporateActions.DTOs;
using BolsaIR.Application.Features.CorporateActions.Services;
using BolsaIR.Domain.Enums;
using BolsaIR.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BolsaIR.Infrastructure.ReadServices;

public sealed class CorporateActionReadService : ICorporateActionReadService
{
	private readonly BolsaIRDbContext _context;

	public CorporateActionReadService(BolsaIRDbContext context)
	{
		_context = context;
	}

	public async Task<CorporateActionDetailsDto?> GetByIdAsync(Guid id)
	{
		return await _context.CorporateActions
			.AsNoTracking()
			.Where(x => x.Id == id)
			.Select(x => new CorporateActionDetailsDto
			{
				Id = x.Id,
				AssetId = x.AssetId,
				AssetTicker = x.Asset.Ticker,
				Type = x.Type,
				ApprovedDate = x.ApprovedDate,
				EffectiveDate = x.EffectiveDate,
				Factor = x.Factor,
				Description = x.Description
			})
			.FirstOrDefaultAsync();
	}

	public async Task<List<CorporateActionListDto>> GetListAsync()
	{
		return await _context.CorporateActions
			.AsNoTracking()
			.OrderByDescending(x => x.EffectiveDate)
			.ThenBy(x => x.Asset.Ticker)
			.Select(x => new CorporateActionListDto
			{
				Id = x.Id,
				AssetTicker = x.Asset.Ticker,
				Type = x.Type,
				EffectiveDate = x.EffectiveDate
			})
			.ToListAsync();
	}

	public async Task<bool> ExistsAsync(Guid assetId, CorporateActionType type, DateOnly effectiveDate, Guid? ignoreId = null)
	{
		var query = _context.CorporateActions
			.AsNoTracking()
			.Where(x =>
				x.AssetId == assetId &&
				x.Type == type &&
				x.EffectiveDate == effectiveDate);

		if (ignoreId.HasValue)
			query = query.Where(x => x.Id != ignoreId.Value);

		return await query.AnyAsync();
	}
}