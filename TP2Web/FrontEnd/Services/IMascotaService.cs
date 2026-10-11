using TP2Web.FrontEnd.DTO.Mascota.Request;
using TP2Web.FrontEnd.DTO.Mascota.Response;
using TP2Web.FrontEnd.DTO.Paginado.Response;

namespace TP2Web.FrontEnd.Services
{
    public interface IMascotaService
    {
        Task<PaginadoResponse<MascotaResponse>> ObtenerTodasAsync(MascotaPaginado request);
        Task<MascotaResponse?> ObtenerPorIdAsync(int id);
        Task CrearAsync(MascotaCrear request);
        Task ActualizarAsync(MascotaActualizar request);
        Task GuardarCambiosAsync();

    }
}
