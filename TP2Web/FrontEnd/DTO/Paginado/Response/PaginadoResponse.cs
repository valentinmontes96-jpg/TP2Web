namespace TP2Web.FrontEnd.DTO.Paginado.Response
{
    public class PaginadoResponse<T>
    {
        public List<T> Items { get; set; } = new List<T>();
        public int PaginaActual { get; set; }
        public int TamanoPagina { get; set; }
        public int TotalRegistros { get; set; }

        // Calcula automáticamente el total de páginas necesarias
        public int TotalPaginas => (int)Math.Ceiling((double)TotalRegistros / TamanoPagina);
    }
}
