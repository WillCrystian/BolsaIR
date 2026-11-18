using BolsaIR.Application.Common;
using BolsaIR.Application.Features.BrokerageNotes.Factories;
using BolsaIR.Application.Importers.Interfaces;
using BolsaIR.Domain.Entities;
using BolsaIR.Domain.Interfaces;

namespace BolsaIR.Application.Features.BrokerageNotes.Services;

public class ImportBrokerageNoteService : IImportBrokerageNoteService
{
	private readonly IEnumerable<IPdfImporter> _importers;

	private readonly IRepository<BrokerageNote> _noteRepository;
	private readonly IRepository<Asset> _assetRepository;
	private readonly IRepository<Broker> _brokerWriteRepository;

	private readonly IReadRepository<Broker> _brokerRepository;
	private readonly IReadRepository<Asset> _assetReadRepository;
	private readonly IReadRepository<BrokerageNote> _noteReadRepository;

	private readonly IUnitOfWork _unitOfWork;

	public ImportBrokerageNoteService(
		IEnumerable<IPdfImporter> importers,
		IRepository<BrokerageNote> noteRepository,
		IRepository<Asset> assetRepository,
		IRepository<Broker> brokerWriteRepository,
		IReadRepository<Broker> brokerRepository,
		IReadRepository<Asset> assetReadRepository,
		IReadRepository<BrokerageNote> noteReadRepository,
		IUnitOfWork unitOfWork)
	{
		_importers = importers;
		_noteRepository = noteRepository;
		_assetRepository = assetRepository;
		_brokerWriteRepository = brokerWriteRepository;
		_brokerRepository = brokerRepository;
		_assetReadRepository = assetReadRepository;
		_noteReadRepository = noteReadRepository;
		_unitOfWork = unitOfWork;
	}

	public async Task<Result> ImportAsync(
		Stream pdf,
		string fileName,
		CancellationToken cancellationToken = default)
	{
		using var memory = new MemoryStream();

		await pdf.CopyToAsync(memory, cancellationToken);

		var bytes = memory.ToArray();

		//-------------------------------------------------------
		// Descobre qual importador utilizar
		//-------------------------------------------------------

		var importer =
			_importers.FirstOrDefault(x => x.CanRead(bytes));

		if (importer is null)
			return Result.Failure(BrokerageNoteErrors.ImporterNotFound);

		//-------------------------------------------------------
		// Lê o PDF
		//-------------------------------------------------------

		var dto =
			await importer.ImportAsync(bytes, cancellationToken);

		//-------------------------------------------------------
		// Corretora
		//-------------------------------------------------------

		var broker =
			await _brokerRepository.FirstOrDefaultAsync(
				x => x.Name == dto.BrokerName,
				cancellationToken);

		if (broker is null)
		{
			return Result.Failure(
				BrokerageNoteErrors.BrokerNotFound(dto.BrokerName));
		}

		_brokerWriteRepository.Attach(broker);

		//-------------------------------------------------------
		// Nota já importada?
		//-------------------------------------------------------

		var duplicated =
			await _noteReadRepository.AnyAsync(
				x =>
					x.BrokerId == broker.Id &&
					x.NoteNumber == dto.NoteNumber,
				cancellationToken);

		if (duplicated)
		{
			return Result.Failure(BrokerageNoteErrors.BrokerageNoteAlreadyImported(dto.NoteNumber));
		}

		// depois substituiremos por:
		// AnyAsync(x => x.BrokerId == broker.Id &&
		//               x.NoteNumber == dto.NoteNumber)

		//-------------------------------------------------------
		// Cria Nota
		//-------------------------------------------------------

		var note = BrokerageNoteFactory.Create(broker, dto, fileName);

		//-------------------------------------------------------
		// Operações
		//-------------------------------------------------------

		foreach (var item in dto.Operations)
		{
			var asset =
				await _assetReadRepository.FirstOrDefaultAsync(
					x => x.Ticker == item.Ticker,
					cancellationToken);

			if (asset is null)
			{
				asset = AssetFactory.Create(
					item.Ticker,
					item.TradingName,
					item.AssetType);

				await _assetRepository.AddAsync(
					asset,
					cancellationToken);
			}
			else
			{
				_assetRepository.Attach(asset);
			}

			var operationData =
				OperationDataFactory.Create(
					item,
					dto.SettlementDate ?? dto.TradeDate);

			note.AddOperation(
				asset,
				operationData);
		}

		//-------------------------------------------------------
		// Salva
		//-------------------------------------------------------

		await _noteRepository.AddAsync(
			note,
			cancellationToken);

		try
		{
			//Console.WriteLine($"Broker ID: {broker.Id}");
			//Console.WriteLine($"Broker Name: {broker.Name}");

			await _unitOfWork.SaveChangesAsync(cancellationToken);
		}
		catch (Exception ex)
		{
			Console.WriteLine("========== ERRO ==========");
			Console.WriteLine(ex.Message);
			Console.WriteLine("========== INNER ==========");
			Console.WriteLine(ex.InnerException?.Message);
			Console.WriteLine("========== INNER 2 ==========");
			Console.WriteLine(ex.InnerException?.InnerException?.Message);
			Console.WriteLine("===========================");

			throw;
		}

		return Result.Success();
	}
}