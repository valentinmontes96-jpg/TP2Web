using TP2Web.FrontEnd.DTO.Cliente.Request;
using TP2Web.FrontEnd.DTO.Cliente.Response;

namespace TP2Web.FrontEnd.Services
{
    public interface IClienteService
    {
        Task<IEnumerable<ClienteResponse>> ObtenerTodosAsync();
        Task<ClienteResponse> ObtenerPorIdAsync(int id);
        Task CrearAsync(ClienteCrear request);
        Task ActualizarAsync(ClienteActualizar request);
        Task EliminarAsync(int id);
    }
}
