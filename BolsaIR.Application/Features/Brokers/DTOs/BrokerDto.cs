namespace BolsaIR.Application.Features.Brokers.DTOs;

public sealed record BrokerDto
{
	public Guid Id { get; init; }

	public string Name { get; init; } = string.Empty;
}
