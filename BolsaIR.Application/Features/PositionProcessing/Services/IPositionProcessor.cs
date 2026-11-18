using BolsaIR.Domain.Entities;

namespace BolsaIR.Application.Features.PositionProcessing.Services;

public interface IPositionProcessor
{
	Task ProcessAsync(BrokerageNote brokerageNote, CancellationToken cancellationToken = default);


}