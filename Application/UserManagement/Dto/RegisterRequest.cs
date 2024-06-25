using System.ComponentModel.DataAnnotations;

namespace LoginTestAPI.Models.Domain
{
    public class RegisterRequest
    {
        [Required(ErrorMessage = "Email is required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string PfNumber { get; set; }
        public string FullName { get; set; }
        public string Gender { get; set; }
    }
}
