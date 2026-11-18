namespace BolsaIR.Application.Features.Companies.DTOs;

public sealed class CompanyDto
{
	public Guid Id { get; init; }

	public string Name { get; init; } = string.Empty;

	public string TradingName { get; init; } = string.Empty;

	public string Cnpj { get; init; } = string.Empty;
}