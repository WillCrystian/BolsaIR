using BolsaIR.Application.Common;
using BolsaIR.Application.Features.Assets;
using BolsaIR.Application.Features.CorporateActions.Services;
using BolsaIR.Domain.Entities;
using BolsaIR.Domain.Interfaces;
using MediatR;

namespace BolsaIR.Application.Features.CorporateActions.Commands.CreateCorporateAction;

public sealed class CreateCorporateActionCommandHandler
	: IRequestHandler<CreateCorporateActionCommand, Result<Guid>>
{
	private readonly IRepository<CorporateAction> _repository;
	private readonly IRepository<Asset> _assetRepository;
	private readonly ICorporateActionReadService _readService;
	private readonly IUnitOfWork _unitOfWork;

	public CreateCorporateActionCommandHandler(IRepository<CorporateAction> repository, IRepository<Asset> assetRepository,
		ICorporateActionReadService readService, IUnitOfWork unitOfWork)
	{
		_repository = repository;
		_assetRepository = assetRepository;
		_readService = readService;
		_unitOfWork = unitOfWork;
	}

	public async Task<Result<Guid>> Handle(CreateCorporateActionCommand request, CancellationToken cancellationToken)
	{
		var asset = await _assetRepository.GetByIdAsync(
			request.AssetId,
			cancellationToken);

		if (asset is null)
			return Result<Guid>.Failure(AssetErrors.NotFound);

		var exists = await _readService.ExistsAsync(
			request.AssetId,
			request.Type,
			request.EffectiveDate);

		if (exists)
			return Result<Guid>.Failure(CorporateActionErrors.AlreadyExists);

		var corporateAction = new CorporateAction(
			asset,
			request.Type,
			request.ApprovedDate,
			request.EffectiveDate,
			request.Factor,
			request.Description,
			request.ExternalId);

		await _repository.AddAsync(
			corporateAction,
			cancellationToken);

		await _unitOfWork.SaveChangesAsync(cancellationToken);

		return Result<Guid>.Success(corporateAction.Id);
	}
}