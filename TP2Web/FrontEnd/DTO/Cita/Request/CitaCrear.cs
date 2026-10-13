namespace TP2Web.FrontEnd.DTO.Cita.Request
{
    public class CitaCrear
    {
        public DateTime FechaHora { get; set; } = DateTime.Now;
        public string Motivo { get; set; } = string.Empty;
        public string Estado { get; set; } = "Pendiente";
        public int MascotaId { get; set; }
        public int VeterinarioId { get; set; }
    }
}
