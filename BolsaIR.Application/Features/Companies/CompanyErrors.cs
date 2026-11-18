using BolsaIR.Application.Common;

namespace BolsaIR.Application.Features.Companies;

public static class CompanyErrors
{
	public static readonly Error NotFound =
		new("Company.NotFound", "Empresa não encontrada.");

	public static readonly Error AlreadyExists =
		new("Company.AlreadyExists", "Já existe uma empresa cadastrada com este CNPJ.");

	public static readonly Error HasAssets =
		new("Company.HasAssets", "A empresa possui ativos vinculados e não pode ser removida.");
}