using BolsaIR.Application.Common;

namespace BolsaIR.Application.Features.BrokerageNotes;

public static class BrokerageNoteErrors
{
	public static readonly Error NotFound =
		new(
			"BrokerageNote.ImporterNotFound",
			"Não foi encontrado para este PDF.");

	public static readonly Error ImporterNotFound =
		new(
			"BrokerageNote.BrokerageNotFound",
			"Não foi encontrada a corretora na nota.");

	public static Error BrokerNotFound(string broker)
		=> new(
			"BrokerageNote.BrokerNotFound",
			$"A corretora '{broker}' não está cadastrada.");

	public static Error BrokerageNoteAlreadyImported(string number)
		=> new(
			"BrokerageNote.AlreadyImported",
			$"A nota {number} já foi importada.");
}
