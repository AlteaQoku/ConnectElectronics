using System.ComponentModel.DataAnnotations;
namespace ConnectElectronics.Models.ViewModels
{
    public class RoleViewModel
    {
        [Required]
        [Display(Name = "Role")]
        public string Name { get; set; }
    }
}
