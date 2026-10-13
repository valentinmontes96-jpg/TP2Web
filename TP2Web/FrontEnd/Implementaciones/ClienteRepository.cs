using Microsoft.EntityFrameworkCore;
using TP2Web.FrontEnd.Data;
using TP2Web.FrontEnd.Models;
using TP2Web.FrontEnd.Models.ModeloAuxiliar;
using TP2Web.FrontEnd.Repositories;


namespace TP2Web.FrontEnd.Implementaciones
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly AppDbContext _context;

        public ClienteRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Cliente>> ObtenerTodosAsync(ClienteQueryParameters parametros)
        {
            var query = _context.Clientes.AsQueryable();

            if (!string.IsNullOrWhiteSpace(parametros.BuscarNombre))
            {
                query = query.Where(c => c.Nombre.Contains(parametros.BuscarNombre));
            }

            if (!string.IsNullOrWhiteSpace(parametros.BuscarEmail))
            {
                query = query.Where(c => c.Email.Contains(parametros.BuscarEmail));
            }

            return await query
                .Skip((parametros.Pagina - 1) * parametros.CantidadPorPagina)
                .Take(parametros.CantidadPorPagina)
                .ToListAsync();
        }

        public async Task<Cliente?> ObtenerPorIdAsync(int id)
        {
            return await _context.Clientes.FindAsync(id);
        }

        public void Agregar(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
        }

        public void Actualizar(Cliente cliente)
        {
            _context.Clientes.Update(cliente);
        }

        public void Eliminar(Cliente cliente)
        {
            _context.Clientes.Remove(cliente);
        }

        public async Task GuardarCambiosAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
