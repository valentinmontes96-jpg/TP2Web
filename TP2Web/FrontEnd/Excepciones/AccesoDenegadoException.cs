namespace TP2Web.FrontEnd.Excepciones
{
    public class AccesoDenegadoException : Exception
    {
        public AccesoDenegadoException() : base("No tenes permisos para realizar ésta acción.")
        {
        }

        public AccesoDenegadoException(string mensaje) : base(mensaje)
        {
        }
    }
}
