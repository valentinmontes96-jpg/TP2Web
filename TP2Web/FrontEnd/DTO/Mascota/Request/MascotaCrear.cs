using System.ComponentModel.DataAnnotations;

namespace TP2Web.FrontEnd.DTO.Mascota.Request
{
    public class MascotaCrear
    {
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [MaxLength(50)]
        public string Nombre { get; set; } = string.Empty;

        [Required]
        public string Especie { get; set; } = string.Empty; 
    }
}
