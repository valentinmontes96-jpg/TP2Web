using Microsoft.EntityFrameworkCore;
using TP2Web.FrontEnd.Data;
using TP2Web.FrontEnd.Models;
using TP2Web.FrontEnd.Models.ModeloAuxiliar;
using TP2Web.FrontEnd.Repositories;


namespace TP2Web.FrontEnd.Implementaciones;

public class CitaRepository : ICitaRepository
{
    private readonly AppDbContext _context;

    public CitaRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<(IEnumerable<Cita> Citas, int TotalRegistros)> ObtenerTodasAsync(CitaQueryParameters parametros)
    {
        var query = _context.Citas
            .Include(c => c.Mascota)
            .Include(c => c.Veterinario)
            .AsQueryable();

        // Filtros
        if (!string.IsNullOrWhiteSpace(parametros.BuscarMotivo))
        {
            query = query.Where(c => c.Motivo.Contains(parametros.BuscarMotivo));
        }

        if (!string.IsNullOrWhiteSpace(parametros.Estado))
        {
            query = query.Where(c => c.Estado == parametros.Estado);
        }

        if (parametros.MascotaId.HasValue)
        {
            query = query.Where(c => c.MascotaId == parametros.MascotaId.Value);
        }

        int totalRegistros = await query.CountAsync();

        var citas = await query
            .Skip((parametros.Pagina - 1) * parametros.CantidadPorPagina)
            .Take(parametros.CantidadPorPagina)
            .ToListAsync();

        return (citas, totalRegistros);
    }

    public async Task<Cita?> ObtenerPorIdAsync(int id)
    {
        return await _context.Citas
            .Include(c => c.Mascota)
            .Include(c => c.Veterinario)
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public void Agregar(Cita cita)
    {
        _context.Citas.Add(cita);
    }

    public void Actualizar(Cita cita)
    {
        _context.Citas.Update(cita);
    }

    public void Eliminar(Cita cita)
    {
        _context.Citas.Remove(cita);
    }

    public async Task GuardarCambiosAsync()
    {
        await _context.SaveChangesAsync();
    }
}