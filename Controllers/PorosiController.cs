﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ConnectElectronics.Data;
using ConnectElectronics.Infrastructure;
using ConnectElectronics.Models;
using ConnectElectronics.Models.ViewModels;
using System.Data;
using System.Reflection.Emit;

namespace ConnectElectronics.Controllers
{
    public class PorosiController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IUserService _userService;
        public PorosiController(ApplicationDbContext context, IUserService service)
        {
            _context = context;
            _userService = service;
        }
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {

            return View(await _context.Porosit.ToListAsync());
        }
        [Authorize]
        public async Task<IActionResult> PorositEMia()
        {
            var UserId = _userService.getUserId();
            var PorosiPersonale = _context.Porosit.Where(p => p.KlientId == UserId);
            return View(await PorosiPersonale.OrderByDescending(p => p.Id).ToListAsync());
        }
        [Authorize]
        public IActionResult CheckOut()
        {
            
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CheckOut(Porosi porosi)
        {
           var UserId = _userService.getUserId();
           
            var UserN = _userService.getUserName().Split('@')[0];
            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart") ?? new List<CartItem>();

            CartViewModel cartVM = new()
            {
                ProdukteShport = cart,
                CmimiTotal = cart.Sum(x => x.Sasi * x.Cmimi)
            };
            bool PorosiaEPar = _context.Porosit.Any(p => p.KlientId == UserId);
            if (cartVM.ProdukteShport.Count > 0)
            {
                porosi.KlientId = UserId;
                porosi.KlientUserName = UserN;
                porosi.DataPorosis =DateTime.Now;
                _context.Porosit.Add(porosi);
                await _context.SaveChangesAsync();

                double shuma = 0.0;
                foreach (var item in cartVM.ProdukteShport)
                {
                    var porosidetaje = new Porosi_Detaje
                    {
                        PorosiId = porosi.Id,
                        ProduktId = item.ProduktId,
                        ShumaProdukt = (double)item.Total,
                        Pr_Sasia=item.Sasi
                    };
                    shuma +=(double) item.Total;
                    _context.Porosi_Detajet.Add(porosidetaje);
                }
                if (!PorosiaEPar)
                {
                    shuma = 0.95 * shuma;
                }
                porosi.ShumaT = shuma;
                _context.Porosit.Update(porosi);
                await _context.SaveChangesAsync();
                ViewBag.PrID = porosi.Id;
                return View("MenyratPagese",(cartVM));
            }
            return RedirectToAction("Index", "Produkt");
        }
        [Authorize]
        public IActionResult Ukrye(int? id)
        {
            var porosi = _context.Porosit
       .FirstOrDefault(m => m.Id == id);
            HttpContext.Session.Remove("Cart");
            return View(porosi);
        }
        [Authorize]
        public async Task<ActionResult> Detaje(int? id) { 
         
            if (id == null || _context.Porosit == null)
            {
                return NotFound();
    }

        var porosi = await _context.Porosit
        .FirstOrDefaultAsync(m => m.Id == id);
            if (porosi == null)
            {
                return NotFound();
            }

            return View(porosi);
        }
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Porosit == null)
            {
                return NotFound();
            }

            var porosi = await _context.Porosit
                .FirstOrDefaultAsync(m => m.Id == id);
            if (porosi == null)
            {
                return NotFound();
            }

            return View(porosi);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Porosit== null)
            {
                return Problem("Tabela e Porosive eshte bosh");
            }
            var porosi= await _context.Porosit.FindAsync(id);
            if (porosi != null)
            {
                _context.Porosit.Remove(porosi);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}

