using BolsaIR.Application.Features.BrokerageNotes.DTOs;
using BolsaIR.Domain.Enums;
using BolsaIR.Infrastructure.Importers.BTG.Helpers;
using System.Globalization;
using System.Text.RegularExpressions;

namespace BolsaIR.Infrastructure.Importers.BTG;

internal sealed class BtgOperationReader
{
	private static readonly CultureInfo PtBr = new("pt-BR");

	public void Read(BtgImportContext context)
	{
		ArgumentNullException.ThrowIfNull(context);

		var operationLines =
			GetOperationLines(context.Lines);

		foreach (var line in operationLines)
		{
			var operation = Parse(line);

			if (operation is not null)
				context.Note.Operations.Add(operation);
		}
	}

	private static IEnumerable<string> GetOperationLines(
		IEnumerable<string> lines)
	{
		return lines.Where(x =>
			x.StartsWith(
				BtgConstants.OperationsPrefix,
				StringComparison.OrdinalIgnoreCase));
	}

	private static ImportOperationDto? Parse(string line)
	{
		var parts =
			line.Split(
				' ',
				StringSplitOptions.RemoveEmptyEntries);

		if (parts.Length < 8)
			return null;

		var tickerIndex =
			FindTicker(parts);

		if (tickerIndex < 0)
			return null;

		var quantityIndex =
			FindQuantityIndex(
				parts,
				tickerIndex);

		if (quantityIndex < 0)
			return null;

		var ticker =
			parts[tickerIndex];

		//-------------------------------------------------
		// Detecta mercado/tipo do ativo
		//-------------------------------------------------

		var market =
			BtgMarketDetector.Detect(line);

		//-------------------------------------------------
		// Cria DTO
		//-------------------------------------------------

		return new ImportOperationDto
		{
			Ticker = ticker,

			TradingName =
				GetTradingName(
					parts,
					tickerIndex,
					quantityIndex),

			AssetType =
				market.AssetType,

			OperationType =
				GetOperationType(parts),

			TradeType =
				market.TradeType,

			Quantity =
				GetQuantity(
					parts,
					quantityIndex),

			UnitPrice =
				GetUnitPrice(
					parts,
					quantityIndex),

			GrossValue =
				GetGrossValue(
					parts,
					quantityIndex),

			Observation =
				market.Description
		};
	}

	#region Ticker

	private static int FindTicker(
		string[] parts)
	{
		return Array.FindIndex(
			parts,
			x => Regex.IsMatch(
				x,
				BtgRegex.Ticker));
	}

	#endregion

	#region Quantity

	/// <summary>
	/// Procura o primeiro inteiro após o ticker.
	/// Esse inteiro representa a quantidade.
	/// </summary>
	private static int FindQuantityIndex(
		string[] parts,
		int tickerIndex)
	{
		for (
			var i = tickerIndex + 1;
			i < parts.Length;
			i++)
		{
			if (int.TryParse(
				parts[i],
				out _))
			{
				return i;
			}
		}

		return -1;
	}

	private static int GetQuantity(
		string[] parts,
		int quantityIndex)
	{
		return int.Parse(
			parts[quantityIndex],
			CultureInfo.InvariantCulture);
	}

	#endregion

	#region Operation

	private static OperationType GetOperationType(
		string[] parts)
	{
		return parts[1].Equals(
			"C",
			StringComparison.OrdinalIgnoreCase)
				? OperationType.Buy
				: OperationType.Sell;
	}

	#endregion

	#region Values

	private static decimal GetUnitPrice(
		string[] parts,
		int quantityIndex)
	{
		return decimal.Parse(
			parts[quantityIndex + 1],
			PtBr);
	}

	private static decimal GetGrossValue(
		string[] parts,
		int quantityIndex)
	{
		return decimal.Parse(
			parts[quantityIndex + 2],
			PtBr);
	}

	#endregion

	#region Trading Name

	/// <summary>
	/// Tudo que estiver entre o ticker e a quantidade
	/// pertence ao nome do ativo.
	/// </summary>
	private static string GetTradingName(
		string[] parts,
		int tickerIndex,
		int quantityIndex)
	{
		return string.Join(
			" ",
			parts
				.Skip(tickerIndex + 1)
				.Take(
					quantityIndex -
					tickerIndex -
					1));
	}

	#endregion
}