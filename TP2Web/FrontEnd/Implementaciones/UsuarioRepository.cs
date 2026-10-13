using Microsoft.EntityFrameworkCore;
using TP2Web.FrontEnd.Data;
using TP2Web.FrontEnd.Models;
using TP2Web.FrontEnd.Repositories;

namespace TP2Web.FrontEnd.Implementaciones
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly AppDbContext _context;

        public UsuarioRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Usuario?> ObtenerPorEmailAsync(string email)
        {
            // Busca si el usuario ya existe ignorando mayúsculas/minúsculas
            return await _context.Usuarios.FirstOrDefaultAsync(u => u.Email.ToLower() == email.ToLower());
        }

        public void Agregar(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
        }

        public async Task GuardarCambiosAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
