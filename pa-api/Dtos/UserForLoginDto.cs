using System.ComponentModel.DataAnnotations;

namespace pa_api.Dtos
{
    public class UserForLoginDto
    {
        [Required]
        public string Username { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 4, ErrorMessage = "A senha deve conter no minimo 4-30 caracteres!!!!")]
        public string Password { get; set; }
    }
}