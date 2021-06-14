using PSCBlazorExportExcel.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSCBlazorExportExcel.Api.Data
{
	public static class AuthorData
	{
		public static List<Author> Authors = new List<Author>
		{
			new Author { Id = 1, FirstName = "Enrico", LastName = "Rossini" },
			new Author { Id = 2, FirstName = "Donal", LastName = "Duck" },
			new Author { Id = 3, FirstName = "Mickey", LastName = "Mouse"}
		};
	}
}