using ConnectElectronics.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ConnectElectronics.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.RazorPages;


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

        public  IActionResult Index(int? pageNumber)
        {
            
            var cookieval = Request.Cookies["SaveLastCategory"];
            ViewBag.Cookie = cookieval;
            int pageSize = 8;
            var produkteRecommended = _context.Produkte.Where(p => p.Kategori.Emri == cookieval).Take(4).Include(p => p.marka).Include(p => p.Kategori);
            ViewBag.recommended = produkteRecommended;
            return View( PaginatedList<Produkt>.Create(_context.Produkte.Include(p=>p.Kategori).Include(p=>p.marka).ToList(),pageNumber ?? 1, pageSize));
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