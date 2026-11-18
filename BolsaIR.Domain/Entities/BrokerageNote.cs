using BolsaIR.Domain.Common;

namespace BolsaIR.Domain.Entities;

public class BrokerageNote : EntityBase
{
	private BrokerageNote()
	{
	}

	public BrokerageNote(Broker broker, string noteNumber, DateOnly tradeDate)
	{
		Broker = broker ?? throw new ArgumentNullException(nameof(broker));
		BrokerId = broker.Id;

		if (string.IsNullOrWhiteSpace(noteNumber))
			throw new ArgumentException(nameof(noteNumber));

		NoteNumber = noteNumber.Trim();
		TradeDate = tradeDate;
	}

	public Guid BrokerId { get; private set; }

	public Broker Broker { get; private set; } = null!;

	public string NoteNumber { get; private set; } = string.Empty;

	public DateOnly TradeDate { get; private set; }

	public string? FileName { get; private set; }

	public bool Imported { get; private set; }

	public DateTime? ImportedAt { get; private set; }

	public string? Observation { get; private set; }

	public decimal TotalValue { get; private set; }

	public decimal NetValue { get; private set; }

	public DateOnly? SettlementDate { get; private set; }

	public decimal LiquidValue { get; private set; }

	public decimal BrokerageFee { get; private set; }

	public decimal ExchangeFee { get; private set; }

	public decimal RegistrationFee { get; private set; }

	public decimal SettlementFee { get; private set; }

	public decimal Emoluments { get; private set; }

	public decimal OtherFees { get; private set; }

	public decimal Irrf { get; private set; }

	public decimal TotalFees =>
		BrokerageFee +
		ExchangeFee +
		RegistrationFee +
		SettlementFee +
		Emoluments +
		OtherFees;

	public int OperationsCount => Operations.Count;

	public ICollection<Operation> Operations { get; private set; } =
		new List<Operation>();

	public void UpdateFees(
		decimal brokerageFee,
		decimal exchangeFee,
		decimal registrationFee,
		decimal settlementFee,
		decimal emoluments,
		decimal otherFees)
	{
		if (brokerageFee < 0)
			throw new ArgumentOutOfRangeException(nameof(brokerageFee));

		if (exchangeFee < 0)
			throw new ArgumentOutOfRangeException(nameof(exchangeFee));

		if (registrationFee < 0)
			throw new ArgumentOutOfRangeException(nameof(registrationFee));

		if (settlementFee < 0)
			throw new ArgumentOutOfRangeException(nameof(settlementFee));

		if (emoluments < 0)
			throw new ArgumentOutOfRangeException(nameof(emoluments));

		if (otherFees < 0)
			throw new ArgumentOutOfRangeException(nameof(otherFees));

		BrokerageFee = brokerageFee;
		ExchangeFee = exchangeFee;
		RegistrationFee = registrationFee;
		SettlementFee = settlementFee;
		Emoluments = emoluments;
		OtherFees = otherFees;

		Touch();
	}

	public void UpdateTotals(decimal totalValue, decimal netValue, decimal liquidValue)
	{
		TotalValue = totalValue;
		NetValue = netValue;
		LiquidValue = liquidValue;

		Touch();
	}

	public void SetIrrf(decimal irrf)
	{
		if (irrf < 0)
			throw new ArgumentOutOfRangeException(nameof(irrf));

		Irrf = irrf;

		Touch();
	}

	public void SetImported(string fileName)
	{
		if (Imported)
			throw new InvalidOperationException("Nota já importada.");

		FileName = fileName.Trim();
		Imported = true;
		ImportedAt = DateTime.UtcNow;

		Touch();
	}

	public void AddObservation(string observation)
	{
		if (string.IsNullOrWhiteSpace(observation))
			return;

		Observation = observation.Trim();

		Touch();
	}

	public void AddOperation(Asset asset, OperationData data)
	{
		var operation = new Operation(this, asset, data);

		Operations.Add(operation);

		RecalculateTotals();
	}

	public Operation GetOperation(Guid operationId)
	{
		var operation = Operations.FirstOrDefault(x => x.Id == operationId);

		if (operation is null)
			throw new InvalidOperationException("Operação não encontrada.");

		return operation;
	}

	public void UpdateOperation(Guid operationId, Asset asset, OperationData data)
	{
		var operation = Operations
			.FirstOrDefault(x => x.Id == operationId);

		if (operation is null)
			throw new InvalidOperationException("Operação não encontrada.");

		operation.Update(asset, data);

		Touch();
	}

	public void RemoveOperation(Guid operationId)
	{
		var operation = GetOperation(operationId);

		Operations.Remove(operation);

		RecalculateTotals();
	}

	private void RecalculateTotals()
	{
		TotalValue = Operations.Sum(x => x.GrossValue);

		NetValue = Operations.Sum(x => x.NetValue);

		LiquidValue = NetValue;

		BrokerageFee = Operations.Sum(x => x.BrokerageFee);

		ExchangeFee = Operations.Sum(x => x.ExchangeFee);

		RegistrationFee = Operations.Sum(x => x.RegistrationFee);

		SettlementFee = Operations.Sum(x => x.SettlementFee);

		Emoluments = Operations.Sum(x => x.Emoluments);

		OtherFees = Operations.Sum(x => x.OtherFees);

		Irrf = Operations.Sum(x => x.Irrf);

		SettlementDate = Operations.Count > 0
			? Operations.Max(x => x.SettlementDate)
			: null;

		Touch();
	}
}