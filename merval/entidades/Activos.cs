using merval.DB;
using merval.Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace merval
{
    [Serializable]
    public class Activos : IActivosSQL
    {
        #region constructores atributos y propiedades
        private string nombre;
        private decimal valorCompra;
        private decimal valorVenta;
        private int cantidad;
        private int id;
        

        public Activos()
        {
        }
        
        public Activos(string nombre, decimal valorCompra, decimal valorVenta, int cantidad)
        {
            this.nombre = nombre;
            this.valorCompra = valorCompra;
            this.valorVenta = valorVenta;
            this.cantidad = cantidad;
        }

        public Activos(int id, string nombre, decimal valorCompra, decimal valorVenta, int cantidad) : this (nombre, valorCompra, valorVenta, cantidad)
        {
            Id = id;
        }



        public string Nombre { get => nombre; set => nombre = value; }
        
        public decimal ValorCompra { get => valorCompra; set => valorCompra = value; }
        
        public decimal ValorVenta { get => valorVenta; set => valorVenta = value; }
        
        public int Cantidad { get => cantidad; set => cantidad = value; }
        
        public int Id { get => id; set => id = value; }

        public static bool operator ==(Activos activo1, Activos activo2)
        {
            if (ReferenceEquals(activo1, activo2))
            {
                return true;
            }

            if (ReferenceEquals(activo1, null) || ReferenceEquals(activo2, null))
            {
                return false;
            }

            return activo1.nombre == activo2.nombre;
        }

        public static bool operator !=(Activos activo1, Activos activo2)
        {
            return !(activo1 == activo2);
        }
        #endregion

        #region data de coneccion sql

        public static MySqlConnection Connection;

        public static MySqlCommand commandSql;

        /// <summary>
        /// data de coneccion mysql
        /// </summary>
        static Activos()
        {
            var SqlStringConnection = @"Server=localhost;Database=merval;Uid=root;Pwd=;";
            Connection = new MySqlConnection(SqlStringConnection);

            commandSql = new MySqlCommand();
            commandSql.CommandType = System.Data.CommandType.Text;
            commandSql.Connection = Connection;
        }
        #endregion



        #region metodos interfase
        /// agrega a la base de datos el activo comprado por el cliente 
        public async Task comprarActivo(UsuarioSQL usuario, Activos activos) //async
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(Connection.ConnectionString))
                {
                    await connection.OpenAsync();

                    string insertQuery = "INSERT INTO listadodeactivosusuario (idUsuario, Nombre, cantidad) " +
                                         "VALUES (@idUsuario, @Nombre, @cantidad)";

                    using (MySqlCommand cmd = new MySqlCommand(insertQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@idUsuario", usuario.Id);
                        cmd.Parameters.AddWithValue("@Nombre", activos.Nombre);
                        cmd.Parameters.AddWithValue("@cantidad", activos.Cantidad);
                        int filasAfectadas = cmd.ExecuteNonQuery();

                        if (filasAfectadas == 1)
                        {
                            Vm.VentanaMensaje("Exito", "Titulo adquirido.");
                        }
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        /// <summary>
        /// crea la tabla de activos, Monedas o Acciones paramostrar en los datagrids
        /// </summary>
        /// <param name="tipo"></param>
        /// <returns></returns>
        public async Task<DataTable> MostrarActivos(string tipo)    //async
        {
            DataTable table = new DataTable();
                try
                {
                    await Connection.OpenAsync();
                    commandSql.CommandText = string.Empty;
                    var query = $"SELECT * FROM {tipo}";

                   commandSql.CommandText = query;

                    using (MySqlDataReader reader = commandSql.ExecuteReader())
                    {
                        table.Load(reader); // Cargar los datos del lector en la tabla
                    }
                }
                catch (Exception ex)
                {
                    Vm.VentanaMensajeError("No se pudo conectar a la DB");
                }
                finally
                {
                    Connection.Close();
                }
            return table;
        }

        /// <summary>
        /// Inserta un nuevo activo en la base de datos.
        /// Recibe el tipo de activo, que puede ser "monedas" o "acciones"
        /// Recibe el objeto de tipo activos que se va a insertar en la base de datos
        /// </summary>
        /// <param name="tipo">El tipo de activo, que puede ser "monedas" o "acciones".</param>
        /// <param name="activo">El objeto de tipo activos que se va a insertar en la base de datos.</param>
        /// <returns>True si la inserción fue exitosa, False en caso contrario.</returns>

        public async Task InsertarActivo(string tipo, Activos activo)   //async
        {
            
            try
            {
                using (MySqlConnection connection = new MySqlConnection(Connection.ConnectionString))
                {
                    await connection.OpenAsync();

                    string insertQuery = $"INSERT INTO {tipo} (nombre, valorCompra, valorVenta) " +
                                         "VALUES (@nombre, @valorCompra, @valorVenta)";

                    using (MySqlCommand cmd = new MySqlCommand(insertQuery, connection))
                    {
                        cmd.Parameters.Add("@nombre", MySqlDbType.VarChar).Value = activo.Nombre;
                        cmd.Parameters.Add("@valorCompra", MySqlDbType.Decimal).Value = activo.ValorCompra;
                        cmd.Parameters.Add("@valorVenta", MySqlDbType.Decimal).Value = activo.ValorVenta;

                        int filasAfectadas = await cmd.ExecuteNonQueryAsync();

                        if (filasAfectadas == 1)
                        {
                            Vm.VentanaMensaje("Éxito", "Activo ingresado correctamente.");
                        }
                        else
                        {
                            Vm.VentanaMensajeError("No se pudo agregar el activo.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Vm.VentanaMensajeError($"Error al insertar activo: {ex.Message}");
            }
        }   

        /// <summary>
        /// eliminar cualquier tipo de activo de la base de datos
        /// </summary>
        /// <param name="activos"></param>
        /// <param name="tipo"></param>
        public async Task EliminarActivo(Activos activos, string tipo)
        {

            try
            {
                using (MySqlConnection connection = new MySqlConnection(Connection.ConnectionString))
                {
                    await connection.OpenAsync();

                    string deleteQuery = $"DELETE FROM {tipo} WHERE Nombre = @nombre";

                    using (MySqlCommand cmd = new MySqlCommand(deleteQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@nombre", activos.Nombre);

                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            Vm.VentanaMensaje($"{tipo} --{activos.Nombre}--", "dado de baja");
                        }
                        else
                        {
                            Vm.VentanaMensajeError($"{tipo} no encontrado\nNo se realizó la baja");
                        }

                    }
                }

            }
            catch (Exception ex)
            {
                Vm.VentanaMensajeError("Error, no se realizó la baja: " + ex.Message);
                throw;
            }

        } //async

        /// <summary>
        /// modificar cualquier tipo de activo de la base de datos
        /// </summary>
        /// <param name="tipo"></param>
        /// <param name="nombre"></param>
        /// <param name="valorCompra"></param>
        /// <param name="valorVenta"></param>
        /// <param name="id"></param>
        public async Task ModificarActivo(string tipo, string nombre, decimal valorCompra, decimal valorVenta, string id)
        {
            try
            {
                await using (MySqlConnection connection = new MySqlConnection(Connection.ConnectionString))
                {
                    await connection.OpenAsync();

                    string updateQuery = $"UPDATE {tipo} SET `Nombre` = @Nombre, `valorCompra` = @valorCompra, `valorVenta` = @valorVenta WHERE `id` = @id";

                    await using (MySqlCommand cmd = new MySqlCommand(updateQuery, connection))
                    {
                        cmd.Parameters.Add("@Nombre", MySqlDbType.VarChar).Value = nombre;
                        cmd.Parameters.Add("@valorCompra", MySqlDbType.Decimal).Value = valorCompra;
                        cmd.Parameters.Add("@valorVenta", MySqlDbType.Decimal).Value = valorVenta;
                        cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = id;

                        int filasAfectadas = await cmd.ExecuteNonQueryAsync();

                        if (filasAfectadas == 1)
                        {
                            Vm.VentanaMensaje("Exito", "Titulo ingresado correctamente.");
                        }
                    }
                }
            }
            catch (Exception)
            {
                Vm.VentanaMensajeError("no se pudo actualizar usuario");
                throw;
            }
        }

        /// <summary>
        /// crea una lista con los activos recibe string tipo para diferenciar los tipos de activos, retorna una lista de activos
        /// </summary>
        /// <param name="tipo"></param>
        /// <returns>lista de activos</returns>
        public async Task<List<Activos>> CrearListaDeActivos(string tipo)
        {
            List<Activos> lista = new List<Activos>();
            try
            {
                await Connection.OpenAsync();
                commandSql.CommandText = string.Empty;
                var query = $"SELECT * FROM {tipo}";
                commandSql.CommandText = query;

                using var reader = await commandSql.ExecuteReaderAsync();
                {
                    while (reader.Read())
                    {
                        var id = Convert.ToInt32(reader["id"].ToString());
                        var nombre = reader["nombre"].ToString();
                        var valorCompra = reader.GetDecimal(reader.GetOrdinal("valorCompra"));
                        var valorVenta = reader.GetDecimal(reader.GetOrdinal("valorVenta"));

                        Activos a = new Activos(id, nombre, valorCompra, valorVenta, 0);
                        lista.Add(a);
                    }
                }
            }
            catch (Exception ex)
            {
                Vm.VentanaMensajeError("No se pudo conectar a la DB");
            }
            finally
            {
                Connection.Close();
            }
            return lista;
        }





        /*
        lista generica
        public async Task<List<T>> CrearListaGenerica(string tipo, string query)
        {
            List<T> lista = new List<T>();
            try
            {
                await Connection.OpenAsync();
                commandSql.CommandText = string.Empty;

                ///var query = $"SELECT * FROM {tipo}";
                commandSql.CommandText = query;

                using var reader = await commandSql.ExecuteReaderAsync();
                {
                    while (reader.Read())
                    {
                        //var id = Convert.ToInt32(reader["id"].ToString());
                        //var nombre = reader["nombre"].ToString();
                        //var valorCompra = reader.GetDecimal(reader.GetOrdinal("valorCompra"));
                        //var valorVenta = reader.GetDecimal(reader.GetOrdinal("valorVenta"));
                        T objeto = (T)reader;

                        //Activos a = new Activos(nombre, valorCompra, valorVenta, 0);
                        lista.Add(objeto);
                    }
                }

                return lista;
            }
            catch (Exception)
            {

                throw;
            }
        }

        ************ en activos sql **************************

        public static explicit operator ActivosAdo (MySqlDataReader reader)
        {
            var id = Convert.ToInt32(reader["id"].ToString());
            var nombre = reader["nombre"].ToString();
            var valorCompra = reader.GetDecimal(reader.GetOrdinal("valorCompra"));
            var valorVenta = reader.GetDecimal(reader.GetOrdinal("valorVenta"));

            return new Activos(nombre, valorCompra, valorVenta, 0);

        }
*/

        #endregion






    }
}
