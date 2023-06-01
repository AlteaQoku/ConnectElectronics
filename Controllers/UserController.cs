using Microsoft.AspNetCore.Mvc;

namespace ConnectElectronics.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
