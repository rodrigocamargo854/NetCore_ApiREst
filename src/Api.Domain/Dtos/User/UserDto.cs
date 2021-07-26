using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Dtos
{
    public class UserDto
    {
        [Required(ErrorMessage = "Nome é um campo obrigatorio")]
        [StringLength(60, ErrorMessage = "Nome deve ter no maximo {1} caracteres")]


        public string Name { get; set; }

        [Required(ErrorMessage = "Nome é um campo obrigatorio")]
        [EmailAddress(ErrorMessage = "Email com formato invalido")]
        [StringLength(100, ErrorMessage = "Nome deve ter no maximo {1} caracteres")]
        public int Email { get; set; }
    }
}
