using BolsaIR.Application.Common;
using BolsaIR.Domain.Entities;
using BolsaIR.Domain.Interfaces;
using MediatR;

namespace BolsaIR.Application.Features.Dividends.Commands.RemoveDividend;

public sealed class RemoveDividendCommandHandler : IRequestHandler<RemoveDividendCommand, Result>
{
	private readonly IRepository<Dividend> _repository;
	private readonly IUnitOfWork _unitOfWork;

	public RemoveDividendCommandHandler(IRepository<Dividend> repository, IUnitOfWork unitOfWork)
	{
		_repository = repository;
		_unitOfWork = unitOfWork;
	}

	public async Task<Result> Handle(RemoveDividendCommand request, CancellationToken cancellationToken)
	{
		var dividend = await _repository.GetByIdAsync(
			request.Id,
			cancellationToken);

		if (dividend is null)
			return Result.Failure(DividendErrors.NotFound);

		_repository.Remove(dividend);

		await _unitOfWork.SaveChangesAsync(cancellationToken);

		return Result.Success();
	}
}