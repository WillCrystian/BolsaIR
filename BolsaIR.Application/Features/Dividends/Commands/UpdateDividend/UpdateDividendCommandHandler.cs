using BolsaIR.Application.Common;
using BolsaIR.Application.Features.Dividends.Services;
using BolsaIR.Domain.Entities;
using BolsaIR.Domain.Interfaces;
using MediatR;

namespace BolsaIR.Application.Features.Dividends.Commands.UpdateDividend;

public sealed class UpdateDividendCommandHandler : IRequestHandler<UpdateDividendCommand, Result>
{
	private readonly IRepository<Dividend> _repository;
	private readonly IDividendReadService _readService;
	private readonly IUnitOfWork _unitOfWork;

	public UpdateDividendCommandHandler(IRepository<Dividend> repository, IDividendReadService readService, IUnitOfWork unitOfWork)
	{
		_repository = repository;
		_readService = readService;
		_unitOfWork = unitOfWork;
	}

	public async Task<Result> Handle(UpdateDividendCommand request, CancellationToken cancellationToken)
	{
		var dividend = await _repository.GetByIdAsync(
			request.Id,
			cancellationToken);

		if (dividend is null)
			return Result.Failure(DividendErrors.NotFound);

		var exists = await _readService.ExistsAsync(
			dividend.AssetId,
			request.Type,
			request.ExDate,
			request.Id);

		if (exists)
			return Result.Failure(DividendErrors.AlreadyExists);

		dividend.Update(
			request.Type,
			request.ExDate,
			request.PaymentDate,
			request.ValuePerShare,
			request.Description);

		_repository.Update(dividend);

		await _unitOfWork.SaveChangesAsync(cancellationToken);

		return Result.Success();
	}
}