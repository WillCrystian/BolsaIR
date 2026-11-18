using UglyToad.PdfPig;

namespace BolsaIR.Infrastructure.Pdf;

public sealed class PdfPigReaderService
{
	public List<PdfPage> ExtractPages(Stream stream)
	{
		var pages = new List<PdfPage>();

		using var document = PdfDocument.Open(stream);

		foreach (var page in document.GetPages())
		{
			var pdfPage = new PdfPage
			{
				PageNumber = page.Number
			};

			foreach (var word in page.GetWords())
			{
				pdfPage.Words.Add(new PdfWord
				{
					X = (int)word.BoundingBox.Left,
					Y = (int)word.BoundingBox.Bottom,
					Text = word.Text
				});
			}

			pages.Add(pdfPage);
		}

		return pages;
	}
}