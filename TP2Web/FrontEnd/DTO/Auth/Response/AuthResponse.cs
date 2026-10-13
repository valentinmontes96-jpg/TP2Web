namespace TP2Web.FrontEnd.DTO.Auth.Response
{
    public class AuthResponse
    {
        public bool Exito { get; set; }
        public string Token { get; set; } = string.Empty;
        public string Mensaje { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Rol { get; set; } = string.Empty;
    }
}
