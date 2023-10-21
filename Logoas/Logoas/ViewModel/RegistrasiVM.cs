using System.ComponentModel.DataAnnotations;

namespace Logoas.ViewModel
{
    public class RegistrasiVM
    {
        [Display(Name = "Member NIK")]
        public string NIK { get; set; }
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "PhoneNumber")]
        public string PhoneNumber { get; set; }
        [Display(Name = "Addres")]
        public string Address { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
