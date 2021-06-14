using Microsoft.AspNetCore.Mvc;
using PSCBlazorExportExcel.Api.Services;

namespace PSCBlazorExportExcel.Api.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class ExportController : Controller
	{
		private ExportService _service;

		private string contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
		private string fileName = "authors.xlsx";

		public ExportController(ExportService service)
		{
			_service = service;
		}

		[HttpGet]
		public IActionResult DownloadAuthorsExport()
		{
			return File(_service.CreateAuthorExport(), contentType, fileName);
		}
	}
}