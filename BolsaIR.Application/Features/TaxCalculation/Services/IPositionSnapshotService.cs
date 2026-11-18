using BolsaIR.Application.Features.TaxCalculation.DTOs;
using BolsaIR.Application.Features.TaxCalculation.Models;

namespace BolsaIR.Application.Features.TaxCalculation.Services;

public interface IPositionSnapshotService
{
	PositionSnapshot GetOrCreate(
		Dictionary<Guid, PositionSnapshot> positions,
		OperationForTaxCalculation operation);
}