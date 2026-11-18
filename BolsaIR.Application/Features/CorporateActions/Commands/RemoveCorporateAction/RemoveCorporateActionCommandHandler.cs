using BolsaIR.Application.Common;
using BolsaIR.Application.Features.CorporateActions.Services;
using BolsaIR.Domain.Entities;
using BolsaIR.Domain.Interfaces;
using MediatR;

namespace BolsaIR.Application.Features.CorporateActions.Commands.RemoveCorporateAction;

public sealed class RemoveCorporateActionCommandHandler : IRequestHandler<RemoveCorporateActionCommand, Result>
{
	private readonly IRepository<CorporateAction> _repository;
	private readonly ICorporateActionReadService _readService;
	private readonly IUnitOfWork _unitOfWork;

	public RemoveCorporateActionCommandHandler(IRepository<CorporateAction> repository, ICorporateActionReadService readService, IUnitOfWork unitOfWork)
	{
		_repository = repository;
		_readService = readService;
		_unitOfWork = unitOfWork;
	}

	public async Task<Result> Handle(RemoveCorporateActionCommand request, CancellationToken cancellationToken)
	{
		var corporateAction = await _repository.GetByIdAsync(
			request.Id,
			cancellationToken);

		if (corporateAction is null)
			return Result.Failure(CorporateActionErrors.NotFound);

		_repository.Remove(corporateAction);

		await _unitOfWork.SaveChangesAsync(cancellationToken);

		return Result.Success();
	}
}