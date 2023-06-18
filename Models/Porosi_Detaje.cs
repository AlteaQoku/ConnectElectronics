
using ConnectElectronics.Models;
using System.ComponentModel.DataAnnotations;

namespace ConnectElectronics.Models
{
    public class Porosi_Detaje
    {
        [Display(Name = "Product ID")]
        public int ProduktId { get; set; }
        public Produkt? Produkt { get; set; }
        public int PorosiId { get; set; }
        public Porosi? Porosi { get; set; }
        [Display(Name = "Quantity")]
        public int? Pr_Sasia { get; set; }
        [Display(Name = "Price")]
        public double ShumaProdukt { get; set; }

    }
}