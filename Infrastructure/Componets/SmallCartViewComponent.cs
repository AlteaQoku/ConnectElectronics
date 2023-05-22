using Microsoft.AspNetCore.Mvc;
using ConnectElectronics.Models;
using ConnectElectronics.Models.ViewModels;


namespace ConnectElectronics.Infrastructure.Components
{
    public class SmallCartViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart");
            SmallCartViewModel kartaVm;

            if (cart == null || cart.Count == 0)
            {
                kartaVm = null;
            }
            else
            {
                kartaVm = new()
                {
                    NumriProdukteve = cart.Sum(x => x.Sasi),
                    TotalCmimi = cart.Sum(x => x.Sasi * x.Cmimi)
                };
            }
            
          return View(kartaVm);
        }
    }
}
