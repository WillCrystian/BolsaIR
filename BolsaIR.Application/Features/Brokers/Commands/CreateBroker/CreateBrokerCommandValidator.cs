using FluentValidation;

namespace BolsaIR.Application.Features.Brokers.Commands.CreateBroker;

public sealed class CreateBrokerCommandValidator : AbstractValidator<CreateBrokerCommand>
{
	public CreateBrokerCommandValidator()
	{
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