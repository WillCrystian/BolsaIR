using BolsaIR.Application.Features.PositionProcessing.Services;
using BolsaIR.Domain.Entities;
using BolsaIR.Domain.Enums;

namespace BolsaIR.Infrastructure.Services;

public sealed class PositionCalculationService : IPositionCalculationService
{
	public void ApplyOperation(
		Position position,
		Operation operation)
	{
		ArgumentNullException.ThrowIfNull(position);
		ArgumentNullException.ThrowIfNull(operation);

		switch (operation.OperationType)
		{
			case OperationType.Buy:

				position.Buy(
					operation.Quantity,
					operation.UnitPrice,
					operation.SettlementDate);

				break;

			case OperationType.Sell:

				position.Sell(
					operation.Quantity,
					operation.SettlementDate);

				break;

			default:

				throw new NotSupportedException(
					$"Tipo de operação '{operation.OperationType}' não suportado.");
		}
	}

	public void ApplyCorporateAction(
		Position position,
		CorporateAction corporateAction)
	{
		ArgumentNullException.ThrowIfNull(position);
		ArgumentNullException.ThrowIfNull(corporateAction);

		switch (corporateAction.Type)
		{
			case CorporateActionType.Split:

				position.ApplySplit(corporateAction.Factor);

				break;

			case CorporateActionType.ReverseSplit:

				position.ApplyReverseSplit(corporateAction.Factor);

				break;

			case CorporateActionType.Bonus:

				position.ApplyBonus(corporateAction.Factor);

				break;

			default:

				throw new NotSupportedException(
					$"Evento corporativo '{corporateAction.Type}' não suportado.");
		}
	}
}