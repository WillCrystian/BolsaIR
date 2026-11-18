using BolsaIR.Application.Common;
using BolsaIR.Domain.Entities;
using BolsaIR.Domain.Interfaces;
using MediatR;

namespace BolsaIR.Application.Features.Assets.Commands.InactivateAsset;

public sealed class InactivateAssetCommandHandler : IRequestHandler<InactivateAssetCommand, Result>
{
	private readonly IRepository<Asset> _repository;
	private readonly IUnitOfWork _unitOfWork;

	public InactivateAssetCommandHandler(
		IRepository<Asset> repository,
		IUnitOfWork unitOfWork)
	{
		_repository = repository;
		_unitOfWork = unitOfWork;
	}

	public async Task<Result> Handle(
		InactivateAssetCommand request,
		CancellationToken cancellationToken)
	{
		var asset = await _repository.GetByIdAsync(
			request.Id,
			cancellationToken);

		if (asset is null)
			return Result.Failure(AssetErrors.NotFound);

		asset.Inactivate();

		_repository.Update(asset);

		await _unitOfWork.SaveChangesAsync(cancellationToken);

		return Result.Success();
	}
}