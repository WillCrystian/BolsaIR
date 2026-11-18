namespace BolsaIR.Application.Features.Brokers.DTOs;

public sealed class BrokerDetailsDto
{
	public Guid Id { get; init; }

	public string Name { get; init; } = string.Empty;

	public string? Cnpj { get; init; }

	public string? Website { get; init; }

	public string? ImporterName { get; init; }

	public bool IsActive { get; init; }
}