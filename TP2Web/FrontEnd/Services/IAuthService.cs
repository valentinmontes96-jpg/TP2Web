using TP2Web.FrontEnd.DTO.Auth.Request;
using TP2Web.FrontEnd.DTO.Auth.Response;

namespace TP2Web.FrontEnd.Services
{
    public interface IAuthService
    {
        Task<AuthResponse> RegistroAsync(RegistroRequest request);
        Task<AuthResponse> LoginAsync(LoginRequest request);
    }
}
