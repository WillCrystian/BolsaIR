using BolsaIR.Application.Features.TaxCalculation.DTOs;
using BolsaIR.Application.Features.TaxCalculation.Models;
using BolsaIR.Application.Features.TaxCalculation.Services;

namespace BolsaIR.Infrastructure.Services.TaxCalculation;

public sealed class PositionSnapshotService : IPositionSnapshotService
{
	public PositionSnapshot GetOrCreate(
		Dictionary<Guid, PositionSnapshot> positions,
		OperationForTaxCalculation operation)
	{
		if (positions.TryGetValue(operation.AssetId, out var snapshot))
			return snapshot;

		snapshot = new PositionSnapshot
		{
			AssetId = operation.AssetId
		};

		positions.Add(operation.AssetId, snapshot);

		return snapshot;
	}
}