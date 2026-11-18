namespace BolsaIR.Application.Features.Operations.DTOs;

public sealed class OperationDto
{
	public Guid Id { get; init; }

	public Guid BrokerageNoteId { get; init; }

	public Guid AssetId { get; init; }

	public string AssetTicker { get; init; } = string.Empty;

	public string AssetName { get; init; } = string.Empty;
}