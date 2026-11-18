using BolsaIR.Application.Features.TaxCalculation.Results;
using BolsaIR.Application.Features.TaxCalculation.Services;
using MediatR;

namespace BolsaIR.Application.Features.TaxCalculation.Queries.GetAnnualTaxCalculation;

public sealed class GetAnnualTaxCalculationHandler
	: IRequestHandler<GetAnnualTaxCalculationQuery, AnnualTaxResult>
{
	private readonly ITaxCalculationQueryService _queryService;

	public GetAnnualTaxCalculationHandler(
		ITaxCalculationQueryService queryService)
	{
		_queryService = queryService;
	}

	public async Task<AnnualTaxResult> Handle(
		GetAnnualTaxCalculationQuery request,
		CancellationToken cancellationToken)
	{
		return await _queryService.GetAnnualCalculationAsync(
			request.Year,
			cancellationToken);
	}
}