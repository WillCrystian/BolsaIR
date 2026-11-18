using FluentValidation;

namespace BolsaIR.Application.Features.Operations.Commands.UpdateOperation;

public sealed class UpdateOperationCommandValidator : AbstractValidator<UpdateOperationCommand>
{
	public UpdateOperationCommandValidator()
	{
		RuleFor(x => x.BrokerageNoteId)
			.NotEmpty();

		RuleFor(x => x.OperationId)
			.NotEmpty();

		RuleFor(x => x.AssetId)
			.NotEmpty();

		RuleFor(x => x.Quantity)
			.GreaterThan(0);

		RuleFor(x => x.UnitPrice)
			.GreaterThan(0);
	}
}