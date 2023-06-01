
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConnectElectronics.Models
{
    public class Porosi
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required, Display(Name = "Id e Klientit")]
        public string KlientId { get; set; }
        [Display(Name = "UserName i Klientit")]
        public string KlientUserName { get; set; }
        [Required(ErrorMessage = "Vendosni Emri")]
        [StringLength(maximumLength: 50, MinimumLength = 2)]
        public string Emri { get; set; }
        [Required(ErrorMessage = "Vendosni Mbiemri")]
        public string Mbiemri { get; set; }
        [Required]
        public string Adresa { get; set; }
        [Required]
        public string Qyteti { get; set; }
        [Required(ErrorMessage = "Vendosni numer telefoni")]
        [Phone]
        [Display(Name = "Numri i Kontaktit")]
        public string NumerKontakti { get; set; }
        [Display(Name = "Ora dhe Data e Porosise")]
        public DateTime DataPorosis { get; set; }
        [DataType(DataType.MultilineText)]
        public string? Shenime { get; set; }
        public List<Porosi_Detaje>? Porosi_Detajet { get; set; }
        [Display(Name = "Shuma e harxhuar")]
        public double ShumaT { get; set; }
        //shuma totale e porosise
    }
}