namespace TP2Web.FrontEnd.Excepciones
{
    public class CredencialesInvalidasException : Exception
    {
        public CredencialesInvalidasException() : base("El usuario o la contraseña son incorrectas.")
        {
        }
    }
}
