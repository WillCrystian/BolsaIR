namespace BolsaIR.Application.Features.Brokers.DTOs;

public sealed record BrokerListDto
{
	public Guid Id { get; init; }

	public string Name { get; init; } = string.Empty;

	public string? Cnpj { get; init; }

	public bool IsActive { get; init; }
}
