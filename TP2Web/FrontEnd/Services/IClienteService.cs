using TP2Web.FrontEnd.DTO.Cliente.Request;
using TP2Web.FrontEnd.DTO.Cliente.Response;
using TP2Web.FrontEnd.Models.ModeloAuxiliar;

namespace TP2Web.FrontEnd.Services
{
    public interface IClienteService
    {
        Task<IEnumerable<ClienteResponse>> ObtenerTodosAsync(ClienteQueryParameters parametros);
        Task<ClienteResponse> ObtenerPorIdAsync(int id);
        Task CrearAsync(ClienteCrear request);
        Task ActualizarAsync(ClienteActualizar request);
        Task EliminarAsync(int id);
    }
}
