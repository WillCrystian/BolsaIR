using BolsaIR.Domain.Entities;

namespace BolsaIR.Domain.Interfaces;

public interface IOperationRepository
{
	Task<List<Operation>> GetByAssetAsync(
		Guid assetId,
		CancellationToken cancellationToken = default);

	Task<List<Operation>> GetByBrokerageNoteAsync(
		Guid brokerageNoteId,
		CancellationToken cancellationToken = default);

	Task<List<Operation>> GetProcessedAsync(
		CancellationToken cancellationToken = default);
}
