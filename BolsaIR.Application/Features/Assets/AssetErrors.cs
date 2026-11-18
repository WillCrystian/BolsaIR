using BolsaIR.Application.Common;

namespace BolsaIR.Application.Features.Assets;

public static class AssetErrors
{
	public static readonly Error NotFound =
		new("Asset.NotFound", "Ativo não encontrado.");

	public static readonly Error AlreadyExists =
		new("Asset.AlreadyExists", "Já existe um ativo com esse ticker.");

	public static readonly Error HasOperations =
	new("Asset.HasOperations", "O ativo possui operações cadastradas.");

	public static readonly Error HasPositions =
		new("Asset.HasPositions", "O ativo possui posições cadastradas.");

	public static readonly Error HasQuotes =
		new("Asset.HasQuotes", "O ativo possui cotações cadastradas.");

	public static readonly Error HasDividends =
		new("Asset.HasDividends", "O ativo possui dividendos cadastrados.");

	public static readonly Error HasCorporateActions =
		new("Asset.HasCorporateActions", "O ativo possui eventos corporativos cadastrados.");
}