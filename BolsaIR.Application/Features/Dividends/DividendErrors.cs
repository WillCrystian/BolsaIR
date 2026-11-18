using BolsaIR.Application.Common;

namespace BolsaIR.Application.Features.Dividends;

public static class DividendErrors
{
	public static readonly Error NotFound =
		new("Dividend.NotFound", "Dividendo não encontrado.");

	public static readonly Error AlreadyExists =
		new("Dividend.AlreadyExists", "Já existe um dividendo para este ativo nesta data EX.");

	public static readonly Error AssetNotFound =
		new("Dividend.AssetNotFound", "Ativo não encontrado.");
}