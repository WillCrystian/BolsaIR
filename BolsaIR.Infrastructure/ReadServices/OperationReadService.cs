using BolsaIR.Application.Features.Operations.DTOs;
using BolsaIR.Application.Features.Operations.Services;
using BolsaIR.Application.Features.TaxCalculation.DTOs;
using BolsaIR.Domain.Entities;
using BolsaIR.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BolsaIR.Infrastructure.ReadServices;

public sealed class OperationReadService : IOperationReadService
{
	private readonly BolsaIRDbContext _context;

	public OperationReadService(BolsaIRDbContext context)
	{
		_context = context;
	}

	public async Task<OperationDetailsDto?> GetByIdAsync(Guid id)
	{
		return await _context.Operations
			.AsNoTracking()
			.Where(x => x.Id == id)
			.Select(x => new OperationDetailsDto
			{
				Id = x.Id,
				BrokerageNoteId = x.BrokerageNoteId,
				AssetId = x.AssetId,

				OperationType = x.OperationType,
				TradeType = x.TradeType,

				Quantity = x.Quantity,
				UnitPrice = x.UnitPrice,

				GrossValue = x.GrossValue,
				TotalFees = x.TotalFees,
				NetValue = x.NetValue,

				BrokerageFee = x.BrokerageFee,
				ExchangeFee = x.ExchangeFee,
				RegistrationFee = x.RegistrationFee,
				SettlementFee = x.SettlementFee,
				Emoluments = x.Emoluments,
				OtherFees = x.OtherFees,

				Irrf = x.Irrf,

				SettlementDate = x.SettlementDate,

				Observation = x.Observation,

				Processed = x.Processed,
				ProcessedAt = x.ProcessedAt,

				ExternalId = x.ExternalId
			})
			.FirstOrDefaultAsync();
	}

	public async Task<List<OperationListDto>> GetListAsync()
	{
		return await _context.Operations
			.AsNoTracking()
			.OrderByDescending(x => x.SettlementDate)
			.Select(x => new OperationListDto
			{
				Id = x.Id,

				AssetTicker = x.Asset.Ticker,

				OperationType = x.OperationType,
				TradeType = x.TradeType,

				Quantity = x.Quantity,
				UnitPrice = x.UnitPrice,

				SettlementDate = x.SettlementDate,

				Processed = x.Processed
			})
			.ToListAsync();
	}

	public async Task<bool> ExistsAsync(Guid id)
	{
		return await _context.Operations
			.AsNoTracking()
			.AnyAsync(x => x.Id == id);
	}

	public async Task<List<OperationListDto>> GetByBrokerageNoteAsync(Guid brokerageNoteId)
	{
		return await _context.Operations
			.AsNoTracking()
			.Where(x => x.BrokerageNoteId == brokerageNoteId)
			.OrderBy(x => x.SettlementDate)
			.Select(x => new OperationListDto
			{
				Id = x.Id,

				AssetTicker = x.Asset.Ticker,

				OperationType = x.OperationType,
				TradeType = x.TradeType,

				Quantity = x.Quantity,
				UnitPrice = x.UnitPrice,

				SettlementDate = x.SettlementDate,

				Processed = x.Processed
			})
			.ToListAsync();
	}

	public async Task<List<OperationListDto>> GetByAssetAsync(Guid assetId)
	{
		return await _context.Operations
			.AsNoTracking()
			.Where(x => x.AssetId == assetId)
			.OrderBy(x => x.SettlementDate)
			.Select(x => new OperationListDto
			{
				Id = x.Id,

				AssetTicker = x.Asset.Ticker,

				OperationType = x.OperationType,
				TradeType = x.TradeType,

				Quantity = x.Quantity,
				UnitPrice = x.UnitPrice,

				SettlementDate = x.SettlementDate,

				Processed = x.Processed
			})
			.ToListAsync();
	}

	public async Task<List<Operation>> GetAllForPositionCalculationAsync(CancellationToken cancellationToken = default)
	{
		return await _context.Operations
			.Include(x => x.Asset)
			.AsNoTracking()
			.OrderBy(x => x.SettlementDate)
			.ThenBy(x => x.CreatedAt)
			.ToListAsync(cancellationToken);
	}

	public async Task<List<OperationForTaxCalculation>> GetAllForTaxCalculationAsync(int year, CancellationToken cancellationToken = default)
	{
		return await _context.Operations
			.AsNoTracking()
			.Include(x => x.Asset)
			.Where(x => x.SettlementDate.Year == year)
			.OrderBy(x => x.SettlementDate)
			.ThenBy(x => x.CreatedAt)
			.Select(x => new OperationForTaxCalculation
			{
				OperationId = x.Id,

				BrokerageNoteId = x.BrokerageNoteId,

				AssetId = x.AssetId,

				AssetTicker = x.Asset.Ticker,

				AssetType = x.Asset.AssetType,

				OperationType = x.OperationType,

				TradeType = x.TradeType,

				Quantity = x.Quantity,

				UnitPrice = x.UnitPrice,

				GrossValue = x.GrossValue,

				TotalFees = x.TotalFees,

				NetValue = x.NetValue,

				Irrf = x.Irrf,

				SettlementDate = x.SettlementDate
			})
			.ToListAsync(cancellationToken);
	}
}