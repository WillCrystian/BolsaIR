using BolsaIR.Application.Features.PositionProcessing.Services;
using BolsaIR.Domain.Entities;
using BolsaIR.Domain.Enums;
using BolsaIR.Domain.Interfaces;

namespace BolsaIR.Infrastructure.Services;

public sealed class PositionProcessor : IPositionProcessor
{
	private readonly IPositionRepository _positionRepository;

	public PositionProcessor(IPositionRepository positionRepository)
	{
		_positionRepository = positionRepository;
	}

	public async Task ProcessAsync(BrokerageNote brokerageNote, CancellationToken cancellationToken = default)
	{
		var operations = brokerageNote.Operations
			.OrderBy(x => x.SettlementDate)
			.ThenBy(x => x.CreatedAt);

		foreach (var operation in operations)
		{
			if (operation.Processed)
				continue;

			var position = await _positionRepository.GetByAssetIdAsync(
				operation.AssetId,
				cancellationToken);

			if (position is null)
			{
				position = new Position(operation.Asset);

				await _positionRepository.AddAsync(
					position,
					cancellationToken);
			}

			switch (operation.OperationType)
			{
				case OperationType.Buy:

					position.Buy(
						operation.Quantity,
						operation.NetValue,
						operation.SettlementDate);

					break;

				case OperationType.Sell:

					position.Sell(
						operation.Quantity,
						operation.SettlementDate);

					break;

				default:

					throw new InvalidOperationException(
						$"OperationType {operation.OperationType} não suportado.");
			}

			operation.MarkAsProcessed();

			_positionRepository.Update(position);
		}
	}
}