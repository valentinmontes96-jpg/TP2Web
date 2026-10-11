namespace TP2Web.FrontEnd.DTO.Mascota.Request
{
    public class MascotaPaginado
    {
        public int NumeroPagina { get; set; } = 1;
        public int TamanoPagina { get; set; } = 10;
        public string? Buscar { get; set; }
        public string? OrdenarPor { get; set; }
        public string? Direccion { get; set; } // "asc" o "desc"

        // Filtros específicos que el usuario puede aplicar en la pantalla
        public string? Especie { get; set; }
    }
}
