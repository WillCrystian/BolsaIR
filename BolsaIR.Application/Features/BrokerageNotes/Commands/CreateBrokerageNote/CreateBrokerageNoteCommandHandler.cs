using BolsaIR.Application.Common;
using BolsaIR.Application.Features.Assets;
using BolsaIR.Application.Features.Brokers;
using BolsaIR.Domain.Entities;
using BolsaIR.Domain.Interfaces;
using MediatR;

namespace BolsaIR.Application.Features.BrokerageNotes.Commands.CreateBrokerageNote;

public sealed class CreateBrokerageNoteCommandHandler	: IRequestHandler<CreateBrokerageNoteCommand, Result<Guid>>
{
	private readonly IRepository<BrokerageNote> _brokerageNoteRepository;
	private readonly IRepository<Broker> _brokerRepository;
	private readonly IRepository<Asset> _assetRepository;
	private readonly IUnitOfWork _unitOfWork;

	public CreateBrokerageNoteCommandHandler(
		IRepository<BrokerageNote> brokerageNoteRepository,
		IRepository<Broker> brokerRepository,
		IRepository<Asset> assetRepository,
		IUnitOfWork unitOfWork)
	{
		_brokerageNoteRepository = brokerageNoteRepository;
		_brokerRepository = brokerRepository;
		_assetRepository = assetRepository;
		_unitOfWork = unitOfWork;
	}

	public async Task<Result<Guid>> Handle(
		CreateBrokerageNoteCommand request,
		CancellationToken cancellationToken)
	{
		var broker = await _brokerRepository.GetByIdAsync(
			request.BrokerId,
			cancellationToken);

		if (broker is null)
			return Result<Guid>.Failure(BrokerErrors.NotFound);

		var note = new BrokerageNote(
			broker,
			request.NoteNumber,
			request.TradeDate);

		note.UpdateFees(
			request.BrokerageFee,
			request.ExchangeFee,
			request.RegistrationFee,
			request.SettlementFee,
			request.Emoluments,
			request.OtherFees);

		note.UpdateTotals(
			request.TotalValue,
			request.NetValue,
			request.LiquidValue);

		note.SetIrrf(request.Irrf);

		if (!string.IsNullOrWhiteSpace(request.Observation))
			note.AddObservation(request.Observation);

		foreach (var operationData in request.Operations)
		{
			var asset = await _assetRepository.GetByIdAsync(
				operationData.AssetId,
				cancellationToken);

			if (asset is null)
				return Result<Guid>.Failure(AssetErrors.NotFound);

			note.AddOperation(asset, operationData);
		}

		await _brokerageNoteRepository.AddAsync(
			note,
			cancellationToken);

		await _unitOfWork.SaveChangesAsync(cancellationToken);

		return Result<Guid>.Success(note.Id);
	}
}