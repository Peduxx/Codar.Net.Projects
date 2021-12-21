using System.ComponentModel.DataAnnotations;

namespace Codar.Net.Users.Controllers.Models.Request
{
    public class UserRequest
    {
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "E-mail em formato inválido.")]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Age is required.")]
        public int Age { get; set; }
    }
}
