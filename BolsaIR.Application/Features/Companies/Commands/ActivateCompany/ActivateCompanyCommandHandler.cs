using BolsaIR.Application.Common;
using BolsaIR.Domain.Entities;
using BolsaIR.Domain.Interfaces;
using MediatR;

namespace BolsaIR.Application.Features.Companies.Commands.ActivateCompany;

public sealed class ActivateCompanyCommandHandler : IRequestHandler<ActivateCompanyCommand, Result>
{
	private readonly IRepository<Company> _repository;
	private readonly IUnitOfWork _unitOfWork;

	public ActivateCompanyCommandHandler(IRepository<Company> repository, IUnitOfWork unitOfWork)
	{
		_repository = repository;
		_unitOfWork = unitOfWork;
	}

	public async Task<Result> Handle(ActivateCompanyCommand request, CancellationToken cancellationToken)
	{
		var company = await _repository.GetByIdAsync(
			request.Id,
			cancellationToken);

		if (company is null)
			return Result.Failure(CompanyErrors.NotFound);

		company.Activate();

		_repository.Update(company);

		await _unitOfWork.SaveChangesAsync(cancellationToken);

		return Result.Success();
	}
}