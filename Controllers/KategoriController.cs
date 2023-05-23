using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ConnectElectronics.Data;
using ConnectElectronics.Models;
using System.Data;

namespace ConnectElectronics.Controllers
{
    public class KategoriController : Controller { 
     
        private readonly ApplicationDbContext _context;

         public KategoriController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(int id)
        {
            return View(await _context.Kategorit.ToListAsync());
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Kategorit == null)
            {
                return NotFound();
            }
            var kategori = await _context.Kategorit
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kategori == null)
            {
                return NotFound();
            }

            return View(kategori);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
       
        public async Task<IActionResult> Create([Bind("Id,Emri,Pershkrimi")] Kategori kategori)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kategori);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(kategori);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Kategorit == null)
            {
                return NotFound();
            }

            var kategori= await _context.Kategorit.FindAsync(id);
            if (kategori == null)
            {
                return NotFound();
            }
            return View(kategori);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Emri,Pershkrimi")] Kategori kategori)
        {
            if (id != kategori.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                    _context.Update(kategori);
                    await _context.SaveChangesAsync();
                
                return RedirectToAction(nameof(Index));
            }
            return View(kategori);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Kategorit== null)
            {
                return NotFound();
            }

            var kategori = await _context.Kategorit
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kategori == null)
            {
                return NotFound();
            }

            return View(kategori);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Kategorit == null)
            {
                return Problem("Tabela Kategorit eshte bosh");
            }
            var kategori = await _context.Kategorit.FindAsync(id);
            if (kategori != null)
            {
                _context.Kategorit.Remove(kategori);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KategoriExists(int id)
        {
            return _context.Kategorit.Any(e => e.Id == id);
        }
    }
}
