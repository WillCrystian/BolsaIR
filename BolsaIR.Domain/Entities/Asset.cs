using BolsaIR.Domain.Common;
using BolsaIR.Domain.Enums;

namespace BolsaIR.Domain.Entities;

public class Asset : EntityBase
{
	private Asset()
	{
	}

	public Asset(string ticker, string tradingName, AssetType assetType)
	{
		if (string.IsNullOrWhiteSpace(ticker))
			throw new ArgumentException("Ticker é obrigatório.");

		if (string.IsNullOrWhiteSpace(tradingName))
			throw new ArgumentException("Nome de negociação é obrigatório.");

		Ticker = ticker.Trim().ToUpperInvariant();
		TradingName = tradingName.Trim();
		AssetType = assetType;

		IsActive = true;
	}

	public string Ticker { get; private set; } = string.Empty;

	public string TradingName { get; private set; } = string.Empty;

	public string? CompanyName { get; private set; }

	public string? Cnpj { get; private set; }

	public string? Isin { get; private set; }

	public AssetType AssetType { get; private set; }

	public string? Sector { get; private set; }

	public string? Segment { get; private set; }

	public bool IsActive { get; private set; }

	public Guid? CompanyId { get; private set; }

	public Company? Company { get; private set; }

	public ICollection<Operation> Operations { get; private set; } = new List<Operation>();

	public ICollection<Quote> Quotes { get; private set; } = new List<Quote>();

	public ICollection<Position> Positions { get; private set; } = new List<Position>();

	public ICollection<Dividend> Dividends { get; private set; } = new List<Dividend>();

	public ICollection<CorporateAction> CorporateActions { get; private set; } = new List<CorporateAction>();

	public void Update(string tradingName, string? companyName, string? cnpj, string? isin, AssetType assetType, string? sector, string? segment)
	{
		if (string.IsNullOrWhiteSpace(tradingName))
			throw new ArgumentException("Nome de negociação é obrigatório.");

		TradingName = tradingName.Trim();

		CompanyName = companyName;
		Cnpj = cnpj;
		Isin = isin;
		AssetType = assetType;
		Sector = sector;
		Segment = segment;

		Touch();
	}

	public void Activate()
	{
		IsActive = true;
		Touch();
	}

	public void Inactivate()
	{
		IsActive = false;
		Touch();
	}

	public void AssociateCompany(Company company)
	{
		Company = company;
		CompanyId = company.Id;

		Touch();
	}
}