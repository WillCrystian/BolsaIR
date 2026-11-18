using BolsaIR.Application.Features.TaxCalculation.Results;
using MediatR;

namespace BolsaIR.Application.Features.TaxCalculation.Queries.GetAnnualTaxCalculation;

public sealed record GetAnnualTaxCalculationQuery(
	int Year)
	: IRequest<AnnualTaxResult>;