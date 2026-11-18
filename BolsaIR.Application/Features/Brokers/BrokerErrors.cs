using BolsaIR.Application.Common;

namespace BolsaIR.Application.Features.Brokers;

public static class BrokerErrors
{
	public static readonly Error NotFound =
		new("Broker.NotFound", "Corretora não encontrada.");

	public static readonly Error AlreadyExists =
		new("Broker.AlreadyExists", "Já existe uma corretora com este nome.");

	public static readonly Error HasBrokerageNotes =
		new(
			"Broker.HasBrokerageNotes",
			"A corretora possui notas de corretagem cadastradas.");

	public static readonly Error IsAlreadyActive =
		new(
			"Broker.IsAlreadyActive",
			"A corretora já está ativa.");

	public static readonly Error IsAlreadyInactive =
		new(
			"Broker.IsAlreadyInactive",
			"A corretora já está inativa.");

}