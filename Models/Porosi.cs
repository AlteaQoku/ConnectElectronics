
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConnectElectronics.Models
{
    public class Porosi
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required, Display(Name = "Client ID")]
        public string KlientId { get; set; }
        [Display(Name = "Client Username")]
        public string KlientUserName { get; set; }
        [Required(ErrorMessage = "Vendosni Emri")]
        [StringLength(maximumLength: 50, MinimumLength = 2)]
        [Display(Name = "Name")]
        public string Emri { get; set; }
        [Required(ErrorMessage = "Vendosni Mbiemri")]
        [Display(Name = "Surname")]
        public string Mbiemri { get; set; }
        [Required]
        [Display(Name = "Address")]
        public string Adresa { get; set; }
        [Required]
        [Display(Name = "City")]
        public string Qyteti { get; set; }
        [Required(ErrorMessage = "Vendosni numer telefoni")]
        [Phone]
        [Display(Name = "Phone Number")]
        public string NumerKontakti { get; set; }
        [Display(Name = "Date & Time")]
        public DateTime DataPorosis { get; set; }
        [DataType(DataType.MultilineText)]
        [Display(Name = "Note")]
        public string? Shenime { get; set; }
        public List<Porosi_Detaje>? Porosi_Detajet { get; set; }
        [Display(Name = "Total Sum")]
        public double ShumaT { get; set; }
        //shuma totale e porosise
    }
}