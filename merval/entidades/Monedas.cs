using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using merval.Interfaces;
using merval.Serializadores;
using MySql.Data.MySqlClient;

namespace merval
{
    [Serializable]
    public class Monedas : Activos
    {
        #region constructores atributos y propiedades

        private int _id;

        public Monedas() : base()
        {
        }

        public Monedas(string nombre, decimal valorCompra, decimal valorVenta, int cantidad) : base(nombre, valorCompra, valorVenta, cantidad)
        {
        }
        public Monedas(int id, string nombre, decimal valorCompra, decimal valorVenta, int cantidad) : base(nombre, valorCompra, valorVenta, cantidad)
        {
            Id = id;
        }

        public int Id { get => _id; set => _id = value; }
        #endregion

        public static Monedas CrearMoneda(string titulo, decimal valorCompra, decimal valorVenta)
        {
            int cantidad = 0;
            Monedas nuevaMoneda = new Monedas(titulo, valorCompra, valorVenta, cantidad);

            return nuevaMoneda;
        }

        /// <summary>
        /// para trabajar offline con xml
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="valorCompra"></param>
        /// <param name="valorVenta"></param>
        /// <param name="lista"></param>
        /// 
        public static void ModificarDatos(string nombre, decimal valorCompra, decimal valorVenta, List<Monedas> lista)
        {
            foreach (Monedas a in lista)
            {
                if (a.Nombre == nombre)
                {
                    a.ValorCompra = valorCompra;
                    a.ValorVenta = valorVenta;
                    Serializadora.GuardarGralMonedas(lista);
                    break;
                }
            }
        }

        #region data de coneccion sql
        public static MySqlConnection Connection;

        public static MySqlCommand commandSql;

        /// <summary>
        /// data de coneccion mysql
        /// </summary>
        static Monedas()
        {
            var SqlStringConnection = @"Server=localhost;Database=merval;Uid=root;Pwd=;";
            Connection = new MySqlConnection(SqlStringConnection);

            commandSql = new MySqlCommand();
            commandSql.CommandType = System.Data.CommandType.Text;
            commandSql.Connection = Connection;
        }
        #endregion



        //#region metodos interfase

        //public void comprarActivo(Usuario usuario, Activos activos)
        //{
        //    using (MySqlConnection connection = new MySqlConnection(Connection.ConnectionString))
        //    {

        //        connection.Open();

        //        string insertQuery = "INSERT INTO listadodeactivosusuario (idUsuario, Nombre, cantidad) " +
        //                             "VALUES (@idUsuario, @Nombre, @cantidad)";

        //        using (MySqlCommand cmd = new MySqlCommand(insertQuery, connection))
        //        {
        //            cmd.Parameters.AddWithValue("@idUsuario", usuario.Id);
        //            cmd.Parameters.AddWithValue("@Nombre", activos.Nombre);
        //            cmd.Parameters.AddWithValue("@cantidad", activos.Cantidad);
        //            int filasAfectadas = cmd.ExecuteNonQuery();

        //            if (filasAfectadas == 1)
        //            {
        //                Vm.VentanaMensaje("Exito", "Titulo adquirido.");
        //            }
        //        }
        //    }

        //}

        ///// <summary>
        ///// crea la tabla de activos, Monedas o Acciones paramostrar en los datagrids
        ///// </summary>
        ///// <param name="tipo"></param>
        ///// <returns></returns>
        //public DataTable MostrarActivos(string tipo)
        //{
        //    DataTable table = new DataTable();

        //    try
        //    {
        //        Connection.Open();
        //        commandSql.CommandText = string.Empty;
        //        var query = "SELECT * FROM Monedas";

        //        if (tipo == "Acciones")
        //        {
        //            query = "SELECT * FROM Acciones";
        //        }

        //        commandSql.CommandText = query;

        //        using (MySqlDataReader reader = commandSql.ExecuteReader())
        //        {
        //            table.Load(reader); // Cargar los datos del lector en la tabla
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Vm.VentanaMensajeError("No se pudo conectar a la DB");
        //    }
        //    finally
        //    {
        //        Connection.Close();
        //    }

        //    return table;
        //}

        ///// <summary>
        ///// Inserta un nuevo activo en la base de datos.
        ///// Recibe el tipo de activo, que puede ser "monedas" o "acciones"
        ///// Recibe el objeto de tipo activos que se va a insertar en la base de datos
        ///// </summary>
        ///// <param name="tipo">El tipo de activo, que puede ser "monedas" o "acciones".</param>
        ///// <param name="activo">El objeto de tipo activos que se va a insertar en la base de datos.</param>
        ///// <returns>True si la inserción fue exitosa, False en caso contrario.</returns>
        //public void InsertarActivo(string tipo, Activos activo)
        //{
        //    using (MySqlConnection connection = new MySqlConnection(Connection.ConnectionString))
        //    {
        //        connection.Open();

        //        string insertQuery = $"INSERT INTO {tipo} (nombre, valorCompra, valorVenta) " +
        //                             "VALUES (@nombre, @valorCompra, @valorVenta)";

        //        using (MySqlCommand cmd = new MySqlCommand(insertQuery, connection))
        //        {
        //            cmd.Parameters.AddWithValue("@nombre", activo.Nombre);
        //            cmd.Parameters.AddWithValue("@valorCompra", activo.ValorCompra);
        //            cmd.Parameters.AddWithValue("@valorVenta", activo.ValorVenta);

        //            int filasAfectadas = cmd.ExecuteNonQuery();

        //            if (filasAfectadas == 1)
        //            {
        //                Vm.VentanaMensaje("Exito", "Titulo ingresado correctamente.");
        //            }
        //            else
        //            {
        //                Vm.VentanaMensajeError("no se pudo agregar.");
        //            }
        //        }
        //    }
        //}

        ///// <summary>
        ///// eliminar cualquier tipo de activo de la base de datos
        ///// </summary>
        ///// <param name="activos"></param>
        ///// <param name="tipo"></param>
        //public void EliminarActivo(Activos activos, string tipo)
        //{

        //    try
        //    {
        //        using (MySqlConnection connection = new MySqlConnection(Connection.ConnectionString))
        //        {
        //            connection.Open();

        //            string deleteQuery = $"DELETE FROM {tipo} WHERE Nombre = @nombre";

        //            using (MySqlCommand cmd = new MySqlCommand(deleteQuery, connection))
        //            {
        //                cmd.Parameters.AddWithValue("@nombre", activos.Nombre);

        //                if (cmd.ExecuteNonQuery() > 0)
        //                {
        //                    Vm.VentanaMensaje($"{tipo} --{activos.Nombre}--", "dado de baja");
        //                }
        //                else
        //                {
        //                    Vm.VentanaMensajeError($"{tipo} no encontrado\nNo se realizó la baja");
        //                }

        //            }
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        Vm.VentanaMensajeError("Error, no se realizó la baja: " + ex.Message);
        //        throw;
        //    }

        //}

        ///// <summary>
        ///// modificar cualquier tipo de activo de la base de datos
        ///// </summary>
        ///// <param name="tipo"></param>
        ///// <param name="nombre"></param>
        ///// <param name="valorCompra"></param>
        ///// <param name="valorVenta"></param>
        ///// <param name="id"></param>
        //public void ModificarActivo(string tipo, string nombre, decimal valorCompra, decimal valorVenta, string id)
        //{

        //    try
        //    {
        //        using (MySqlConnection connection = new MySqlConnection(Connection.ConnectionString))
        //        {
        //            connection.Open();

        //            string updateQuery = $"UPDATE {tipo} SET `Nombre` = @Nombre, `valorCompra` = @valorCompra, `valorVenta` = @valorVenta WHERE `id` = @id";

        //            using (MySqlCommand cmd = new MySqlCommand(updateQuery, connection))
        //            {
        //                cmd.Parameters.AddWithValue("@Nombre", nombre);
        //                cmd.Parameters.AddWithValue("@valorCompra", valorCompra);
        //                cmd.Parameters.AddWithValue("@valorVenta", valorVenta);
        //                cmd.Parameters.AddWithValue("@id", id);

        //                int filasAfectadas = cmd.ExecuteNonQuery();

        //                if (filasAfectadas == 1)
        //                {
        //                    Vm.VentanaMensaje("Exito", "Titulo ingresado correctamente.");
        //                }
        //            }
        //        }


        //    }
        //    catch (Exception)
        //    {
        //        Vm.VentanaMensajeError("no se pudo actualizar usuario");
        //        throw;
        //    }
        //}

        ///// <summary>
        ///// crea una lista con los activos recibe string tipo para diferenciar los tipos de activos, retorna una lista de activos
        ///// </summary>
        ///// <param name="tipo"></param>
        ///// <returns>lista de activos</returns>
        //public List<Activos> CrearListaDeActivos(string tipo)
        //{
        //    List<Activos> lista = new List<Activos>();
        //    try
        //    {
        //        Connection.Open();
        //        commandSql.CommandText = string.Empty;
        //        var query = $"SELECT * FROM {tipo}";
        //        commandSql.CommandText = query;

        //        using var reader = commandSql.ExecuteReader();
        //        {
        //            while (reader.Read())
        //            {
        //                var id = Convert.ToInt32(reader["id"].ToString());
        //                var nombre = reader["nombre"].ToString();
        //                var valorCompra = reader.GetDecimal(reader.GetOrdinal("valorCompra"));
        //                var valorVenta = reader.GetDecimal(reader.GetOrdinal("valorVenta"));

        //                Activos a = new Activos(nombre, valorCompra, valorVenta, 0);
        //                lista.Add(a);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Vm.VentanaMensajeError("No se pudo conectar a la DB");
        //    }
        //    finally
        //    {
        //        Connection.Close();
        //    }
        //    return lista;
        //}

        //#endregion



        /// <summary>
        /// /// crea una lista con las monedas, retorna una lista de monedas
        /// </summary>
        /// <returns>lista de monedas</returns>
        public static List<Monedas> CrearListaMonedas()
        {
            List<Monedas> lista = new List<Monedas>();
            try
            {
                Connection.Open();
                commandSql.CommandText = string.Empty;
                var query = "SELECT * FROM Monedas";
                commandSql.CommandText = query;

                using var reader = commandSql.ExecuteReader();
                {
                    while (reader.Read())
                    {
                        var id = Convert.ToInt32(reader["id"].ToString());
                        var nombre = reader["nombre"].ToString();
                        var valorCompra = reader.GetDecimal(reader.GetOrdinal("valorCompra"));
                        var valorVenta = reader.GetDecimal(reader.GetOrdinal("valorVenta"));
                        Monedas a = new Monedas(id, nombre, valorCompra, valorVenta, 0);
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


        // public static "async" void nombremetodo()
        //{  
        //Task.Run(async () =>
        //{
        // comunicar con la BD 
        // await antes de cada metodo
        //}).Wait(); // Esperar a que la tarea se complete " }).wait();" no olvidarme!!

        //return si hace falta;
        //}


    }
}
