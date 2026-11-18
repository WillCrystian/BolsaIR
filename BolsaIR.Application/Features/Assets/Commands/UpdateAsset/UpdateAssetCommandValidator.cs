using FluentValidation;

namespace BolsaIR.Application.Features.Assets.Commands.UpdateAsset;

public sealed class UpdateAssetCommandValidator
	: AbstractValidator<UpdateAssetCommand>
{
	public UpdateAssetCommandValidator()
	{
		RuleFor(x => x.TradingName)
			.NotEmpty()
			.MaximumLength(200);
	}
}