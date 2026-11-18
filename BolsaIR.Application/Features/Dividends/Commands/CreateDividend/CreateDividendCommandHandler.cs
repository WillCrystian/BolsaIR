using BolsaIR.Application.Common;
using BolsaIR.Application.Features.Assets;
using BolsaIR.Application.Features.Dividends.Services;
using BolsaIR.Domain.Entities;
using BolsaIR.Domain.Interfaces;
using MediatR;

namespace BolsaIR.Application.Features.Dividends.Commands.CreateDividend;

public sealed class CreateDividendCommandHandler : IRequestHandler<CreateDividendCommand, Result<Guid>>
{
	private readonly IRepository<Dividend> _repository;
	private readonly IRepository<Asset> _assetRepository;
	private readonly IDividendReadService _readService;
	private readonly IUnitOfWork _unitOfWork;

	public CreateDividendCommandHandler(
		IRepository<Dividend> repository, IRepository<Asset> assetRepository,
		IDividendReadService readService, IUnitOfWork unitOfWork)
	{
		_repository = repository;
		_assetRepository = assetRepository;
		_readService = readService;
		_unitOfWork = unitOfWork;
	}

	public async Task<Result<Guid>> Handle(CreateDividendCommand request, CancellationToken cancellationToken)
	{
		var asset = await _assetRepository.GetByIdAsync(
			request.AssetId,
			cancellationToken);

		if (asset is null)
			return Result<Guid>.Failure(AssetErrors.NotFound);

		var exists = await _readService.ExistsAsync(
			request.AssetId,
			request.Type,
			request.ExDate);

		if (exists)
			return Result<Guid>.Failure(DividendErrors.AlreadyExists);

		var dividend = new Dividend(
			asset,
			request.Type,
			request.ExDate,
			request.PaymentDate,
			request.ValuePerShare,
			request.Description,
			request.ExternalId);

		await _repository.AddAsync(
			dividend,
			cancellationToken);

		await _unitOfWork.SaveChangesAsync(cancellationToken);

		return Result<Guid>.Success(dividend.Id);
	}
}