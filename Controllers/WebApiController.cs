using ConnectElectronics.Data;
using ConnectElectronics.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ConnectElectronics.Controllers
{

	[ApiController]
	[Route("api/[Controller]/[Action]")]
	public class WebApiController : ControllerBase
	{
		private readonly ApplicationDbContext _context;
		private readonly IUserService _userService;
		public WebApiController(ApplicationDbContext context, IUserService service)
		{ 
			_context = context;
			_userService = service;
		}
		
		public IActionResult getUsers()
		{
			return Ok(_context.Users.Count());
		}

		public IActionResult prodForDiscount()
		{
			return Ok(_context.Produkte.OrderByDescending(p => p.Sasia).Take(3));
		}

		public IActionResult getSalesInMonth()
		{
			var result = from Porosite in _context.Porosit
						 group Porosite by new
						 {
							 Porosite.DataPorosis.Month
						 } into final select new
                         {
                             Muaji = new DateTime(1, final.Key.Month, 1).ToString("MMMM"),
                             Count = final.Count()
                         };
            return Ok(result);
		}

		public IActionResult getUserHighestBuy()
		{

			return Ok(_context.Porosit.Where(p => p.DataPorosis.Month == DateTime.Now.Month).OrderByDescending(p=>p.ShumaT).Take(1));
		}
	}
}
