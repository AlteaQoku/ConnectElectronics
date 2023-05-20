using System.ComponentModel.DataAnnotations;

namespace ConnectElectronics.Models
{
    public class Kategori
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Emri { get; set; }
        public string? Pershkrimi { get; set; }
        public List<Produkt>? Produkte { get; set; }
    }
}