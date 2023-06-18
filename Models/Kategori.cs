using System.ComponentModel.DataAnnotations;

namespace ConnectElectronics.Models
{
    public class Kategori
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name ="Name")]
        public string Emri { get; set; }
        [Display(Name ="Description")]
        public string? Pershkrimi { get; set; }
        public List<Produkt>? Produkte { get; set; }
    }
}