using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Dtos
{
    public class LoginDto
    {
        //? faz o email ser obrigatorio

        [Required(ErrorMessage = "EMail é obrigatorio para login")]
        [EmailAddress(ErrorMessage = "Email em formato inválido")]
        [StringLength(100, ErrorMessage = "EMail deve ter no máximo {1} caracteres")]

        public string Email { get; set; }
    }
}
