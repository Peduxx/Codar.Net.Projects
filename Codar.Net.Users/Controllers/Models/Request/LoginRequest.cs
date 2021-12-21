using System.ComponentModel.DataAnnotations;

namespace Codar.Net.Users.Controllers.Models.Request
{
    public class LoginRequest
    {
        [EmailAddress(ErrorMessage = "E-mail em formato inválido.")]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }
    }
}