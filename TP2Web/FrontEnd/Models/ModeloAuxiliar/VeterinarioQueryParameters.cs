namespace TP2Web.FrontEnd.Models.ModeloAuxiliar
{
    public class VeterinarioQueryParameters
    {
        public string? BuscarNombre { get; set; }
        public string? BuscarEspecialidad { get; set; }
        public string? BuscarMatricula { get; set; }

        public int Pagina { get; set; } = 1;
        public int CantidadPorPagina { get; set; } = 10;
    }
}
