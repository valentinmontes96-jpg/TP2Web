using Microsoft.EntityFrameworkCore;
using TP2Web.FrontEnd.DTO.Paginado.Response;
using TP2Web.FrontEnd.Models;
using TP2Web.FrontEnd.Models.ModeloAuxiliar;
using TP2Web.FrontEnd.Excepciones;

namespace TP2Web.FrontEnd.Repositories
{
    public interface IMascotaRepository
    {
        Task<PaginadoResponse<Mascota>> ObtenerTodasAsync(MascotaQueryParametros parametros);
        Task<Mascota?> ObtenerPorIdAsync(int id);
        Task AgregarAsync(Mascota mascota);
        public async Task GuardarCambiosAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Atrapamos cualquier error de EF y lo envolvemos en tu excepción personalizada
                throw new BaseDeDatosException("Ocurrió un error al intentar guardar los cambios en la base de datos.", ex);
            }
        }
    }
}
