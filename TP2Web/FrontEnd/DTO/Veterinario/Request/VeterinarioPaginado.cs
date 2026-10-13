using TP2Web.FrontEnd.DTO.Veterinario.Response;

namespace TP2Web.FrontEnd.DTO.Veterinario.Request
{
    public class VeterinarioPaginado
    {
        public IEnumerable<VeterinarioResponse> Veterinarios { get; set; } = new List<VeterinarioResponse>();
        public int TotalRegistros { get; set; }
    }
}
