namespace BolsaIR.Infrastructure.Pdf;

public static class PdfLineBuilder
{
	public static List<string> BuildLines(PdfPage page)
	{
		const decimal tolerance = 2;

		var groups =
			page.Words
				.GroupBy(x => Math.Round((double)(x.Y / tolerance)))
				.OrderByDescending(x => x.First().Y);

		var result = new List<string>();

		foreach (var group in groups)
		{
			result.Add(
				string.Join(
					" ",
					group
						.OrderBy(x => x.X)
						.Select(x => x.Text)));
		}

		return result;
	}
}