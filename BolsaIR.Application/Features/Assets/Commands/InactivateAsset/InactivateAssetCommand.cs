using BolsaIR.Application.Common;
using MediatR;

namespace BolsaIR.Application.Features.Assets.Commands.InactivateAsset;

public sealed class InactivateAssetCommand : IRequest<Result>
{
	public Guid Id { get; init; }
}