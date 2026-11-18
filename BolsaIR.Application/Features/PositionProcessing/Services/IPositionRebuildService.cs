using BolsaIR.Domain.Entities;

namespace BolsaIR.Application.Features.PositionProcessing.Services;

public interface IPositionRebuildService
{
	Task RebuildAsync(Guid assetId, CancellationToken cancellationToken);

	Task RebuildAllAsync(CancellationToken cancellationToken);
}