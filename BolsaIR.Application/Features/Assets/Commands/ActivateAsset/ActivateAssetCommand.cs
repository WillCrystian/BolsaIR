using BolsaIR.Application.Common;
using MediatR;

namespace BolsaIR.Application.Features.Assets.Commands.ActivateAsset;

public sealed class ActivateAssetCommand : IRequest<Result>
{
	public Guid Id { get; init; }
}