using FluentValidation;

namespace BolsaIR.Application.Features.Dividends.Commands.CreateDividend;

public sealed class CreateDividendCommandValidator : AbstractValidator<CreateDividendCommand>
{
	public CreateDividendCommandValidator()
	{
		RuleFor(x => x.AssetId)
			.NotEmpty();

		RuleFor(x => x.ValuePerShare)
			.GreaterThan(0);

		RuleFor(x => x.PaymentDate)
			.GreaterThanOrEqualTo(x => x.ExDate);
	}
}