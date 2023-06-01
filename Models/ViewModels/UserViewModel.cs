using System.ComponentModel.DataAnnotations;
namespace ConnectElectronics.Models.ViewModels
{
    public class UserViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime Birthday { get; set; }

        public string City { get; set; }

        public string Role { get; set; }
    }
}
