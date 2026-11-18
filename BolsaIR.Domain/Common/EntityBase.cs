namespace BolsaIR.Domain.Common;

public abstract class EntityBase
{
	protected EntityBase()
	{
		Id = Guid.NewGuid();
		CreatedAt = DateTime.UtcNow;
	}

	public Guid Id { get; protected set; }

	public DateTime CreatedAt { get; protected set; }

	public DateTime? UpdatedAt { get; protected set; }

	public void Touch()
	{
		UpdatedAt = DateTime.UtcNow;
	}
}