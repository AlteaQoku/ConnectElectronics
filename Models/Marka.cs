
using System.ComponentModel.DataAnnotations;

namespace ConnectElectronics.Models
{
    public class Marka
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name ="Name")]
        public string Emri { get; set; }
        [Display(Name ="Country")]
        public string? Shteti { get; set; }
        public List<Produkt>? Produkte { get; set; }

    }
}
