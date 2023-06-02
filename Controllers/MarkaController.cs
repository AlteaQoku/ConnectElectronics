using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ConnectElectronics.Data;
using ConnectElectronics.Models;

namespace ConnectElectronics.Controllers
{
    public class MarkaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MarkaController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
              return View(await _context.Markat.ToListAsync());
        }
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Markat == null)
            {
                return NotFound();
            }
            var marka = await _context.Markat
                .FirstOrDefaultAsync(m => m.Id == id);
            if (marka == null)
            {
                return NotFound();
            }

            return View(marka);
        }
        [Authorize(Roles = "Admin")]

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Emri,Shteti")] Marka marka)
        {
            if (ModelState.IsValid)
            {
                _context.Add(marka);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(marka);
        }
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Markat == null)
            {
                return NotFound();
            }

            var marka = await _context.Markat.FindAsync(id);
            if (marka == null)
            {
                return NotFound();
            }
            return View(marka);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Emri,Shteti")] Marka marka)
        {
            if (id != marka.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                    _context.Update(marka);
                    await _context.SaveChangesAsync();
            
                return RedirectToAction(nameof(Index));
            }
            return View(marka);
        }
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Markat == null)
            {
                return NotFound();
            }

            var marka = await _context.Markat
                .FirstOrDefaultAsync(m => m.Id == id);
            if (marka == null)
            {
                return NotFound();
            }

            return View(marka);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Markat == null)
            {
                return Problem("Tabela Marka eshte bosh");
            }
            var marka = await _context.Markat.FindAsync(id);
            if (marka != null)
            {
                _context.Markat.Remove(marka);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MarkaExists(int id)
        {
          return _context.Markat.Any(e => e.Id == id);
        }
    }
}
