using Microsoft.EntityFrameworkCore;
using TP2Web.FrontEnd.Data;
using TP2Web.FrontEnd.Models;
using TP2Web.FrontEnd.Models.ModeloAuxiliar;
using TP2Web.FrontEnd.Repositories;

namespace TP2Web.FrontEnd.Implementaciones;

public class VeterinarioRepository : IVeterinarioRepository
{
    private readonly AppDbContext _context;

    public VeterinarioRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<(IEnumerable<Veterinario> Veterinarios, int TotalRegistros)> ObtenerTodosAsync(VeterinarioQueryParameters parametros)
    {
        var query = _context.Veterinarios.AsQueryable();


        if (!string.IsNullOrWhiteSpace(parametros.BuscarNombre))
        {
            query = query.Where(v => v.Nombre.Contains(parametros.BuscarNombre));
        }

        if (!string.IsNullOrWhiteSpace(parametros.BuscarEspecialidad))
        {
            query = query.Where(v => v.Especialidad.Contains(parametros.BuscarEspecialidad));
        }

        if (!string.IsNullOrWhiteSpace(parametros.BuscarMatricula))
        {
            query = query.Where(v => v.Matricula.Contains(parametros.BuscarMatricula));
        }
        
        int totalRegistros = await query.CountAsync();

        var veterinarios = await query
            .Skip((parametros.Pagina - 1) * parametros.CantidadPorPagina)
            .Take(parametros.CantidadPorPagina)
            .ToListAsync();

        return (veterinarios, totalRegistros);
    }

    public async Task<Veterinario?> ObtenerPorIdAsync(int id)
    {
        return await _context.Veterinarios.FirstOrDefaultAsync(v => v.Id == id);
    }

    public void Agregar(Veterinario veterinario)
    {
        _context.Veterinarios.Add(veterinario);
    }

    public void Actualizar(Veterinario veterinario)
    {
        _context.Veterinarios.Update(veterinario);
    }

    public void Eliminar(Veterinario veterinario)
    {
        _context.Veterinarios.Remove(veterinario);
    }

    public async Task GuardarCambiosAsync()
    {
        await _context.SaveChangesAsync();
    }
}