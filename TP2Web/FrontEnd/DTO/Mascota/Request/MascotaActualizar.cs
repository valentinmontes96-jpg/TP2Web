using System.ComponentModel.DataAnnotations;

namespace TP2Web.FrontEnd.DTO.Mascota.Request
{
    public class MascotaActualizar
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Nombre { get; set; } = string.Empty;
        [Required(ErrorMessage = "La especie es obligatoria")]
        public string Especie { get; set; } = string.Empty;
    }
}
