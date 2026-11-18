using BolsaIR.Domain.Common;
using BolsaIR.Domain.Enums;

namespace BolsaIR.Domain.Entities;

public class Broker : EntityBase
{
	private Broker()
	{
	}

	public Broker(string name)
	{
		if (string.IsNullOrWhiteSpace(name))
			throw new ArgumentException("Nome obrigatório.");

		Name = name.Trim().ToUpperInvariant();
		IsActive = true;
	}

	public string Name { get; private set; } = string.Empty;

	public string? Cnpj { get; private set; }

	public string? Website { get; private set; }

	public string? ImporterName { get; private set; }

	public bool IsActive { get; private set; }

	public ICollection<BrokerageNote> BrokerageNotes { get; private set; } = new List<BrokerageNote>();

	public void ConfigureImporter(string importer)
	{
		if (string.IsNullOrWhiteSpace(importer))
			throw new ArgumentException(nameof(importer));

		ImporterName = importer;
		Touch();
	}
	public void Update(string name, string? cnpj, string? website, string? importerName)
	{
		if (string.IsNullOrWhiteSpace(name))
			throw new ArgumentException("Nome obrigatório.");

		Name = name.Trim().ToUpperInvariant();

		Cnpj = cnpj;

		Website = website;

		ImporterName = importerName;

		Touch();
	}

	public void UpdateInformation(string? cnpj, string? website)
	{
		Cnpj = cnpj;
		Website = website;
		Touch();
	}
	public void Activate()
	{
		if (IsActive)
			return;

		IsActive = true;
		Touch();
	}

	public void Inactivate()
	{
		if (!IsActive)
			return;

		IsActive = false;
		Touch();
	}
}