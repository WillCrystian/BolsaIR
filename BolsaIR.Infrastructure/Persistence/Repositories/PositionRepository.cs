using BolsaIR.Domain.Entities;
using BolsaIR.Domain.Interfaces;
using BolsaIR.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BolsaIR.Infrastructure.Persistence.Repositories;

public sealed class PositionRepository : Repository<Position>, IPositionRepository
{
	private readonly BolsaIRDbContext _context;

	public PositionRepository(BolsaIRDbContext context)
		: base(context)
	{
		_context = context;
	}

	public async Task<Position?> GetByAssetIdAsync(
		Guid assetId,
		CancellationToken cancellationToken = default)
	{
		return await _context.Positions
			.Include(x => x.Asset)
			.FirstOrDefaultAsync(
				x => x.AssetId == assetId,
				cancellationToken);
	}
}