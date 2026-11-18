using FluentValidation;

namespace BolsaIR.Application.Features.PositionProcessing.Commands.ProcessBrokerageNote;

public sealed class ProcessBrokerageNoteCommandValidator : AbstractValidator<ProcessBrokerageNoteCommand>
{
	public ProcessBrokerageNoteCommandValidator()
	{
		RuleFor(x => x.BrokerageNoteId)
			.NotEmpty();
	}
}