using FluentValidation;

namespace BolsaIR.Application.Features.Brokers.Commands.UpdateBroker;

public sealed class UpdateBrokerCommandValidator : AbstractValidator<UpdateBrokerCommand>
{
	public UpdateBrokerCommandValidator()
	{
		RuleFor(x => x.Id)
			.NotEmpty();

		RuleFor(x => x.Name)
			.NotEmpty()
			.MaximumLength(150);

		RuleFor(x => x.Cnpj)
			.MaximumLength(20);

		RuleFor(x => x.Website)
			.MaximumLength(250);

		RuleFor(x => x.ImporterName)
			.MaximumLength(100);
	}
}