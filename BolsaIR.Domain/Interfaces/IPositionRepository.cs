using BolsaIR.Domain.Entities;

namespace BolsaIR.Domain.Interfaces;

public interface IPositionRepository : IRepository<Position>
{
	Task<Position?> GetByAssetIdAsync(
		Guid assetId,
		CancellationToken cancellationToken = default);
}