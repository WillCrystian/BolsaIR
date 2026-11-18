using BolsaIR.Application.Common;

namespace BolsaIR.Application.Importers;

public static class ImportErrors
{
	public static readonly Error NotFound =
	new("NotFound", "Nenhum importador encontrado para este PDF.");
}
