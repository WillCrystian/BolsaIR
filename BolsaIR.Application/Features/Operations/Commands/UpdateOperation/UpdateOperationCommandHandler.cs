using BolsaIR.Application.Common;
using BolsaIR.Application.Features.Assets;
using BolsaIR.Application.Features.BrokerageNotes;
using BolsaIR.Domain.Entities;
using BolsaIR.Domain.Interfaces;
using MediatR;

namespace BolsaIR.Application.Features.Operations.Commands.UpdateOperation;

public sealed class UpdateOperationCommandHandler : IRequestHandler<UpdateOperationCommand, Result>
{
	private readonly IRepository<BrokerageNote> _brokerageNoteRepository;
	private readonly IRepository<Asset> _assetRepository;
	private readonly IUnitOfWork _unitOfWork;

	public UpdateOperationCommandHandler(
		IRepository<BrokerageNote> brokerageNoteRepository,
		IRepository<Asset> assetRepository,
		IUnitOfWork unitOfWork)
	{
		_brokerageNoteRepository = brokerageNoteRepository;
		_assetRepository = assetRepository;
		_unitOfWork = unitOfWork;
	}

	public async Task<Result> Handle(UpdateOperationCommand request, CancellationToken cancellationToken)
	{
		var note = await _brokerageNoteRepository.GetByIdAsync(
			request.BrokerageNoteId,
			cancellationToken);

		if (note is null)
			return Result.Failure(BrokerageNoteErrors.NotFound);

		var asset = await _assetRepository.GetByIdAsync(
			request.AssetId,
			cancellationToken);

		if (asset is null)
			return Result.Failure(AssetErrors.NotFound);

		var operationData = new OperationData(
			request.AssetId,
			request.OperationType,
			request.TradeType,
			request.Quantity,
			request.UnitPrice,
			request.BrokerageFee,
			request.ExchangeFee,
			request.RegistrationFee,
			request.SettlementFee,
			request.Emoluments,
			request.OtherFees,
			request.Irrf,
			request.SettlementDate,
			request.Observation);

		note.UpdateOperation(
			request.OperationId,
			asset,
			operationData);

		_brokerageNoteRepository.Update(note);

		await _unitOfWork.SaveChangesAsync(cancellationToken);

		return Result.Success();
	}
}