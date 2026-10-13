namespace TP2Web.FrontEnd.DTO.Cita.Response
{
    public class CitaResponse
    {
        public int Id { get; set; }
        public DateTime FechaHora { get; set; }
        public string Motivo { get; set; } = string.Empty;
        public string Estado { get; set; } = string.Empty;

        
        public int MascotaId { get; set; }
        public int VeterinarioId { get; set; }

        
        public string NombreMascota { get; set; } = string.Empty;
        public string NombreVeterinario { get; set; } = string.Empty;
    }
}
