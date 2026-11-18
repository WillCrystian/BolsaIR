using BolsaIR.Application.Features.Operations.Services;
using BolsaIR.Application.Features.TaxCalculation.Models;
using BolsaIR.Application.Features.TaxCalculation.Services;

namespace BolsaIR.Infrastructure.Services;

public sealed class TaxCalculationDataProvider : ITaxCalculationDataProvider
{
	private readonly IOperationReadService _operationReadService;

	public TaxCalculationDataProvider(IOperationReadService operationReadService)
	{
		_operationReadService = operationReadService;
	}

	public async Task<YearOperationsGroup> GetYearAsync(
		int year,
		CancellationToken cancellationToken = default)
	{
		var operations =
			await _operationReadService.GetAllForTaxCalculationAsync(
				year,
				cancellationToken);

		var result = new YearOperationsGroup
		{
			Year = year
		};

		var months = operations
			.GroupBy(x => x.SettlementDate.Month)
			.OrderBy(x => x.Key);

		foreach (var month in months)
		{
			result.Months.Add(new MonthOperationsGroup
			{
				Year = year,

				Month = month.Key,

				Operations = month
					.OrderBy(x => x.SettlementDate)
					.ToList()
			});
		}

		return result;
	}
}