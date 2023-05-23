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
		public bool Index()
		{
			return false;

		}
	}
}
