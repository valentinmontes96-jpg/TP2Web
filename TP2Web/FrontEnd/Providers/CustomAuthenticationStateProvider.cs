using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace TP2Web.FrontEnd.Providers
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly IJSRuntime _jsRuntime;
        private readonly string _tokenKey = "jwt_token";

        // Esta variable guarda la sesión para no tener que leer el localStorage a cada rato
        private ClaimsPrincipal _usuarioEnMemoria;

        public CustomAuthenticationStateProvider(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            // 1. Si ya lo tenemos en memoria, lo devolvemos rápido y evitamos errores de JS
            if (_usuarioEnMemoria != null)
                return new AuthenticationState(_usuarioEnMemoria);

            try
            {
                // 2. Si no está en memoria, intentamos buscarlo en el navegador
                var token = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", _tokenKey);

                if (string.IsNullOrEmpty(token))
                    return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));

                var handler = new JwtSecurityTokenHandler();
                var jwtToken = handler.ReadJwtToken(token);

                if (jwtToken.ValidTo < DateTime.UtcNow)
                    return await MarcarUsuarioComoDesconectado();

                var identity = new ClaimsIdentity(jwtToken.Claims, "jwt");
                _usuarioEnMemoria = new ClaimsPrincipal(identity); // Lo guardamos en memoria

                return new AuthenticationState(_usuarioEnMemoria);
            }
            catch (Exception)
            {
                return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
            }
        }

        public void MarcarUsuarioComoAutenticado(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var jwtToken = handler.ReadJwtToken(token);
            var identity = new ClaimsIdentity(jwtToken.Claims, "jwt");

            _usuarioEnMemoria = new ClaimsPrincipal(identity); // Guardamos en memoria

            var authState = Task.FromResult(new AuthenticationState(_usuarioEnMemoria));
            NotifyAuthenticationStateChanged(authState);
        }

        public async Task InicializarEstadoInteractividadAsync()
        {
            try
            {
                var token = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", _tokenKey);
                if (!string.IsNullOrEmpty(token))
                {
                    var handler = new JwtSecurityTokenHandler();
                    var jwtToken = handler.ReadJwtToken(token);

                    if (jwtToken.ValidTo > DateTime.UtcNow)
                    {
                        var identity = new ClaimsIdentity(jwtToken.Claims, "jwt");
                        _usuarioEnMemoria = new ClaimsPrincipal(identity); // Asigna la memoria

                        var authState = Task.FromResult(new AuthenticationState(_usuarioEnMemoria));
                        NotifyAuthenticationStateChanged(authState);
                    }
                }
            }
            catch { /* Ignoramos errores si se llama prematuramente */ }
        }


        public async Task<AuthenticationState> MarcarUsuarioComoDesconectado()
        {
            _usuarioEnMemoria = null; // Limpiamos la memoria

            try
            {
                await _jsRuntime.InvokeVoidAsync("localStorage.removeItem", _tokenKey);
            }
            catch { /* Ignoramos si falla por pre-renderizado */ }

            var estadoAnonimo = new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
            NotifyAuthenticationStateChanged(Task.FromResult(estadoAnonimo));

            return estadoAnonimo;
        }
    }
}