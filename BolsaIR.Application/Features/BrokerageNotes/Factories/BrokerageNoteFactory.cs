using BolsaIR.Application.Features.BrokerageNotes.DTOs;
using BolsaIR.Domain.Entities;

namespace BolsaIR.Application.Features.BrokerageNotes.Factories;

public static class BrokerageNoteFactory
{
	public static BrokerageNote Create(
		Broker broker,
		ImportBrokerageNoteDto dto,
		string fileName)
	{
		var note = new BrokerageNote(
			broker,
			dto.NoteNumber,
			dto.TradeDate);

		note.UpdateTotals(
			dto.TotalValue,
			dto.NetValue,
			dto.LiquidValue);

		note.UpdateFees(
			dto.BrokerageFee,
			dto.ExchangeFee,
			dto.RegistrationFee,
			dto.SettlementFee,
			dto.Emoluments,
			dto.OtherFees);

		note.SetIrrf(dto.Irrf);

		note.SetImported(fileName);

		return note;
	}
}