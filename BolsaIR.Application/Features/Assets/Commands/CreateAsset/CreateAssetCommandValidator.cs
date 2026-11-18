using FluentValidation;

namespace BolsaIR.Application.Features.Assets.Commands.CreateAsset;

public sealed class CreateAssetCommandValidator : AbstractValidator<CreateAssetCommand>
{
	public CreateAssetCommandValidator()
	{
		RuleFor(x => x.Ticker)
			.NotEmpty()
			.MaximumLength(20);

		RuleFor(x => x.TradingName)
			.NotEmpty()
			.MaximumLength(200);
	}
}