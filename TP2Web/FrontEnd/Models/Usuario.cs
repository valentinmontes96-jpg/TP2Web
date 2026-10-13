using System.ComponentModel.DataAnnotations;

namespace TP2Web.FrontEnd.Models
{
    public class Usuario
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string PasswordHash { get; set; } = string.Empty;

        [Required(ErrorMessage = "Debe seleccionar un rol para el usuario.")]
        [StringLength(20)]
        public string Rol { get; set; } = string.Empty;
    }
}
