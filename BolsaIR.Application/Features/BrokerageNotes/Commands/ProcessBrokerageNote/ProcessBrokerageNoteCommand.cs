using BolsaIR.Application.Common;
using MediatR;

namespace BolsaIR.Application.Features.BrokerageNotes.Commands.ProcessBrokerageNote;

public sealed record ProcessBrokerageNoteCommand(
	Guid BrokerageNoteId)
	: IRequest<Result>;