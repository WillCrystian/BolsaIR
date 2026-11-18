using BolsaIR.Application.Common;
using BolsaIR.Application.Features.Companies.Services;
using BolsaIR.Domain.Entities;
using BolsaIR.Domain.Interfaces;
using MediatR;

namespace BolsaIR.Application.Features.Companies.Commands.UpdateCompany;

public sealed class UpdateCompanyCommandHandler
	: IRequestHandler<UpdateCompanyCommand, Result>
{
	private readonly IRepository<Company> _repository;
	private readonly ICompanyReadService _readService;
	private readonly IUnitOfWork _unitOfWork;

	public UpdateCompanyCommandHandler(IRepository<Company> repository, ICompanyReadService readService, IUnitOfWork unitOfWork)
	{
		_repository = repository;
		_readService = readService;
		_unitOfWork = unitOfWork;
	}

	public async Task<Result> Handle(UpdateCompanyCommand request, CancellationToken cancellationToken)
	{
		var company = await _repository.GetByIdAsync(
			request.Id,
			cancellationToken);

		if (company is null)
			return Result.Failure(CompanyErrors.NotFound);

		var normalizedCnpj = request.Cnpj
			.Replace(".", "")
			.Replace("/", "")
			.Replace("-", "")
			.Trim();

		var exists = await _readService.ExistsAsync(normalizedCnpj);

		if (exists && normalizedCnpj != company.Cnpj)
			return Result.Failure(CompanyErrors.AlreadyExists);

		company.Update(
			request.Name,
			request.TradingName,
			request.Cnpj,
			request.Sector,
			request.Segment,
			request.Website);

		_repository.Update(company);

		await _unitOfWork.SaveChangesAsync(cancellationToken);

		return Result.Success();
	}
}