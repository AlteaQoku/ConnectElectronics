using ConnectElectronics.Data;
using Microsoft.AspNetCore.Mvc;

namespace ConnectElectronics.Controllers
{

	[ApiController]
	[Route("api/[Controller]/[Action]")]
	public class WebApiController : ControllerBase
	{
		private readonly ApplicationDbContext _context;
		public WebApiController(ApplicationDbContext context) => _context = context;
		
		public IActionResult getUsers()
		{
			return Ok(_context.Users.Count());
		}

		public IActionResult prodForDiscount()
		{
			return Ok(_context.Produkte.OrderByDescending(p => p.Sasia).Take(3));
		}
	}
}
