using BolsaIR.Application.Common;
using BolsaIR.Application.Features.Assets.Services;
using BolsaIR.Domain.Entities;
using BolsaIR.Domain.Interfaces;
using MediatR;

namespace BolsaIR.Application.Features.Assets.Commands.RemoveAsset;

public sealed class RemoveAssetCommandHandler : IRequestHandler<RemoveAssetCommand, Result>
{
	private readonly IRepository<Asset> _repository;
	private readonly IAssetReadService _readService;
	private readonly IUnitOfWork _unitOfWork;

	public RemoveAssetCommandHandler(
		IRepository<Asset> repository,
		IAssetReadService readService,
		IUnitOfWork unitOfWork)
	{
		_repository = repository;
		_readService = readService;
		_unitOfWork = unitOfWork;
	}

	public async Task<Result> Handle(
		RemoveAssetCommand request,
		CancellationToken cancellationToken)
	{
		var asset = await _repository.GetByIdAsync(
			request.Id,
			cancellationToken);

		if (asset is null)
			return Result.Failure(AssetErrors.NotFound);

		if (await _readService.HasOperationsAsync(request.Id))
			return Result.Failure(AssetErrors.HasOperations);

		if (await _readService.HasPositionsAsync(request.Id))
			return Result.Failure(AssetErrors.HasPositions);

		if (await _readService.HasQuotesAsync(request.Id))
			return Result.Failure(AssetErrors.HasQuotes);

		if (await _readService.HasDividendsAsync(request.Id))
			return Result.Failure(AssetErrors.HasDividends);

		if (await _readService.HasCorporateActionsAsync(request.Id))
			return Result.Failure(AssetErrors.HasCorporateActions);

		_repository.Remove(asset);

		await _unitOfWork.SaveChangesAsync(cancellationToken);

		return Result.Success();
	}
}