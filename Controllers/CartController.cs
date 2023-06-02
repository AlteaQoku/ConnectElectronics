using Microsoft.AspNetCore.Mvc;
using ConnectElectronics.Data;
using ConnectElectronics.Infrastructure;
using ConnectElectronics.Models;
using ConnectElectronics.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace ConnectElectronics.Controllers
{
    public class CartController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CartController(ApplicationDbContext context)
        {
            _context = context;
        }
        [Authorize]
        public IActionResult Index()
        {
            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart") ?? new List<CartItem>();
            CartViewModel cartVM = new()
            {
                ProdukteShport = cart,
                CmimiTotal = cart.Sum(x => x.Sasi * x.Cmimi)
            };

            return View(cartVM);
        }
        public async Task<IActionResult> Add(int Id)
        {
                Produkt produkt = await _context.Produkte.FindAsync(Id)?? new Produkt();
            if (ModelState.IsValid)
            {
             
                List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart") ?? new List<CartItem>();

                CartItem cartItem = cart.Where(c => c.ProduktId == Id).FirstOrDefault();
                if (cartItem == null)
                {
                    cart.Add(new CartItem(produkt));
                }
                else
                {
                    cartItem.Sasi += 1;
                }

                HttpContext.Session.SetJson("Cart", cart);

                TempData["Success"] = "Produkti eshte shtuar!";

                return Redirect(Request.Headers["Referer"].ToString());
            }
            else
            {
                TempData["Danger"] = "Produkti nuk u shtua!";
                return RedirectToAction("Index", "Produkt");
            }

        }
        public  ActionResult Decrease(int id)
        {
            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart");

            CartItem cartItem = cart.Where(c => c.ProduktId == id).FirstOrDefault() ?? new CartItem();

            if (cartItem.Sasi > 1)
            {
                --cartItem.Sasi;
            }
            else
            {
                cart.RemoveAll(p => p.ProduktId == id);
            }

            if (cart.Count == 0)
            {
                HttpContext.Session.Remove("Cart");
            }
            else
            {
                HttpContext.Session.SetJson("Cart", cart);
            }

            TempData["Success"] = "Produkti u hoq!";

            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Remove(long id)
        {
            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart");

            cart.RemoveAll(p => p.ProduktId == id);

            if (cart.Count == 0)
            {
                HttpContext.Session.Remove("Cart");
            }
            else
            {
                HttpContext.Session.SetJson("Cart", cart);
            }

            TempData["Success"] = "Produkti u fshi!";

            return RedirectToAction("Index");
        }

        public IActionResult Clear()
        {
            HttpContext.Session.Remove("Cart");

            return RedirectToAction("Index");
        }


    }
}
