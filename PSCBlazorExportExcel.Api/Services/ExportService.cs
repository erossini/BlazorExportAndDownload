using ClosedXML.Excel;
using PSCBlazorExportExcel.Api.Data;
using PSCBlazorExportExcel.Api.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSCBlazorExportExcel.Api.Services
{
	public class ExportService
	{
		#region CSV
		public string GetCSV(IEnumerable<Author> list)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendLine("Id,FirstName,LastName");
			foreach (var author in list)
			{
				stringBuilder.AppendLine($"{author.Id},{author.FirstName},{ author.LastName}");
			}

			return stringBuilder.ToString();
		}
		#endregion

		#region Excel
		private byte[] ConvertToByte(XLWorkbook workbook)
		{
			var stream = new MemoryStream();
			workbook.SaveAs(stream);

			var content = stream.ToArray();
			return content;
		}

		public byte[] CreateAuthorExport()
		{
			var workbook = new XLWorkbook();
			workbook.Properties.Title = "Export from authors";
			workbook.Properties.Author = "Enrico Rossini";
			workbook.Properties.Subject = "Export from authors";
			workbook.Properties.Keywords = "authors, puresourcecode, blazor";

			CreateAuthorWorksheet(workbook);

			return ConvertToByte(workbook);
		}

		public byte[] CreateFullExport()
		{
			var workbook = new XLWorkbook();
			workbook.Properties.Title = "Full Export";
			workbook.Properties.Author = "Enrico Rossini";
			workbook.Properties.Subject = "Full Export";
			workbook.Properties.Keywords = "authors, puresourcecode, blazor";

			CreateAuthorWorksheet(workbook);
			CreateOtherWorksheet(workbook);

			return ConvertToByte(workbook);
		}

		public void CreateAuthorWorksheet(XLWorkbook package)
		{
			var worksheet = package.Worksheets.Add("Authors");

			worksheet.Cell(1, 1).Value = "Id";
			worksheet.Cell(1, 2).Value = "FirstName";
			worksheet.Cell(1, 3).Value = "LastName";
			for (int index = 1; index <= AuthorData.Authors.Count; index++)
			{
				worksheet.Cell(index + 1, 1).Value = AuthorData.Authors[index - 1].Id;
				worksheet.Cell(index + 1, 2).Value = AuthorData.Authors[index - 1].FirstName;
				worksheet.Cell(index + 1, 3).Value = AuthorData.Authors[index - 1].LastName;
			}
		}

		public void CreateOtherWorksheet(XLWorkbook package)
		{
		}
		#endregion
	}
}