using BolsaIR.Domain.Common;

namespace BolsaIR.Domain.Entities;

public class Position : EntityBase
{
	private Position()
	{
	}

	public Position(Asset asset)
	{
		ArgumentNullException.ThrowIfNull(asset);

		Asset = asset;
		AssetId = asset.Id;

		Quantity = 0;
		AveragePrice = 0;
		TotalCost = 0;
		LastMovementDate = null;
	}

	public Guid AssetId { get; private set; }

	public Asset Asset { get; private set; } = null!;

	/// <summary>
	/// Quantidade atual em carteira.
	/// </summary>
	public decimal Quantity { get; private set; }

	/// <summary>
	/// Preço médio atual.
	/// </summary>
	public decimal AveragePrice { get; private set; }

	/// <summary>
	/// Custo total investido na posição.
	/// </summary>
	public decimal TotalCost { get; private set; }

	/// <summary>
	/// Data da última movimentação.
	/// </summary>
	public DateOnly? LastMovementDate { get; private set; }

	public bool IsClosed => Quantity == 0;

	public void Buy(decimal quantity, decimal unitPrice, DateOnly movementDate)
	{
		if (quantity <= 0)
			throw new ArgumentOutOfRangeException(nameof(quantity));

		if (unitPrice <= 0)
			throw new ArgumentOutOfRangeException(nameof(unitPrice));

		var purchaseValue = quantity * unitPrice;

		TotalCost += purchaseValue;
		Quantity += quantity;

		AveragePrice = Quantity == 0
			? 0
			: TotalCost / Quantity;

		LastMovementDate = movementDate;

		Touch();
	}

	public void Sell(decimal quantity, DateOnly movementDate)
	{
		if (quantity <= 0)
			throw new ArgumentOutOfRangeException(nameof(quantity));

		if (quantity > Quantity)
			throw new InvalidOperationException("Quantidade insuficiente para venda.");

		var costRemoved = quantity * AveragePrice;

		Quantity -= quantity;
		TotalCost -= costRemoved;

		if (Quantity == 0)
		{
			AveragePrice = 0;
			TotalCost = 0;
		}
		else
		{
			AveragePrice = TotalCost / Quantity;
		}

		LastMovementDate = movementDate;

		Touch();
	}

	/// <summary>
	/// Ex.: desdobramento 1:2 -> factor = 2
	/// </summary>
	public void ApplySplit(decimal factor)
	{
		if (factor <= 1)
			throw new ArgumentOutOfRangeException(nameof(factor));

		Quantity = (int)Math.Round(Quantity * factor);

		if (Quantity > 0)
			AveragePrice = TotalCost / Quantity;

		Touch();
	}

	/// <summary>
	/// Ex.: grupamento 2:1 -> factor = 2
	/// </summary>
	public void ApplyReverseSplit(decimal factor)
	{
		if (factor <= 1)
			throw new ArgumentOutOfRangeException(nameof(factor));

		Quantity = (int)Math.Round(Quantity / factor);

		if (Quantity == 0)
		{
			AveragePrice = 0;
			TotalCost = 0;
		}
		else
		{
			AveragePrice = TotalCost / Quantity;
		}

		Touch();
	}

	/// <summary>
	/// Ex.: bonificação de 10% -> factor = 1.10
	/// </summary>
	public void ApplyBonus(decimal factor)
	{
		if (factor <= 1)
			throw new ArgumentOutOfRangeException(nameof(factor));

		Quantity = (int)Math.Round(Quantity * factor);

		if (Quantity > 0)
			AveragePrice = TotalCost / Quantity;

		Touch();
	}
}