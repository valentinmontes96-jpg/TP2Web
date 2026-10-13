namespace TP2Web.FrontEnd.Models.ModeloAuxiliar
{
    public class ClienteQueryParameters
    {
        public string? BuscarNombre { get; set; }
        public string? BuscarEmail { get; set; }

        // Paginación por defecto
        public int Pagina { get; set; } = 1;
        public int CantidadPorPagina { get; set; } = 10;
    }
}
