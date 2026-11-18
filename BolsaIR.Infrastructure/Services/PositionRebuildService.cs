using BolsaIR.Application.Features.Operations.Services;
using BolsaIR.Application.Features.PositionProcessing.Services;
using BolsaIR.Application.Features.Positions.Services;
using BolsaIR.Domain.Entities;
using BolsaIR.Domain.Enums;
using BolsaIR.Domain.Interfaces;

namespace BolsaIR.Infrastructure.Services;

public sealed class PositionRebuildService
	: IPositionRebuildService
{
	public Task RebuildAsync(
		Guid assetId,
		CancellationToken cancellationToken = default)
	{
		throw new NotImplementedException();
	}

	public Task RebuildAllAsync(
		CancellationToken cancellationToken = default)
	{
		throw new NotImplementedException();
	}
}
