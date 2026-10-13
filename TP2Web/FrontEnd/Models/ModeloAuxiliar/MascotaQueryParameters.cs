namespace TP2Web.FrontEnd.Models.ModeloAuxiliar
{
    public class MascotaQueryParameters
    {
        public int PaginaActual { get; set; } = 1;
        public int TamanoPagina { get; set; } = 10;
        public string? Buscar { get; set; }
        public string? OrdenarPor { get; set; }
        public string? Direccion { get; set; } // "asc" o "desc"
    }
}
