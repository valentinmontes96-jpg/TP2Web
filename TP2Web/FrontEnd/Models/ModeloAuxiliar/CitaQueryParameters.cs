namespace TP2Web.FrontEnd.Models.ModeloAuxiliar
{
    public class CitaQueryParameters
    {
        public string? BuscarMotivo { get; set; }
        public string? Estado { get; set; }
        public int? MascotaId { get; set; } // Útil para ver el historial de turnos de un animal específico

        public int Pagina { get; set; } = 1;
        public int CantidadPorPagina { get; set; } = 10;
    }
}
