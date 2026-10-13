namespace TP2Web.FrontEnd.DTO.Cita.Request
{
    public class CitaActualizar
    {
        public int Id { get; set; }
        public DateTime FechaHora { get; set; }
        public string Motivo { get; set; } = string.Empty;
        public string Estado { get; set; } = string.Empty;
        public int MascotaId { get; set; }
        public int VeterinarioId { get; set; }

    }
}
