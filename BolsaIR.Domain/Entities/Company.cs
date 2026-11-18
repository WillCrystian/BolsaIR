using BolsaIR.Domain.Common;

namespace BolsaIR.Domain.Entities;

public class Company : EntityBase
{
	private Company()
	{
	}

	public Company(string name, string tradingName, string cnpj)
	{
		if (string.IsNullOrWhiteSpace(name))
			throw new ArgumentException("Nome obrigatório.");

		if (string.IsNullOrWhiteSpace(tradingName))
			throw new ArgumentException("Nome de negociação obrigatório.");

		if (string.IsNullOrWhiteSpace(cnpj))
			throw new ArgumentException("CNPJ obrigatório.");

		Name = name.Trim();

		TradingName = tradingName.Trim();

		Cnpj = NormalizeCnpj(cnpj);

		IsActive = true;
	}

	public string Name { get; private set; } = string.Empty;

	public string TradingName { get; private set; } = string.Empty;

	public string Cnpj { get; private set; } = string.Empty;

	public string? Sector { get; private set; }

	public string? Segment { get; private set; }

	public string? Website { get; private set; }

	public bool IsActive { get; private set; }

	public ICollection<Asset> Assets { get; private set; } = new List<Asset>();

	public void Update(string name, string tradingName, string cnpj, string? sector, string? segment, string? website)
	{
		if (string.IsNullOrWhiteSpace(name))
			throw new ArgumentException("Nome obrigatório.");

		if (string.IsNullOrWhiteSpace(tradingName))
			throw new ArgumentException("Nome de negociação obrigatório.");

		if (string.IsNullOrWhiteSpace(cnpj))
			throw new ArgumentException("CNPJ obrigatório.");

		Name = name.Trim();

		TradingName = tradingName.Trim();

		Cnpj = NormalizeCnpj(cnpj);

		Sector = sector;

		Segment = segment;

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

	private static string NormalizeCnpj(string cnpj)
	{
		return cnpj
			.Replace(".", "")
			.Replace("/", "")
			.Replace("-", "")
			.Trim();
	}
}