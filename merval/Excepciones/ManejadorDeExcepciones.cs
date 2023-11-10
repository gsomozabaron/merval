using merval.entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace merval.Excepciones
{
    public class ManejadorDeExcepciones
    {

        //ManejadorDeExcepciones.ManejarExcepcion(form, () => 
        //    {});

        public static void ManejarExcepcion(string formName, Action codigo)
        {
            //catch (Exception)//captura el error en las validaciones
            //{
            //    Vm.VentanaMensajeError("los precios ingresados no son validos.");
            //}
            //catch (Exception)//captura error si no se puede grabar el xml 
            //{
            //    Vm.VentanaMensajeError("No se pudo grabar el Archivo");
            //}

            string mensaje;
            try
            {
                codigo.Invoke();
            }


            catch (NullReferenceException ex)
            {
                mensaje = "variable es null: ";
                CrearErrorLog(formName, ex, mensaje);
            }

            catch (OverflowException ex)
            {
                mensaje = "dato fuera de rango: ";
                CrearErrorLog(formName, ex, mensaje);
            }


            catch (DivideByZeroException ex)
            {
                mensaje = "Excepción de división por cero: ";
                CrearErrorLog(formName, ex, mensaje);
            }


            catch (FormatException ex)
            {
                mensaje = "Formato de dato erroneo: ";
                CrearErrorLog(formName, ex, mensaje);
            }


            catch (Exception ex)
            {
                mensaje = "inesperado informar a sistemas: ";
                CrearErrorLog(formName, ex, mensaje);
            }







            finally
            {

            }
        }
        private static void CrearErrorLog(string formName, Exception ex, string mensaje)
        {
            var errorLog = new LogError(ex, mensaje, formName);



            Vm.VentanaMensajeError(mensaje);
            ////////grabar log//////////////
            ///RegistrarError(errorLog)
            RegistrarError(errorLog);
            Vm.VentanaMensajeError($"{errorLog.Message},{errorLog.MethodName},{errorLog.fecha}");
        }

        private static string GenerarStringErrores(LogError errorLog)   //si hacemos sb
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(errorLog.Message);
            sb.Append(errorLog.MethodName);
            sb.Append(errorLog.fecha);

            return sb.ToString();
        }

        private static void RegistrarError(LogError errorLog)   //o guardamos lista de errores
        {
            string datosErrror = GenerarStringErrores(errorLog);
            List<string> listaErrores = new List<string>(); //crear archivo
            listaErrores.Add(datosErrror);




            // Aquí puedes implementar la lógica para registrar el error en un archivo de registro,
            // base de datos, etc.
            // Por ejemplo, escribir el error en un archivo de registro o almacenarlo en una
            // base de datos.
            // También puedes enviar notificaciones o realizar otras acciones según tus necesidades.
        }

    }
}
