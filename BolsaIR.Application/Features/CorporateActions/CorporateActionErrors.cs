using BolsaIR.Application.Common;

namespace BolsaIR.Application.Features.CorporateActions;

public static class CorporateActionErrors
{
	public static readonly Error NotFound =
		new(
			"CorporateAction.NotFound",
			"Ação corporativa não encontrada.");

	public static readonly Error AssetNotFound =
		new(
			"CorporateAction.AssetNotFound",
			"Ativo não encontrado.");

	public static readonly Error AlreadyExists =
		new(
			"CorporateAction.AlreadyExists",
			"Já existe uma ação corporativa cadastrada para este ativo nesta data.");
}