namespace BolsaIR.Application.Features.Companies.DTOs;

public sealed class CompanyDetailsDto
{
	public Guid Id { get; init; }

	public string Name { get; init; } = string.Empty;

	public string TradingName { get; init; } = string.Empty;

	public string Cnpj { get; init; } = string.Empty;

	public string? Sector { get; init; }

	public string? Segment { get; init; }

	public string? Website { get; init; }

	public bool IsActive { get; init; }
}