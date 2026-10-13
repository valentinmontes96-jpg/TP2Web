using TP2Web.FrontEnd.Models;
using TP2Web.FrontEnd.Models.ModeloAuxiliar;

namespace TP2Web.FrontEnd.Repositories
{
    public interface IClienteRepository
    {
        Task<IEnumerable<Cliente>> ObtenerTodosAsync(ClienteQueryParameters parametros);
        Task<Cliente?> ObtenerPorIdAsync(int id);
        void Agregar(Cliente cliente);
        void Actualizar(Cliente cliente);
        void Eliminar(Cliente cliente);
        Task GuardarCambiosAsync();
    }
}
