using BolsaIR.Application.Features.BrokerageNotes.DTOs;

namespace BolsaIR.Infrastructure.Importers.BTG;

internal sealed class BtgFeeAllocator
{
	public void Allocate(BtgImportContext context)
	{
		ArgumentNullException.ThrowIfNull(context);

		var note = context.Note;

		if (note.Operations.Count == 0)
			return;

		var totalGrossValue =
			note.Operations.Sum(x => x.GrossValue);

		if (totalGrossValue <= 0)
			return;

		foreach (var operation in note.Operations)
		{
			var percentage =
				operation.GrossValue / totalGrossValue;

			operation.BrokerageFee =
				Round(note.BrokerageFee * percentage);

			operation.ExchangeFee =
				Round(note.ExchangeFee * percentage);

			operation.RegistrationFee =
				Round(note.RegistrationFee * percentage);

			operation.SettlementFee =
				Round(note.SettlementFee * percentage);

			operation.Emoluments =
				Round(note.Emoluments * percentage);

			operation.OtherFees =
				Round(note.OtherFees * percentage);

			operation.Irrf =
				Round(note.Irrf * percentage);
		}

		AdjustRounding(note);
	}

	private static decimal Round(decimal value)
	{
		return Math.Round(
			value,
			2,
			MidpointRounding.AwayFromZero);
	}

	private static void AdjustRounding(
		ImportBrokerageNoteDto note)
	{
		Adjust(
			note.Operations,
			note.BrokerageFee,
			x => x.BrokerageFee,
			(x, value) => x.BrokerageFee = value);

		Adjust(
			note.Operations,
			note.ExchangeFee,
			x => x.ExchangeFee,
			(x, value) => x.ExchangeFee = value);

		Adjust(
			note.Operations,
			note.RegistrationFee,
			x => x.RegistrationFee,
			(x, value) => x.RegistrationFee = value);

		Adjust(
			note.Operations,
			note.SettlementFee,
			x => x.SettlementFee,
			(x, value) => x.SettlementFee = value);

		Adjust(
			note.Operations,
			note.Emoluments,
			x => x.Emoluments,
			(x, value) => x.Emoluments = value);

		Adjust(
			note.Operations,
			note.OtherFees,
			x => x.OtherFees,
			(x, value) => x.OtherFees = value);

		Adjust(
			note.Operations,
			note.Irrf,
			x => x.Irrf,
			(x, value) => x.Irrf = value);
	}

	private static void Adjust(
		IList<ImportOperationDto> operations,
		decimal total,
		Func<ImportOperationDto, decimal> selector,
		Action<ImportOperationDto, decimal> setter)
	{
		if (operations.Count == 0)
			return;

		var current =
			operations.Sum(selector);

		var difference =
			total - current;

		if (difference == 0)
			return;

		var operation =
			operations
				.OrderByDescending(x => x.GrossValue)
				.First();

		setter(
			operation,
			selector(operation) + difference);
	}
}