using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace TP2Web.FrontEnd.DTO.Auth.Request
{
    public class RegistroRequest
    {
        [Required(ErrorMessage = "El email es Obligatorio.")]
        [EmailAddress(ErrorMessage = "El formato del email no es válido.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "La contraseña es obligatoria.")]
        [MinLength(6, ErrorMessage = "La contraseña debe tener al menos 6 caracteres.")]
        public string Password { get; set; } = string.Empty;

        [Required(ErrorMessage = "Debe confirmar la contraseña.")]
        [Compare("Password", ErrorMessage = "Las contraseñas no coinciden.")]
        public string ConfirmarPassword { get; set; } = string.Empty;

        [Required(ErrorMessage = "Debe seleccionar un rol para el usuario.")]
        public string Rol { get; set; } = string.Empty;
    }

}

