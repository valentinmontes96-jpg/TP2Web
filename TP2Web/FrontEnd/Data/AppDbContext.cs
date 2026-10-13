using Microsoft.EntityFrameworkCore; 
using TP2Web.FrontEnd.Models;

namespace TP2Web.FrontEnd.Data 
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Cliente> Clientes { get; set; } = null!;
        public DbSet<Mascota> Mascotas { get; set; } = null!;
        public DbSet<Cita> Citas { get; set; } = null!;
        public DbSet<Veterinario> Veterinarios { get; set; } = null!;
        public DbSet<Usuario> Usuarios { get; set; } = null!;
    }
}