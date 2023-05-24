using ConnectElectronics.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ConnectElectronics.Data;
using Microsoft.EntityFrameworkCore;

namespace ConnectElectronics.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var cookieval = Request.Cookies["SaveLastCategory"];
            ViewBag.Cookie = cookieval;
            return View(_context.Produkte.Include(p=>p.Kategori).Include(p=>p.marka).ToList());
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