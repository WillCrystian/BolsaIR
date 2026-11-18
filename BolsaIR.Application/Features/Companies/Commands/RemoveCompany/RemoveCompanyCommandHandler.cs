using BolsaIR.Application.Common;
using BolsaIR.Application.Features.Companies.Services;
using BolsaIR.Domain.Entities;
using BolsaIR.Domain.Interfaces;
using MediatR;

namespace BolsaIR.Application.Features.Companies.Commands.RemoveCompany;

public sealed class RemoveCompanyCommandHandler : IRequestHandler<RemoveCompanyCommand, Result>
{
	private readonly IRepository<Company> _repository;
	private readonly ICompanyReadService _readService;
	private readonly IUnitOfWork _unitOfWork;

	public RemoveCompanyCommandHandler(IRepository<Company> repository, ICompanyReadService readService, IUnitOfWork unitOfWork)
	{
		_repository = repository;
		_readService = readService;
		_unitOfWork = unitOfWork;
	}

	public async Task<Result> Handle(RemoveCompanyCommand request, CancellationToken cancellationToken)
	{
		var company = await _repository.GetByIdAsync(
			request.Id,
			cancellationToken);

		if (company is null)
			return Result.Failure(CompanyErrors.NotFound);

		var hasAssets = await _readService.HasAssetsAsync(request.Id);

		if (hasAssets)
			return Result.Failure(CompanyErrors.HasAssets);

		_repository.Remove(company);

		await _unitOfWork.SaveChangesAsync(cancellationToken);

		return Result.Success();
	}
}