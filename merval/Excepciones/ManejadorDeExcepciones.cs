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
        private static void Errores()
        {
            


            string mensaje = "";
            string formName = "";
            try
            {

            }

            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                mensaje = "Al conectar a la base de datos ";
                CrearErrorLog(formName, ex, mensaje);

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

        public static async void CrearErrorLog(string formName, Exception ex, string mensaje)
        {
            var errorLog = new LogError(ex, mensaje, formName);

            await ErrorSql.InsertarErrorEnDb(errorLog);           
        }
       
      
    }
}
