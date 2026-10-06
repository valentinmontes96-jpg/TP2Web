using System.ComponentModel.DataAnnotations;

namespace TP2Web.FrontEnd.Models
{
    public class Cita
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Fecha y hora obligatorias.")]
        public DateTime FechaHora { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "El motivo de la cita es obligatorio.")]
        [StringLength(200)]
        public string Motivo { get; set; } = null!;

        [Required]
        [StringLength(20)]
        public string Estado { get; set; } = "Pendiente"; //Pendiente, Atendido, Cancelado

        //FK
        [Required(ErrorMessage = "Tenés que seleccionar una mascota.")]
        public int MascotaId { get; set; }

        //Propiedad de navegación: Una cita pertenece a una sola mascota
        public Mascota Mascota { get; set; } = null!;

        [Required(ErrorMessage = "Debe asignar un veterinario al turno.")]
        public int VeterinarioId { get; set; }

        // Propiedad de navegación
        public Veterinario Veterinario { get; set; } = null!;


    }
}
