using System.ComponentModel.DataAnnotations;
namespace ConnectElectronics.Models
{
    public class EditRole
    {
        public string Id { get; set; }
        [Required]
        [Display(Name = "Role")]
        public string Name { get; set; }
    }
}
