using FluentValidation;

namespace BolsaIR.Application.Features.CorporateActions.Commands.UpdateCorporateAction;

public sealed class UpdateCorporateActionValidator : AbstractValidator<UpdateCorporateActionCommand>
{
	public UpdateCorporateActionValidator()
	{
		RuleFor(x => x.Id)
			.NotEmpty();

		RuleFor(x => x.Factor)
			.GreaterThan(0);

		RuleFor(x => x.ApprovedDate)
			.NotEmpty();

		RuleFor(x => x.EffectiveDate)
			.NotEmpty();
	}
}