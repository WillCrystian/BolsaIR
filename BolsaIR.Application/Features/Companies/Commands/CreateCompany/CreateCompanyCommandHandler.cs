using BolsaIR.Application.Common;
using BolsaIR.Application.Features.Companies.Services;
using BolsaIR.Domain.Entities;
using BolsaIR.Domain.Interfaces;
using MediatR;

namespace BolsaIR.Application.Features.Companies.Commands.CreateCompany;

public sealed class CreateCompanyCommandHandler : IRequestHandler<CreateCompanyCommand, Result<Guid>>
{
	private readonly IRepository<Company> _repository;
	private readonly ICompanyReadService _readService;
	private readonly IUnitOfWork _unitOfWork;

	public CreateCompanyCommandHandler(IRepository<Company> repository, ICompanyReadService readService, IUnitOfWork unitOfWork)
	{
		_repository = repository;
		_readService = readService;
		_unitOfWork = unitOfWork;
	}

	public async Task<Result<Guid>> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
	{
		if (await _readService.ExistsAsync(request.Cnpj))
			return Result<Guid>.Failure(CompanyErrors.AlreadyExists);

		var company = new Company(
			request.Name,
			request.TradingName,
			request.Cnpj);

		company.Update(
			request.Name,
			request.TradingName,
			request.Cnpj,
			request.Sector,
			request.Segment,
			request.Website);

		await _repository.AddAsync(
			company,
			cancellationToken);

		await _unitOfWork.SaveChangesAsync(
			cancellationToken);

		return Result<Guid>.Success(company.Id);
	}
}