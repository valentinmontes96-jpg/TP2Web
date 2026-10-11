namespace TP2Web.FrontEnd.Excepciones
{
    public class RegistroNoEncontradoException : Exception
    {
        public RegistroNoEncontradoException(string mensaje) : base(mensaje)
        {
        }

        public RegistroNoEncontradoException(string nombreEntidad, int id)
            : base($"No se encontró el registro de {nombreEntidad} con el Id {id}.")
        {
        }
    }
}
