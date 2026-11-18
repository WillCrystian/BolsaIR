using FluentValidation;

namespace BolsaIR.Application.Features.BrokerageNotes.Commands.CreateBrokerageNote;

public class CreateBrokerageNoteCommandValidator : AbstractValidator<CreateBrokerageNoteCommand>
{
	public CreateBrokerageNoteCommandValidator()
	{
		RuleFor(x => x.BrokerId)
			.NotEmpty();

		RuleFor(x => x.NoteNumber)
			.NotEmpty()
			.MaximumLength(50);

		RuleFor(x => x.TradeDate)
			.NotEmpty();
	}
}
