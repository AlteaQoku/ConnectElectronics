using System.ComponentModel.DataAnnotations;

namespace ConnectElectronics.Models
{
    public class EditViewModel
    {

        public EditViewModel()
        {
            Claims = new List<string>();
            Roles = new List<string>();
        }

        public string Id { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public DateTime BirthDate { get; set; }
        public string Qyteti { get; set; }

        public List<string> Claims { get; set; }

        public IList<string> Roles { get; set; }
    }
}