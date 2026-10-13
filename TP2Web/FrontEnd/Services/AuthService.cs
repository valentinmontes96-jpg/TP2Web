using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TP2Web.FrontEnd.DTO.Auth.Request;
using TP2Web.FrontEnd.DTO.Auth.Response;
using TP2Web.FrontEnd.DTO.Auth;
using TP2Web.FrontEnd.Models;
using TP2Web.FrontEnd.Repositories;

namespace TP2Web.FrontEnd.Services;

public class AuthService : IAuthService
{
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly IConfiguration _config;

    public AuthService(IUsuarioRepository usuarioRepository, IConfiguration config)
    {
        _usuarioRepository = usuarioRepository;
        _config = config;
    }

    public async Task<AuthResponse> RegistroAsync(RegistroRequest request)
    {
        // Verificamos que el email no esté en uso
        var existe = await _usuarioRepository.ObtenerPorEmailAsync(request.Email);
        if (existe != null)
            return new AuthResponse { Exito = false, Mensaje = "El email ya está registrado." };

        // Creamos el usuario encriptando la contraseña con BCrypt
        var usuario = new Usuario
        {
            Email = request.Email,
            Rol = request.Rol,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password)
        };

        _usuarioRepository.Agregar(usuario);
        await _usuarioRepository.GuardarCambiosAsync();

        return new AuthResponse { Exito = true, Mensaje = "Usuario registrado exitosamente." };
    }

    public async Task<AuthResponse> LoginAsync(LoginRequest request)
    {
        // Buscamos el usuario por email
        var usuario = await _usuarioRepository.ObtenerPorEmailAsync(request.Email);

        // Si no existe o la contraseña no coincide (BCrypt la verifica automáticamente)
        if (usuario == null || !BCrypt.Net.BCrypt.Verify(request.Password, usuario.PasswordHash))
            return new AuthResponse { Exito = false, Mensaje = "Credenciales incorrectas." };

        // Si todo está bien, generamos el Token
        var token = GenerarTokenJWT(usuario);

        return new AuthResponse
        {
            Exito = true,
            Token = token,
            Email = usuario.Email,
            Rol = usuario.Rol,
            Mensaje = "Login exitoso."
        };
    }

    private string GenerarTokenJWT(Usuario usuario)
    {
        // Leemos la clave secreta desde la configuración (secrets.json)
        // Agregué un valor de respaldo temporal por si todavía no lo configuramos
        var key = Encoding.UTF8.GetBytes(_config["JwtSettings:SecretKey"] ?? "ClaveSuperSecretaTemporalParaDesarrollo123456!");

        // Los "Claims" son los datos que viajan dentro del token
        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
            new Claim(ClaimTypes.Email, usuario.Email),
            new Claim(ClaimTypes.Role, usuario.Rol)
        };

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddHours(2), // El token dura 2 horas
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }
}