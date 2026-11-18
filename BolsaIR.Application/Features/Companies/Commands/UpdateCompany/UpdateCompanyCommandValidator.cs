using FluentValidation;

namespace BolsaIR.Application.Features.Companies.Commands.UpdateCompany;

public sealed class UpdateCompanyCommandValidator : AbstractValidator<UpdateCompanyCommand>
{
	public UpdateCompanyCommandValidator()
	{
		RuleFor(x => x.Id)
			.NotEmpty();

		RuleFor(x => x.Name)
			.NotEmpty()
			.MaximumLength(200);

		RuleFor(x => x.TradingName)
			.NotEmpty()
			.MaximumLength(200);

		RuleFor(x => x.Cnpj)
			.NotEmpty()
			.MaximumLength(18);

		RuleFor(x => x.Website)
			.MaximumLength(500)
			.When(x => !string.IsNullOrWhiteSpace(x.Website));

		RuleFor(x => x.Sector)
			.MaximumLength(200)
			.When(x => !string.IsNullOrWhiteSpace(x.Sector));

		RuleFor(x => x.Segment)
			.MaximumLength(200)
			.When(x => !string.IsNullOrWhiteSpace(x.Segment));
	}
}