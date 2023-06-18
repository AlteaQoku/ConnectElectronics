using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ConnectElectronics.Models
{
    public class Produkt
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is missing")]
        [Display(Name = "Name")]
        public string? Emri { get; set; }
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price is missing")]
        [Column(TypeName = "decimal(8, 2)")]
        [ReadOnly(true)]
        [Display(Name = "Price")]
        public double Cmimi { get; set; }
        [Range(1, Int32.MaxValue, ErrorMessage = "Quantity is missing")]
        [Display(Name = "Quantity")]
        public int? Sasia { get; set; }
        [Display(Name = "Offer")]
        public bool? Oferte { get; set; }
        [Display(Name = "Description")]
        public string? Pershkrimi { get; set; }
        [Display(Name = "FotoURL")]
        public Kategori? Kategori { get; set; }
        [ForeignKey("KategoriID")]
        [Display(Name = "Category")]
        public int KategoriID { get; set; }
        public List<Porosi_Detaje>? Porosi_Detajet { get; set; }
        [Display(Name = "Brand")]
        public int MarkaID { get; set; }
        [ForeignKey("MarkaID")]
        public Marka? marka { get; set; }
        public string? Foto { get; set; } = String.Empty;
        [NotMapped]
        [DataType(DataType.Upload)]
        [Display(Name = "Upload Image")]
        [Required]
        public IFormFile ImageFile { get; set; }


    }
}
