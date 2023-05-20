
using System.ComponentModel.DataAnnotations;

namespace ConnectElectronics.Models
{
    public class Marka
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Emri { get; set; }
        public string? Shteti { get; set; }
        public List<Produkt>? Produkte { get; set; }

    }
}
