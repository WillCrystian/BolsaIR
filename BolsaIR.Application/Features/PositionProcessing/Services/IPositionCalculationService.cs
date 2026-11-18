using BolsaIR.Domain.Entities;

namespace BolsaIR.Application.Features.PositionProcessing.Services;

public interface IPositionCalculationService
{
	void ApplyOperation(
		Position position,
		Operation operation);

	void ApplyCorporateAction(
		Position position,
		CorporateAction corporateAction);
}