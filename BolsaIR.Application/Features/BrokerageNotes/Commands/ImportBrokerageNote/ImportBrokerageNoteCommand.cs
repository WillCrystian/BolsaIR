using BolsaIR.Application.Common;
using MediatR;

namespace BolsaIR.Application.Features.BrokerageNotes.Commands.ImportBrokerageNote;

public sealed record ImportBrokerageNoteCommand(
	Stream File,
	string FileName)
	: IRequest<Result>;