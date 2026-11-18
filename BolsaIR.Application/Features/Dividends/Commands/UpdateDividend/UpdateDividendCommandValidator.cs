using FluentValidation;

namespace BolsaIR.Application.Features.Dividends.Commands.UpdateDividend;

public sealed class UpdateDividendCommandValidator	: AbstractValidator<UpdateDividendCommand>
{
	public UpdateDividendCommandValidator()
	{
		RuleFor(x => x.Id)
			.NotEmpty();

		RuleFor(x => x.ValuePerShare)
			.GreaterThan(0);

		RuleFor(x => x.PaymentDate)
			.GreaterThanOrEqualTo(x => x.ExDate);
	}
}