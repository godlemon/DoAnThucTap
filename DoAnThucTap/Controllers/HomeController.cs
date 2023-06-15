using DoAnThucTap.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoAnThucTap.Controllers
{
    public class HomeController : Controller
    {

		private readonly ILogger<HomeController> _logger;
		private readonly ADbContext dbContext;

		public HomeController(ILogger<HomeController> logger, ADbContext dbContext)
		{
			_logger = logger;
			this.dbContext = dbContext;
		}
		[HttpGet]
		public async Task<IActionResult> Main()
        {
			var bannersQuery = from b in dbContext.banners
							   orderby b.Id descending
							   select b;

			ViewBag.Banners = await bannersQuery.ToListAsync();

			var tagsQuery = from t in dbContext.Tags
							select t;

			ViewBag.Tags = await tagsQuery.ToListAsync();
			return View();
		}
        public IActionResult Register()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}