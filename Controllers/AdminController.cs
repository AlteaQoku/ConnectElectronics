using Microsoft.AspNetCore.Mvc;

namespace ConnectElectronics.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
