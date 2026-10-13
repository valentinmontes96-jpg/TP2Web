using TP2Web.FrontEnd.Models;
using TP2Web.FrontEnd.Models.ModeloAuxiliar;

namespace TP2Web.FrontEnd.Repositories
{
    public interface ICitaRepository
    {
        Task<(IEnumerable<Cita> Citas, int TotalRegistros)> ObtenerTodasAsync(CitaQueryParameters parametros);
        Task<Cita?> ObtenerPorIdAsync(int id);
        void Agregar(Cita cita);
        void Actualizar(Cita cita);
        void Eliminar(Cita cita);
        Task GuardarCambiosAsync();
    }
}
