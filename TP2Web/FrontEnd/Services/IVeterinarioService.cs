using TP2Web.FrontEnd.DTO.Veterinario.Request;
using TP2Web.FrontEnd.DTO.Veterinario.Response;
using TP2Web.FrontEnd.Models.ModeloAuxiliar;
using TP2Web.FrontEnd.Models;

namespace TP2Web.FrontEnd.Services;

public interface IVeterinarioService
{
    Task<VeterinarioPaginado> ObtenerTodosAsync(VeterinarioQueryParameters parametros);
    Task<VeterinarioResponse> ObtenerPorIdAsync(int id);
    Task CrearAsync(VeterinarioCrear request);
    Task ActualizarAsync(VeterinarioActualizar request);
    Task EliminarAsync(int id);
}