using BolsaIR.Application.Common;
using BolsaIR.Application.Features.Assets.Services;
using BolsaIR.Domain.Entities;
using BolsaIR.Domain.Interfaces;
using MediatR;

namespace BolsaIR.Application.Features.Assets.Commands.UpdateAsset;

public sealed class UpdateAssetCommandHandler : IRequestHandler<UpdateAssetCommand, Result>
{
	private readonly IRepository<Asset> _repository;
	private readonly IAssetReadService _readService;
	private readonly IUnitOfWork _unitOfWork;

	public UpdateAssetCommandHandler(
		IRepository<Asset> repository,
		IAssetReadService readService,
		IUnitOfWork unitOfWork)
	{
		_repository = repository;
		_readService = readService;
		_unitOfWork = unitOfWork;
	}

	public async Task<Result> Handle(
		UpdateAssetCommand request,
		CancellationToken cancellationToken)
	{
		var asset = await _repository.GetByIdAsync(
			request.Id,
			cancellationToken);

		if (asset is null)
			return Result.Failure(AssetErrors.NotFound);

		asset.Update(
			request.TradingName,
			request.CompanyName,
			request.Cnpj,
			request.Isin,
			request.AssetType,
			request.Sector,
			request.Segment);

		_repository.Update(asset);

		await _unitOfWork.SaveChangesAsync(cancellationToken);

		return Result.Success();
	}
}