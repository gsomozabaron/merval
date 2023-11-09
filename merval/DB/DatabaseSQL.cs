using merval.entidades;
using merval.Serializadores;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace merval.DB
{
    public class DatabaseSQL
    {
        #region Metodos testeados

        public static MySqlConnection Connection;

        public static MySqlCommand commandSql;

        /// <summary>
        /// data de coneccion mysql
        /// </summary>
        static DatabaseSQL()
        {
            var SqlStringConnection = @"Server=localhost;Database=merval;Uid=root;Pwd=;";
            Connection = new MySqlConnection(SqlStringConnection);

            commandSql = new MySqlCommand();
            commandSql.CommandType = System.Data.CommandType.Text;
            commandSql.Connection = Connection;
        }   

        public static void OpenConnection()
        {
            Connection.Open();

            Connection.Close();
        }


        /// <summary>
        /// crea una lista con todos los usuarios de la DB
        /// </summary>
        /// <returns></returns>
        public static List<Usuario> MostrarUsuarios()
        {
            List<Usuario> lista = new List<Usuario>();

            try
            {
                Connection.Open();
                commandSql.CommandText = string.Empty;
                var query = "SELECT * FROM Usuario";
                commandSql.CommandText = query;

               using var reader = commandSql.ExecuteReader();
                {
                    while (reader.Read())
                    {
                        var id = Convert.ToInt32(reader["id"].ToString());
                        var nombre = reader["nombre"].ToString();
                        var dni = reader["dni"].ToString();
                        var nombreUsuario = reader["nombreUsuario"].ToString();
                        var pass = reader["pass"].ToString();
                        var tipoDeUsuario = (Tipo)Enum.Parse(typeof(Tipo), reader["tipoDeUsuario"].ToString());
                        var saldo = reader.GetDecimal(reader.GetOrdinal("saldo"));
                        var apellido = reader["apellido"].ToString();

                        Usuario usuario = new Usuario (id, nombre, dni, nombreUsuario, pass, tipoDeUsuario, saldo, apellido);
                        lista.Add(usuario);
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
       
        /// <summary>
        /// crea la tabla de activos, Monedas o Acciones paramostrar en los datagrids
        /// </summary>
        /// <param name="tipo"></param>
        /// <returns></returns>
        public static DataTable MostrarActivos(string tipo)
        {
            DataTable table = new DataTable();

            try
            {
                Connection.Open();
                commandSql.CommandText = string.Empty;
                var query = "SELECT * FROM Monedas";
                
                if (tipo == "Acciones")
                {
                    query = "SELECT * FROM Acciones";
                }
                
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
        /// para cargar las listas desde XML por primera vez
        /// </summary>
        public static void CargaSQL()
        {
            List<Usuario> listu = Serializadora.LeerListadoUsuarios();
            foreach (Usuario usuario in listu)
            {
                InsertarUsuario(usuario);

                foreach (Activos a in usuario.ListadoDeActivosPropios)
                {
                    InsertarActivosPropios(usuario, a);
                }
            }

            List<Monedas> listm = Serializadora.LeerListaMonedas();
            foreach (Monedas m in listm)
            {
                InsertarMonedas(m);
            }

            List<Acciones> lista = Serializadora.LeerListaAcciones();
            foreach (Acciones a in lista)
            {
                InsertarAcciones(a);
            }

        }

        /// <summary>
        /// crea la lista de usuarios ,invoca a MostrarUsuarios
        /// </summary>
        /// <returns></returns>
        public static List<Usuario> GetUsuarios()
        {
            List<Usuario> lista = MostrarUsuarios();
            return lista;
        }

        public static void EliminarUsuario(Usuario usuario)
        {

            try
            {
                using (MySqlConnection connection = new MySqlConnection(Connection.ConnectionString))
                {
                    connection.Open();
   
                    string deleteQuery = "DELETE FROM usuario WHERE id = @UserId";

                    using (MySqlCommand cmd = new MySqlCommand(deleteQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@UserId", usuario.Id);

                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            Vm.VentanaMensaje($"Usuario --{usuario.NombreUsuario}--\n--{usuario.Nombre}--", "dado de baja");
                        }
                        else
                        {
                            Vm.VentanaMensajeError("Usuario no encontrado\nNo se realizó la baja");
                        }

                    }
                }

            }
            catch (Exception ex)
            {
                Vm.VentanaMensajeError("Error, no se realizó la baja: " + ex.Message);
                throw;
            }

        }



        #endregion


        public static void InsertarUsuario(Usuario nuevoUsuario)
        {
            using (MySqlConnection connection = new MySqlConnection(Connection.ConnectionString))
            {
                connection.Open();

                string insertQuery = "INSERT INTO usuario (nombre, dni, nombreUsuario, pass, tipoDeUsuario, saldo, apellido) " +
                                     "VALUES (@nombre, @dni, @nombreUsuario, @pass, @tipoDeUsuario, @saldo, @apellido)";

                using (MySqlCommand cmd = new MySqlCommand(insertQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@nombre", nuevoUsuario.Nombre);
                    cmd.Parameters.AddWithValue("@dni", nuevoUsuario.Dni);
                    cmd.Parameters.AddWithValue("@nombreUsuario", nuevoUsuario.NombreUsuario);
                    cmd.Parameters.AddWithValue("@pass", nuevoUsuario.Pass);
                    cmd.Parameters.AddWithValue("@tipoDeUsuario", nuevoUsuario.TipoDeUsuario);
                    cmd.Parameters.AddWithValue("@saldo", nuevoUsuario.Saldo);
                    cmd.Parameters.AddWithValue("@apellido", nuevoUsuario.Apellido);
                    //cmd.ExecuteNonQuery();
                }
            }
        }
        public static void InsertarAcciones(Acciones accion)
        {
            using (MySqlConnection connection = new MySqlConnection(Connection.ConnectionString))
            {
                connection.Open();

                string insertQuery = "INSERT INTO Acciones (nombre, valorCompra, valorVenta) " +
                                     "VALUES (@nombre, @valorCompra, @valorVenta)";

                using (MySqlCommand cmd = new MySqlCommand(insertQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@nombre", accion.Nombre);
                    cmd.Parameters.AddWithValue("@valorCompra", accion.ValorCompra);
                    cmd.Parameters.AddWithValue("@valorVenta", accion.ValorVenta);
                    
                    int filasAfectadas = cmd.ExecuteNonQuery();

                    if (filasAfectadas == 1)
                    {
                        Vm.VentanaMensaje("Exito", "Titulo ingresado correctamente.");
                    }
                    else
                    {
                        Vm.VentanaMensajeError("no se pudo agregar.");
                    }
                }
            }
        }
        public static void InsertarMonedas(Monedas moneda)
        {
            using (MySqlConnection connection = new MySqlConnection(Connection.ConnectionString))
            {
                connection.Open();

                string insertQuery = "INSERT INTO Monedas (nombre, valorCompra, valorVenta) " +
                                     "VALUES (@nombre, @valorCompra, @valorVenta)";

                using (MySqlCommand cmd = new MySqlCommand(insertQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@nombre", moneda.Nombre);
                    cmd.Parameters.AddWithValue("@valorCompra", moneda.ValorCompra);
                    cmd.Parameters.AddWithValue("@valorVenta", moneda.ValorVenta);
                    
                    int filasAfectadas = cmd.ExecuteNonQuery();

                    if (filasAfectadas == 1)
                    {
                        Vm.VentanaMensaje("Exito", "Titulo ingresado correctamente.");
                    }
                    else
                    {
                        Vm.VentanaMensajeError("no se pudo agregar.");
                    }
                }
            }
        }

        /// <summary>
        /// Inserta un nuevo activo en la base de datos.
        /// Recibe el tipo de activo, que puede ser "monedas" o "acciones"
        /// Recibe el objeto de tipo activos que se va a insertar en la base de datos
        /// </summary>
        /// <param name="tipo">El tipo de activo, que puede ser "monedas" o "acciones".</param>
        /// <param name="activo">El objeto de tipo activos que se va a insertar en la base de datos.</param>
        /// <returns>True si la inserción fue exitosa, False en caso contrario.</returns>
        public static void InsertarActivo(string tipo, Activos activo)
        {
            using (MySqlConnection connection = new MySqlConnection(Connection.ConnectionString))
            {
                connection.Open();

                string insertQuery = $"INSERT INTO {tipo} (nombre, valorCompra, valorVenta) " +
                                     "VALUES (@nombre, @valorCompra, @valorVenta)";

                using (MySqlCommand cmd = new MySqlCommand(insertQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@nombre", activo.Nombre);
                    cmd.Parameters.AddWithValue("@valorCompra", activo.ValorCompra);
                    cmd.Parameters.AddWithValue("@valorVenta", activo.ValorVenta);

                    int filasAfectadas = cmd.ExecuteNonQuery();

                    if (filasAfectadas == 1)
                    {
                        Vm.VentanaMensaje("Exito", "Titulo ingresado correctamente.");
                    }
                    else
                    {
                        Vm.VentanaMensajeError("no se pudo agregar.");
                    }
                }
            }
        }

        public static void EliminarActivo(Activos activos, string tipo)
        {

            try
            {
                using (MySqlConnection connection = new MySqlConnection(Connection.ConnectionString))
                {
                    connection.Open();

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

        }

        public static void ModificarActivo(string tipo, string nombre, decimal valorCompra, decimal valorVenta)
        {
            
            try
            {
                using (MySqlConnection connection = new MySqlConnection(Connection.ConnectionString))
                {
                    connection.Open();
                    
                    string updateQuery = $"UPDATE {tipo} SET `Nombre` = @Nombre, `valorCompra` = @valorCompra, `valorVenta` = @valorVenta WHERE `id` = @id";

                    using (MySqlCommand cmd = new MySqlCommand(updateQuery, connection))
                    {
                        //cmd.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                        //cmd.Parameters.AddWithValue("@apellido", usuario.Apellido);
                        //cmd.Parameters.AddWithValue("@dni", usuario.Dni);
                        //cmd.Parameters.AddWithValue("@NombreUsuario", usuario.NombreUsuario);
                        //cmd.Parameters.AddWithValue("@id", id);

                        int filasAfectadas = cmd.ExecuteNonQuery();

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





        public static List<Activos> CrearListaDeActivos(string tipo)
        { 
            List<Activos> lista = new List<Activos>();
            try
            {
                Connection.Open();
                commandSql.CommandText = string.Empty;
                var query = $"SELECT * FROM {tipo}";
                commandSql.CommandText = query;

                using var reader = commandSql.ExecuteReader();
                {
                    while (reader.Read())
                    {
                        var id = Convert.ToInt32(reader["id"].ToString());
                        var nombre = reader["nombre"].ToString();
                        var valorCompra = reader.GetDecimal(reader.GetOrdinal("valorCompra"));
                        var valorVenta = reader.GetDecimal(reader.GetOrdinal("valorVenta"));
                        if (tipo == "Acciones")
                        {
                            Activos a = new Acciones(id, nombre, valorCompra, valorVenta, 0);
                            lista.Add(a);
                        }
                        else if (tipo == "monedas")
                        {
                            Activos a = new Monedas(id, nombre, valorCompra, valorVenta, 0);
                            lista.Add(a);
                        }
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
        
        public static List<Acciones> CrearListaAcciones()
        {
            List<Acciones> lista = new List<Acciones>();
            try
            {
                Connection.Open();
                commandSql.CommandText = string.Empty;
                var query = "SELECT * FROM Acciones";
                commandSql.CommandText = query;

                using var reader = commandSql.ExecuteReader();
                {
                    while (reader.Read())
                    {
                        var id = Convert.ToInt32(reader["id"].ToString());
                        var nombre = reader["nombre"].ToString();
                        var valorCompra = reader.GetDecimal(reader.GetOrdinal("valorCompra"));
                        var valorVenta = reader.GetDecimal(reader.GetOrdinal("valorVenta"));

                        Acciones a = new Acciones(id, nombre, valorCompra, valorVenta, 0);
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









        /// <summary>
        /// modificar los datos del usuario, Nombre, apellido, Dni y/o NombreUsuario
        /// </summary>
        /// <param name="usuario">recibe un usuario</param>
        public static void ModificarUsuarios(Usuario usuario)
        {
            int id = usuario.Id;
            try
            {
                using (MySqlConnection connection = new MySqlConnection(Connection.ConnectionString))
                {
                    connection.Open();

                    string updateQuery = "UPDATE `usuario` SET `Nombre` = @Nombre, `apellido` = @apellido, `Dni` = @dni, `NombreUsuario` = @NombreUsuario WHERE `id` = @id";

                    using (MySqlCommand cmd = new MySqlCommand(updateQuery, connection))
                    {                        
                        cmd.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                        cmd.Parameters.AddWithValue("@apellido", usuario.Apellido);
                        cmd.Parameters.AddWithValue("@dni", usuario.Dni);
                        cmd.Parameters.AddWithValue("@NombreUsuario", usuario.NombreUsuario);
                        cmd.Parameters.AddWithValue("@id", id);

                        int filasAfectadas = cmd.ExecuteNonQuery();

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

        public static void InsertarActivosPropios(Usuario usuario, Activos a)
        {
            using (MySqlConnection connection = new MySqlConnection(Connection.ConnectionString))
            {
                connection.Open();

                string insertQuery = "INSERT INTO listadodeactivosusuario (idUsuario, Nombre, cantidad) " +
                                     "VALUES (@idUsuario, @Nombre, @cantidad)";

                using (MySqlCommand cmd = new MySqlCommand(insertQuery, connection))
                {
                    //join usuario id?
                    //cmd.Parameters.AddWithValue("@idUsuario", 2);

                    cmd.Parameters.AddWithValue("@Nombre", a.Nombre);
                    cmd.Parameters.AddWithValue("@cantidad", a.Cantidad);
                    cmd.ExecuteNonQuery();
                }
            }
        }




    }
}
