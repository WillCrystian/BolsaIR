using BolsaIR.Application.Features.Operations.DTOs;
using BolsaIR.Application.Features.TaxCalculation.DTOs;
using BolsaIR.Domain.Entities;

namespace BolsaIR.Application.Features.Operations.Services;

public interface IOperationReadService
{
	Task<List<Operation>> GetAllForPositionCalculationAsync(CancellationToken cancellationToken = default);

	Task<OperationDetailsDto?> GetByIdAsync(Guid id);

	Task<List<OperationListDto>> GetListAsync();

	Task<bool> ExistsAsync(Guid id);

	Task<List<OperationListDto>> GetByBrokerageNoteAsync(Guid brokerageNoteId);

	Task<List<OperationListDto>> GetByAssetAsync(Guid assetId);

	Task<List<OperationForTaxCalculation>>	GetAllForTaxCalculationAsync(
		int year,
		CancellationToken cancellationToken = default);
}