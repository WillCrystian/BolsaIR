using BolsaIR.Application.Common;
using BolsaIR.Domain.Entities;
using BolsaIR.Domain.Interfaces;
using MediatR;

namespace BolsaIR.Application.Features.Companies.Commands.InactivateCompany;

public sealed class InactivateCompanyCommandHandler : IRequestHandler<InactivateCompanyCommand, Result>
{
	private readonly IRepository<Company> _repository;
	private readonly IUnitOfWork _unitOfWork;

	public InactivateCompanyCommandHandler(IRepository<Company> repository, IUnitOfWork unitOfWork)
	{
		_repository = repository;
		_unitOfWork = unitOfWork;
	}

	public async Task<Result> Handle(InactivateCompanyCommand request, CancellationToken cancellationToken)
	{
		var company = await _repository.GetByIdAsync(
			request.Id,
			cancellationToken);

		if (company is null)
			return Result.Failure(CompanyErrors.NotFound);

		company.Inactivate();

		_repository.Update(company);

		await _unitOfWork.SaveChangesAsync(cancellationToken);

		return Result.Success();
	}
}