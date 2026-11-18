using FluentValidation;

namespace BolsaIR.Application.Features.CorporateActions.Commands.CreateCorporateAction;

public sealed class CreateCorporateActionValidator : AbstractValidator<CreateCorporateActionCommand>
{
	public CreateCorporateActionValidator()
	{
		RuleFor(x => x.AssetId)
			.NotEmpty();

		RuleFor(x => x.Factor)
			.GreaterThan(0);

		RuleFor(x => x.EffectiveDate)
			.GreaterThanOrEqualTo(x => x.ApprovedDate);
	}
}