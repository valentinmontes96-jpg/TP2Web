using TP2Web.FrontEnd.Models;
using TP2Web.FrontEnd.Models.ModeloAuxiliar;

namespace TP2Web.FrontEnd.Repositories;

public interface IVeterinarioRepository
{
    // Devolvemos la tupla con la lista y el total para la paginación
    Task<(IEnumerable<Veterinario> Veterinarios, int TotalRegistros)> ObtenerTodosAsync(VeterinarioQueryParameters parametros);
    Task<Veterinario?> ObtenerPorIdAsync(int id);
    void Agregar(Veterinario veterinario);
    void Actualizar(Veterinario veterinario);
    void Eliminar(Veterinario veterinario);
    Task GuardarCambiosAsync();
}