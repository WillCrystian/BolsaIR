using BolsaIR.Application.Common;
using BolsaIR.Domain.Entities;
using BolsaIR.Domain.Interfaces;
using MediatR;

namespace BolsaIR.Application.Features.Assets.Commands.ActivateAsset;

public sealed class ActivateAssetCommandHandler : IRequestHandler<ActivateAssetCommand, Result>
{
	private readonly IRepository<Asset> _repository;
	private readonly IUnitOfWork _unitOfWork;

	public ActivateAssetCommandHandler(
		IRepository<Asset> repository,
		IUnitOfWork unitOfWork)
	{
		_repository = repository;
		_unitOfWork = unitOfWork;
	}

	public async Task<Result> Handle(
		ActivateAssetCommand request,
		CancellationToken cancellationToken)
	{
		var asset = await _repository.GetByIdAsync(
			request.Id,
			cancellationToken);

		if (asset is null)
			return Result.Failure(AssetErrors.NotFound);

		asset.Activate();

		_repository.Update(asset);

		await _unitOfWork.SaveChangesAsync(cancellationToken);

		return Result.Success();
	}
}