using System.ComponentModel.DataAnnotations;

namespace TP2Web.FrontEnd.Models
{
    public class Mascota
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre de la mascota es obligatorio")]
        [StringLength(100)]
        public string Nombre { get; set; } = null!;

        [Required(ErrorMessage = "La especie es obligatoria (ej: Perro,Gato")]
        [StringLength(100)]
        public string Especie { get; set; } = null!;

        //FK
        [Required(ErrorMessage = "El cliente es obligatorio")]
        public int ClienteId { get; set; }

        //Propiedad de navegacion, una mascota debe ser de un solo cliente
        public Cliente Cliente { get; set; } = null!;

        //Propiedad de navegacion, una mascota que pueda tener mas de una cita
        public ICollection<Cita> Citas { get; set; } = new List<Cita>();
    }
}
