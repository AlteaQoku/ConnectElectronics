using Microsoft.AspNetCore.Mvc;
using ConnectElectronics.Data;
using Microsoft.EntityFrameworkCore;


namespace Project.Infrastructure.Components
{
    public class KategoritViewComponent:ViewComponent
    {
        private readonly ApplicationDbContext _context;

        public KategoritViewComponent(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync() => View(await _context.Kategorit.ToListAsync());
    }
}
