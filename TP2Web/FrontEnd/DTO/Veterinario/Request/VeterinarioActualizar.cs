using System.ComponentModel.DataAnnotations;

namespace TP2Web.FrontEnd.DTO.Veterinario.Request
{
    public class VeterinarioActualizar
    {
        public string Nombre { get; set; } = string.Empty;
        public string Especialidad { get; set; } = string.Empty;
        public string Matricula { get; set; } = string.Empty;

    }
}
