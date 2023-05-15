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
        [Required(ErrorMessage = "Te lutem jepni nje vlere")]
        [DataType(DataType.MultilineText)]
        public string? Emri { get; set; }
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Te lutem jepni nje vlere")]
        [Column(TypeName = "decimal(8, 2)")]
        [ReadOnly(true)]
        public double Cmimi { get; set; }
        [Range(1, Int32.MaxValue, ErrorMessage = "Sasia duhet te jete me e madhe se 0")]
        public int? Sasia { get; set; }
        public bool? Oferte { get; set; }
        public string? Pershkrimi { get; set; }
        [Display(Name = "FotoURL")]
        public Kategori? Kategori { get; set; }
        [ForeignKey("KategoriID")]
        [Display(Name = "Kategoria")]
        public int KategoriID { get; set; }
        public List<Porosi_Detaje>? Porosi_Detajet { get; set; }
        [Display(Name = "Marka")]
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
