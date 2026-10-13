using Microsoft.EntityFrameworkCore;
using TP2Web.FrontEnd.DTO.Paginado.Response;
using TP2Web.FrontEnd.Models;
using TP2Web.FrontEnd.Models.ModeloAuxiliar;
using TP2Web.FrontEnd.Excepciones;


namespace TP2Web.FrontEnd.Repositories
{
    public interface IMascotaRepository
    {
        Task<PaginadoResponse<Mascota>> ObtenerTodasAsync(MascotaQueryParameters parametros);
        Task<Mascota?> ObtenerPorIdAsync(int id);
        Task AgregarAsync(Mascota mascota);
        public void Actualizar(Mascota mascota);
        void Eliminar(Mascota mascota);
        Task GuardarCambiosAsync();
        
    }
}
