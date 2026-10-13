using TP2Web.FrontEnd.Models;

namespace TP2Web.FrontEnd.Repositories
{
    public interface IUsuarioRepository
    {
        Task<Usuario?> ObtenerPorEmailAsync(string email);
        void Agregar(Usuario usuario);
        Task GuardarCambiosAsync();
    }
}
