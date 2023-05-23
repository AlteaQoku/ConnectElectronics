using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ConnectElectronics.Models
{
    public class ApplicationUser : IdentityUser
    {
        //[Required]
        //[DisplayName("Emri")]
        //[StringLength(30,MinimumLength =3)]
        public string? FirstName { get; set; }

        //[Required]
        //[DisplayName("Mbiemri")]
        //[StringLength(30,MinimumLength =3)]
        public string? LastName { get; set; }

        //[Required]
        //[DisplayName("Ditelindja")]
        // [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }

       // [Required]
       // [DisplayName("Numri i Kontaktit")]
        public string? PhoneNumber { get; set; }

        //[Required]
       // [DisplayName("Qyteti")]
        public string? City { get; set; }
        
        //[Required]
        //[DisplayName("Rruga")]
        public string? Street { get; set; }

        //[Required]
        //[DisplayName("Kodi Postar")]
        public int PostalNumber { get; set; }

        
       // [DisplayName("Nr_Shtepise")]
        public int HouseNr { get; set; }

    }
}
