using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace merval.Excepciones
{
    public class ErrorSql 
    {
        #region data de coneccion sql

        public static MySqlConnection Connection;

        public static MySqlCommand commandSql;

        /// <summary>
        /// data de coneccion mysql
        /// </summary>
        static ErrorSql()
        {
            var SqlStringConnection = @"Server=localhost;Database=merval;Uid=root;Pwd=;";
            Connection = new MySqlConnection(SqlStringConnection);

            commandSql = new MySqlCommand();
            commandSql.CommandType = System.Data.CommandType.Text;
            commandSql.Connection = Connection;
        }
        #endregion

        /// <summary>
        /// gurda el log en base de datos
        /// </summary>
        /// <param name="error"></param>
        /// <returns></returns>
        

        public static async Task InsertarErrorEnDb(LogError error)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(Connection.ConnectionString))
                {
                    await connection.OpenAsync();

                    string insertQuery = "INSERT INTO ErrorLog (Message, Exception, fecha, MethodName) " +
                                         "VALUES (@Message, @Exception, @fecha, @MethodName)";

                    using (MySqlCommand cmd = new MySqlCommand(insertQuery, connection))
                    {
                        cmd.Parameters.Add("@Message", MySqlDbType.VarChar).Value = error.Message.ToString();
                        cmd.Parameters.Add("@Exception", MySqlDbType.VarChar).Value = error.Exception?.ToString();
                        cmd.Parameters.Add("@fecha", MySqlDbType.VarChar).Value = error.Fecha.ToString("F");
                        cmd.Parameters.Add("@MethodName", MySqlDbType.VarChar).Value = error.MethodName.ToString();

                        int filasAfectadas = await cmd.ExecuteNonQueryAsync();

                        if (filasAfectadas == 1)
                        {
                            // Modificar el mensaje de éxito según tu lógica
                            Vm.VentanaMensaje("Error registrado","en breve sera solucionado");
                        }
                        else
                        {
                            Vm.VentanaMensajeError("No se pudo agregar el error.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Vm.VentanaMensajeError($"Error al insertar log en la base de datos: {ex.Message}");
            }
        }







    }
}
