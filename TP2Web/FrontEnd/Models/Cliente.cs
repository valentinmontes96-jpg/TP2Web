using System.ComponentModel.DataAnnotations;

namespace TP2Web.FrontEnd.Models
{
    public class Cliente
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength (100)]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El teléfono es obligatorio.")]
        [StringLength(20)]
        public string Telefono { get; set; } = null!;

        [EmailAddress(ErrorMessage = "Formato de correo electrónico inválido.")]
        [StringLength(100)]
        public string? Email { get; set; }

        //Un cliente que pueda tener muchas mascotas. .
        public ICollection<Mascota> Mascotas { get; set; } = new List<Mascota>();
    }
}
