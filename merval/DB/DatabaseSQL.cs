using merval.DAO;
using merval.entidades;
using merval.Serializadores;
using Microsoft.VisualBasic;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace merval.DB
{
    public class DatabaseSQL
    {
        
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
                    //InsertarActivosPropios(usuario, a);
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

        #region usuarios todo pasado a interfase IusuarioDao

        /// <summary>
        /// crea y devuelve la lista de usuarios
        /// </summary>
        /// <returns></returns>
        public static List<Usuario> MostrarUsuarios() ///pasado a DAO
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

                        Usuario usuario = new Usuario(id, nombre, dni, nombreUsuario, pass, tipoDeUsuario, saldo, apellido);
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
        /// crea la lista de usuarios ,invoca a MostrarUsuarios
        /// </summary>
        /// <returns></returns>
        public static List<Usuario> GetUsuarios()
        {
            List<Usuario> lista = MostrarUsuarios();
            return lista;
        }

        //<summary>
        //eliminar usuarios de la base de datos
        //</summary>
        //<param name = "usuario" ></ param >
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

         //<summary>
         //agregar usuarios a la base de datos
         //</summary>
         //<param name = "nuevoUsuario" ></ param >
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
                    int filasAfectadas = cmd.ExecuteNonQuery();

                    if (filasAfectadas == 1)
                    {
                        Vm.VentanaMensaje("Exito", "Usuario regisrado correctamente.");
                    }
                    else
                    {
                        Vm.VentanaMensajeError("no se pudo agregar.");
                    }
                }
            }
        }

         //<summary>
         //modificar los datos del usuario, Nombre, apellido, Dni y/o NombreUsuario
         //</summary>
         //<param name = "usuario" > recibe un usuario</param>
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

        /// <summary>
        /// crea las listas de activos adquiridos por el usuario
        /// </summary>
        /// <param name = "usuario" ></ param >
        /// < param name="tipo"></param>
        /// <returns></returns>
        public static List<Activos> CarteraUsuario(Usuario usuario, string tipo)
        {
            List<Activos> lista = new List<Activos>();

            try
            {
                Connection.Open();
                commandSql.CommandText = string.Empty;
                var query = $"SELECT u.Nombre AS nombre_activo, u.cantidad, a.ValorCompra, a.ValorVenta " +
                            $"FROM listadoDeActivosUsuario u " +
                            $"JOIN {tipo} a ON u.Nombre = a.Nombre " +
                            $"WHERE u.idUsuario = {usuario.Id};";

                commandSql.CommandText = query;

                using (MySqlDataReader reader = commandSql.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string nombre = reader["nombre_activo"].ToString();
                        decimal valorCompra = decimal.Parse(reader["ValorCompra"].ToString());
                        decimal valorVenta = decimal.Parse(reader["ValorVenta"].ToString());
                        int cantidad = int.Parse(reader["cantidad"].ToString());

                        Activos activo = new Activos(nombre, valorCompra, valorVenta, cantidad);
                        lista.Add(activo);
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

        public static void modificarCartera(Usuario usuario, Activos activos)
        {
            using (MySqlConnection connection = new MySqlConnection(Connection.ConnectionString))
            {
                connection.Open();

                string updateQuery = "UPDATE listadodeactivosusuario " +
                     "SET cantidad = @cantidad " +
                     "WHERE idUsuario = @idUsuario AND nombre = @Nombre";

                using (MySqlCommand cmd = new MySqlCommand(updateQuery, connection))
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

        public static void ModificarSaldo(Usuario usuario)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(Connection.ConnectionString))
                {
                    connection.Open();

                    string updateQuery = "UPDATE `usuario` SET `saldo`= @saldo  WHERE id = @id";

                    using (MySqlCommand cmd = new MySqlCommand(updateQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@id", usuario.Id);
                        cmd.Parameters.AddWithValue("@saldo", usuario.Saldo);
                        if (cmd.ExecuteNonQuery() == 0)
                        {
                            Vm.VentanaMensajeError("No se realizó la venta");
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Vm.VentanaMensajeError("Error, no se realizó la venta: " + ex.Message);
                throw;
            }

        }

        public static void BajasEnCartera(Usuario usuario, Activos activos)
        {

            try
            {
                using (MySqlConnection connection = new MySqlConnection(Connection.ConnectionString))
                {
                    connection.Open();

                    string deleteQuery = "DELETE FROM listadodeactivosusuario " +
                    "WHERE idUsuario = @idUsuario AND Nombre = @nombre";

                    using (MySqlCommand cmd = new MySqlCommand(deleteQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@idUsuario", usuario.Id);
                        cmd.Parameters.AddWithValue("@Nombre", activos.Nombre);
                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            Vm.VentanaMensaje($"{activos.Nombre}", "Vendido");
                        }
                        else
                        {
                            Vm.VentanaMensajeError("No se realizó la venta");
                        }

                    }
                    ModificarSaldo(usuario);
                }

            }
            catch (Exception ex)
            {
                Vm.VentanaMensajeError("Error, no se realizó la venta: " + ex.Message);
                throw;
            }


        }

        #endregion

        #region activos todo pasado a interfase IactivosDao

        public static void comprarActivo(Usuario usuario, Activos activos)
        {
            using (MySqlConnection connection = new MySqlConnection(Connection.ConnectionString))
            {

                connection.Open();

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
        /// agregar acciones a la base de datos
        /// </summary>
        /// <param name="accion"></param>
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

        /// <summary>
        /// agregar monedas a la base de datos
        /// </summary>
        /// <param name="moneda"></param>
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

        /// <summary>
        /// eliminar cualquier tipo de activo de la base de datos
        /// </summary>
        /// <param name="activos"></param>
        /// <param name="tipo"></param>
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

        /// <summary>
        /// modificar cualquier tipo de activo de la base de datos
        /// </summary>
        /// <param name="tipo"></param>
        /// <param name="nombre"></param>
        /// <param name="valorCompra"></param>
        /// <param name="valorVenta"></param>
        /// <param name="id"></param>
        public static void ModificarActivo(string tipo, string nombre, decimal valorCompra, decimal valorVenta, string id)
        {
            
            try
            {
                using (MySqlConnection connection = new MySqlConnection(Connection.ConnectionString))
                {
                    connection.Open();
                    
                    string updateQuery = $"UPDATE {tipo} SET `Nombre` = @Nombre, `valorCompra` = @valorCompra, `valorVenta` = @valorVenta WHERE `id` = @id";

                    using (MySqlCommand cmd = new MySqlCommand(updateQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@Nombre", nombre);
                        cmd.Parameters.AddWithValue("@valorCompra", valorCompra);
                        cmd.Parameters.AddWithValue("@valorVenta", valorVenta);
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

        /// <summary>
        /// crea una lista con los activos recibe string tipo para diferenciar los tipos de activos, retorna una lista de activos
        /// </summary>
        /// <param name="tipo"></param>
        /// <returns>lista de activos</returns>
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
                        
                        Activos a = new Activos(nombre, valorCompra, valorVenta, 0);
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
        /// crea una lista con las acciones, retorna una lista de acciones
        /// </summary>
        /// <returns>lista de acciones</returns>
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

        #endregion

    }
}
