using BolsaIR.Application.Features.TaxCalculation.Models;
using BolsaIR.Application.Features.TaxCalculation.Results;

namespace BolsaIR.Application.Features.TaxCalculation.Services;

public interface IMonthlyProcessor
{
	Task<MonthlyTaxResult> ProcessAsync(
		MonthOperationsGroup month,
		Dictionary<Guid, PositionSnapshot> positions,
		CancellationToken cancellationToken = default);
}