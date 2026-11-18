using BolsaIR.Application.Common;

namespace BolsaIR.Application.Features.PositionProcessing.Errors;

public static class PositionProcessingErrors
{
	public static readonly Error BrokerageNoteAlreadyProcessed =
		new(
			"PositionProcessing.BrokerageNoteAlreadyProcessed",
			"A nota de corretagem já foi processada.");

	public static readonly Error PositionNotFound =
		new(
			"PositionProcessing.PositionNotFound",
			"Posição não encontrada.");

	public static readonly Error InvalidSell =
		new(
			"PositionProcessing.InvalidSell",
			"Venda maior que a posição.");

	public static readonly Error OperationAlreadyProcessed =
		new(
			"PositionProcessing.OperationAlreadyProcessed",
			"Operação já processada.");
}