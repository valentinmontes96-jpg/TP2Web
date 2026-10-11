using Microsoft.EntityFrameworkCore;
using TP2Web.FrontEnd.Data; 
using TP2Web.FrontEnd.Excepciones;
using TP2Web.FrontEnd.Models;
using TP2Web.FrontEnd.Models.ModeloAuxiliar;
using TP2Web.FrontEnd.Repositories;
using TP2Web.FrontEnd.DTO.Paginado.Response;

namespace TP2Web.FrontEnd.Repositories
{
    public class MascotaRepository : IMascotaRepository
    {
        private readonly AppDbContext _context;

        public MascotaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<PaginadoResponse<Mascota>> ObtenerTodasAsync(MascotaQueryParametros parametros)
        {
            IQueryable<Mascota> query = _context.Mascotas.AsNoTracking();

            if (!string.IsNullOrWhiteSpace(parametros.Buscar))
            {
                string buscar = parametros.Buscar.ToLower();
                query = query.Where(m => m.Nombre.ToLower().Contains(buscar) ||
                                         m.Especie.ToLower().Contains(buscar));
            }

            bool descendente = parametros.Direccion?.Equals("desc", StringComparison.OrdinalIgnoreCase) == true;
            query = parametros.OrdenarPor?.ToLower() switch
            {
                "nombre" => descendente ? query.OrderByDescending(m => m.Nombre) : query.OrderBy(m => m.Nombre),
                "especie" => descendente ? query.OrderByDescending(m => m.Especie) : query.OrderBy(m => m.Especie),
                _ => descendente ? query.OrderByDescending(m => m.Id) : query.OrderBy(m => m.Id)
            };

            int totalRegistros = await query.CountAsync();
            List<Mascota> mascotas = await query
                .Skip((parametros.PaginaActual - 1) * parametros.TamanoPagina)
                .Take(parametros.TamanoPagina)
                .ToListAsync();

            return new PaginadoResponse<Mascota>(mascotas, parametros.PaginaActual, parametros.TamanoPagina, totalRegistros);
        }
    

    public async Task<Mascota?> ObtenerPorIdAsync(int id)
        {
            return await _context.Mascotas
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);
        }
    }

    public async Task AgregarAsync(Mascota mascota)
        {
            _context.Mascotas.Add(mascota);
        }

        public void Actualizar(Mascota mascota)
        {
            _context.Mascotas.Update(mascota);
        }

        public async Task GuardarCambiosAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new OperacionBaseDeDatosException("Ocurrió un error al intentar guardar los cambios en la base de datos.", ex);
            }
        }
    }