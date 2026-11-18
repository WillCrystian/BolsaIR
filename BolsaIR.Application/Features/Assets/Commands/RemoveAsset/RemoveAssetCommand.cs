using BolsaIR.Application.Common;
using MediatR;

namespace BolsaIR.Application.Features.Assets.Commands.RemoveAsset;

public sealed class RemoveAssetCommand : IRequest<Result>
{
	public Guid Id { get; init; }
}