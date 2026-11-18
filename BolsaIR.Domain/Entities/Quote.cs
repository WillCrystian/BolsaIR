using BolsaIR.Domain.Common;

namespace BolsaIR.Domain.Entities;

public class Quote : EntityBase
{
	private Quote()
	{
	}

	public Quote(Asset asset, DateOnly tradingDate, decimal open, decimal high, decimal low, decimal close, long volume)
	{
		if (asset is null)
			throw new ArgumentNullException(nameof(asset));

		if (open < 0)
			throw new ArgumentNullException(nameof(open));

		if (high < 0)
			throw new ArgumentNullException(nameof(high));

		if (low < 0)
			throw new ArgumentNullException(nameof(low));

		if (close < 0)
			throw new ArgumentNullException(nameof(close));

		if (volume < 0)
			throw new ArgumentNullException(nameof(volume));

		Asset = asset;
		AssetId = asset.Id;

		TradingDate = tradingDate;

		Open = open;
		High = high;
		Low = low;
		Close = close;

		Volume = volume;
	}

	public Guid AssetId { get; private set; }

	public Asset Asset { get; private set; } = null!;

	public DateOnly TradingDate { get; private set; }

	public decimal Open { get; private set; }

	public decimal High { get; private set; }

	public decimal Low { get; private set; }

	public decimal Close { get; private set; }

	public long Volume { get; private set; }
}