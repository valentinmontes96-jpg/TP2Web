using System.ComponentModel.DataAnnotations;

namespace TP2Web.FrontEnd.Models
{
    public class Veterinario
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre del profesional es obligatorio.")]
        [StringLength(100)]
        public string Nombre { get; set; } = null!;

        [Required(ErrorMessage = "La especialidad es obligatoria.")]
        [StringLength(50)]
        public string Especialidad { get; set; } = null!; // Ej: General, Cirujano, Dermatólogo

        [Required]
        [StringLength(50)]
        public string Matricula { get; set; } = null!;

        // Propiedad de navegación: Un veterinario atiende muchas citas
        public ICollection<Cita> Citas { get; set; } = new List<Cita>();
    }
}

