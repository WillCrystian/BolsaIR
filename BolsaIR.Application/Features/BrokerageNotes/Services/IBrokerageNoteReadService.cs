using BolsaIR.Domain.Entities;

namespace BolsaIR.Application.Features.BrokerageNotes.Services;

public interface IBrokerageNoteReadService
{
	Task<bool> ExistsForBrokerAsync(Guid brokerId);

	Task<BrokerageNote?> GetForProcessingAsync(
		Guid brokerageNoteId,
		CancellationToken cancellationToken = default);
}
