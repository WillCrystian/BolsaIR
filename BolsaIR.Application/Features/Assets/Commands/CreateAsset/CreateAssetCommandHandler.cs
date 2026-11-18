using BolsaIR.Application.Common;
using BolsaIR.Application.Features.Assets.Services;
using BolsaIR.Domain.Entities;
using BolsaIR.Domain.Interfaces;
using MediatR;

namespace BolsaIR.Application.Features.Assets.Commands.CreateAsset;

public sealed class CreateAssetCommandHandler : IRequestHandler<CreateAssetCommand, Result<Guid>>
{
	private readonly IRepository<Asset> _repository;
	private readonly IAssetReadService _readService;
	private readonly IUnitOfWork _unitOfWork;

	public CreateAssetCommandHandler(IRepository<Asset> repository, IAssetReadService readService, IUnitOfWork unitOfWork)
	{
		_repository = repository;
		_readService = readService;
		_unitOfWork = unitOfWork;
	}

	public async Task<Result<Guid>> Handle(
		CreateAssetCommand request,
		CancellationToken cancellationToken)
	{
		var exists = await _readService.ExistsByTickerAsync(request.Ticker);

		if (exists)
			return Result<Guid>.Failure(AssetErrors.AlreadyExists);

		var asset = new Asset(
			request.Ticker,
			request.TradingName,
			request.AssetType);

		asset.Update(
			request.TradingName,
			request.CompanyName,
			request.Cnpj,
			request.Isin,
			request.AssetType,
			request.Sector,
			request.Segment);

		await _repository.AddAsync(
			asset,
			cancellationToken);

		await _unitOfWork.SaveChangesAsync(
			cancellationToken);

		return Result<Guid>.Success(asset.Id);
	}
}