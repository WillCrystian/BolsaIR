using BolsaIR.Application.Common;
using MediatR;

namespace BolsaIR.Application.Features.Companies.Commands.UpdateCompany;

public sealed class UpdateCompanyCommand : IRequest<Result>
{
	public Guid Id { get; init; }

	public string Name { get; init; } = string.Empty;

	public string TradingName { get; init; } = string.Empty;

	public string Cnpj { get; init; } = string.Empty;

	public string? Sector { get; init; }

	public string? Segment { get; init; }

	public string? Website { get; init; }
}