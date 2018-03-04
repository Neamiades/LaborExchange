using System.Diagnostics;
using LaborExchange.Models;
using Microsoft.AspNetCore.Mvc;

namespace LaborExchange.Controllers
{
	public class HomeController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}

		public IActionResult About()
		{
			ViewData["Message"] = "LaborExchange is a web application for subject 'Designing corporate information systems 1.Modeling and designing systems'";

			return View();
		}

		public IActionResult Contact()
		{
			ViewData["Message"] = "Student of the fifth year of the Faculty of Applied Mathematics in NTUU 'KPI' - Sergey Yakhin, KP-71mn";

			return View();
		}

		public IActionResult Error()
		{
			return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
		}
	}
}