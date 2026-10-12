namespace TP2Web.FrontEnd.Excepciones
{
    public class BaseDeDatosException : Exception
    {
        public BaseDeDatosException(string mensaje) : base(mensaje)
        {
        }

        public BaseDeDatosException(string mensaje, Exception excInterna)
            : base (mensaje, excInterna)
        {
        }
    }
}
