using TP2Web.FrontEnd.DTO.Cita.Response;

namespace TP2Web.FrontEnd.DTO.Cita.Request
{
    public class CitaPaginado
    {
        public IEnumerable<CitaResponse> Citas { get; set; } = new List<CitaResponse>();
        public int TotalRegistros { get; set; }
    }
}
