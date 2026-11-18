using BolsaIR.Application.Common;

namespace BolsaIR.Application.Features.Operations;

public static class OperationErrors
{
	public static readonly Error NotFound =
		new(
			"Operation.NotFound",
			"Operação não encontrada.");

	public static readonly Error AlreadyExists =
		new(
			"Operation.AlreadyExists",
			"Já existe uma operação com os mesmos dados.");

	public static readonly Error BrokerageNoteNotFound =
		new(
			"Operation.BrokerageNoteNotFound",
			"Nota de corretagem não encontrada.");

	public static readonly Error AssetNotFound =
		new(
			"Operation.AssetNotFound",
			"Ativo não encontrado.");

	public static readonly Error AlreadyProcessed =
		new(
			"Operation.AlreadyProcessed",
			"Esta operação já foi processada.");
}