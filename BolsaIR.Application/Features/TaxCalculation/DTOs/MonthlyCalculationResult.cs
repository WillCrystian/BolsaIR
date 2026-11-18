using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolsaIR.Application.Features.TaxCalculation.DTOs;

public sealed class MonthlyCalculationResult
{
	public int Year { get; init; }

	public int Month { get; init; }

	public decimal Sales { get; set; }

	public decimal Cost { get; set; }

	public decimal GrossProfit { get; set; }

	public decimal TaxableProfit { get; set; }

	public decimal AccumulatedLoss { get; set; }

	public decimal Irrf { get; set; }

	public decimal TaxRate { get; set; }

	public decimal TaxDue { get; set; }

	public bool IsExempt { get; set; }
}
