namespace BolsaIR.Application.Features.Companies.DTOs;

public sealed class CompanyListDto
{
	public Guid Id { get; init; }

	public string Name { get; init; } = string.Empty;

	public string TradingName { get; init; } = string.Empty;

	public bool IsActive { get; init; }
}