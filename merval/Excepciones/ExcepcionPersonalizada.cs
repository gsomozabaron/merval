using merval.Excepciones;

namespace merval.Excepciones
{
    public class ExcepcionPersonalizada : Exception
    {
        Object objetoError;
        public ExcepcionPersonalizada(string mensaje , Object objetoError): base(mensaje) 
        { 
            this.objetoError = objetoError;
        }

        public ExcepcionPersonalizada(string mensaje) : base(mensaje)
        {

        }

        public Object Error
        {
            get { return objetoError; }
        }



        public static void ejemplo()
        {
            try
            {
                //validacion
            }
            catch (ExcepcionPersonalizada ex)
            {
                Vm.VentanaMensajeError(ex.Error.ToString()); //donde error es el objeto que disparo la excepcion
            }
        }
    }
}
