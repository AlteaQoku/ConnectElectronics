using Microsoft.AspNetCore.Mvc;

namespace ConnectElectronics.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Main()
        {
            return View();
        }
    }
}
