using BolsaIR.Domain.Common;

namespace BolsaIR.Domain.Entities;

public class Holiday : EntityBase
{
	private Holiday()
	{
	}

	public Holiday(DateOnly date, string description)
	{
		Date = date;
		Description = description.Trim();
	}

	public DateOnly Date { get; private set; }

	public string Description { get; private set; } = string.Empty;
}