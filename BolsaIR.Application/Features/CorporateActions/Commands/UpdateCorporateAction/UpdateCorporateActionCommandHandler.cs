using BolsaIR.Application.Common;
using BolsaIR.Domain.Entities;
using BolsaIR.Domain.Interfaces;
using MediatR;

namespace BolsaIR.Application.Features.CorporateActions.Commands.UpdateCorporateAction;

public sealed class UpdateCorporateActionCommandHandler : IRequestHandler<UpdateCorporateActionCommand, Result>
{
	private readonly IRepository<CorporateAction> _repository;
	private readonly IUnitOfWork _unitOfWork;

	public UpdateCorporateActionCommandHandler(IRepository<CorporateAction> repository, IUnitOfWork unitOfWork)
	{
		_repository = repository;
		_unitOfWork = unitOfWork;
	}

	public async Task<Result> Handle(UpdateCorporateActionCommand request, CancellationToken cancellationToken)
	{
		var corporateAction = await _repository.GetByIdAsync(
			request.Id,
			cancellationToken);

		if (corporateAction is null)
			return Result.Failure(CorporateActionErrors.NotFound);

		corporateAction.Update(
			request.Type,
			request.ApprovedDate,
			request.EffectiveDate,
			request.Factor,
			request.Description);

		await _unitOfWork.SaveChangesAsync(cancellationToken);

		return Result.Success();
	}
}