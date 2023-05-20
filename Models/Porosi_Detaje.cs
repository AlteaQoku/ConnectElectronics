
using ConnectElectronics.Models;
using System.ComponentModel.DataAnnotations;

namespace ConnectElectronics.Models
{
    public class Porosi_Detaje
    {
        [Display(Name = "Id e Produktit")]
        public int ProduktId { get; set; }
        public Produkt? Produkt { get; set; }
        public int PorosiId { get; set; }
        public Porosi? Porosi { get; set; }
        [Display(Name = "Sasia e Produktit")]
        public int? Pr_Sasia { get; set; }
        [Display(Name = "Shuma e Produktit")]
        public double ShumaProdukt { get; set; }

    }
}