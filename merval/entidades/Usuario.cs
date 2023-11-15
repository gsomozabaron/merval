using merval.DAO;
using merval.DB;
using merval.entidades;
using merval.Serializadores;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;


namespace merval
{
    [Serializable]
    [XmlInclude(typeof(Activos))]
    [XmlInclude(typeof(Acciones))]
    [XmlInclude(typeof(Monedas))]

    public class Usuario : Persona , IUsuarioDao
    {
        #region SQL Coneccion
        public static MySqlConnection Connection;

        public static MySqlCommand commandSql;

        static Usuario()
        {
            var SqlStringConnection = @"Server=localhost;Database=merval;Uid=root;Pwd=;";
            Connection = new MySqlConnection(SqlStringConnection);

            commandSql = new MySqlCommand();
            commandSql.CommandType = System.Data.CommandType.Text;
            commandSql.Connection = Connection;
        }
        #endregion

        #region atributos
        [XmlArray("ListadoDeActivosPropios")]
        [XmlArrayItem("Activos", typeof(Activos))]

        private int _id;
        private string _nombre;
        private string _apellido;
        private string _dni;
        private Tipo _tipoDeUsuario;
        private List<Activos> _listadoDeActivosPropios;
        private decimal _saldo;
        
        #endregion

        #region constructores
        public Usuario() : base(string.Empty, string.Empty)
        {
        }

        public Usuario(string nombre, string dni, string nombreUsuario, string pass,
            Tipo tipoDeUsuario, decimal saldo, string apellido)
            : base(nombreUsuario, pass)
        {
            this._nombre = nombre;
            this._dni = dni;
            this._tipoDeUsuario = tipoDeUsuario;
            this._saldo = saldo;
            this._apellido = apellido;
        }

        public Usuario(int id, string nombre, string dni, string nombreUsuario, string pass,
            Tipo tipoDeUsuario, decimal saldo, string apellido)
            : base(nombreUsuario, pass)
        {
            this._id = id;
            this._nombre = nombre;
            this._dni = dni;
            this._tipoDeUsuario = tipoDeUsuario;
            this._saldo = saldo;
            this._apellido = apellido;
            this.ListadoDeActivosPropios = new List<Activos>();
        }

        



        #endregion

        #region propiedades
        public int Id { get => _id; set => _id = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }
        public string Apellido { get => _apellido; set => _apellido = value; }
        public string Dni { get => _dni; set => _dni = value; }
        public Tipo TipoDeUsuario { get => _tipoDeUsuario; set => _tipoDeUsuario = value; }
        public List<Activos> ListadoDeActivosPropios { get => _listadoDeActivosPropios; set => _listadoDeActivosPropios = value; }
        public decimal Saldo { get => _saldo; set => _saldo = value; }


        #endregion


        /// crear nuevo usuario
        public static Usuario CrearUsuario(string nombre, string dni, string nombreUsuario, string pass, Tipo tipoDeUsuario, decimal saldo, string apellido)
        {
            Usuario nuevoUsuario = new (nombre, dni, nombreUsuario, pass, tipoDeUsuario, saldo, apellido);
            return nuevoUsuario;
        }
        
        #region metodos interfase
        public void ModificarUsuarios(Usuario usuario)
        {
            int id = usuario.Id;
            try
            {
                using (MySqlConnection connection = new MySqlConnection(Connection.ConnectionString))
                {
                    connection.Open();

                    string updateQuery = "UPDATE `usuario` SET `Nombre` = @Nombre, `apellido` = @apellido, `Dni` = @dni, `NombreUsuario` = @NombreUsuario, `Saldo` = @Saldo WHERE `id` = @id";

                    using (MySqlCommand cmd = new MySqlCommand(updateQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                        cmd.Parameters.AddWithValue("@apellido", usuario.Apellido);
                        cmd.Parameters.AddWithValue("@dni", usuario.Dni);
                        cmd.Parameters.AddWithValue("@NombreUsuario", usuario.NombreUsuario);
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@Saldo", usuario.Saldo);

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

        public void AgregarUsuario(Usuario nuevoUsuario)
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

        public void BajaUsuario(Usuario usuario)
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



        //añade acciones a la lista de acciones de un usuario
        //public static void ComprarActivo(Usuario usuarioActual, string titulo, int cantidad, decimal totalCompra, string tipo)
        //{
        //    if (HacerValidaciones(usuarioActual, titulo, cantidad, totalCompra))
        //    {
        //        usuarioActual.Saldo -= totalCompra;

        //        if (usuarioActual.ListadoDeActivosPropios == null)
        //        {
        //            usuarioActual.ListadoDeActivosPropios = new List<Activos>();
        //        }
        //        usuarioActual.ModificarSaldo(usuarioActual);
        //        ActualizarActivos(usuarioActual, titulo, cantidad);
        //    }
        //}

        //public static void VenderActivo(Usuario usuarioActual, string titulo, int cantidad, decimal totalVenta)
        ////{
        //    if (HacerValidaciones(usuarioActual, titulo, cantidad, totalVenta))
        //    {
        //        usuarioActual.Saldo += totalVenta;

        //        ActualizarActivos(usuarioActual, titulo, cantidad * -1);
        //    }

        //}




        //private static bool HacerValidaciones(Usuario usuarioActual, string titulo, int cantidad, decimal totalCompra)
        //{
        //    bool todook = true;

        //    if (titulo == "")   //validar que haya algun titulo seleccionado
        //    {
        //        Vm.VentanaMensajeError("Selecciona un accion");
        //        todook = false;
        //    }

        //    if (cantidad <= 0)  //validar cantidad mayor a cero
        //    {
        //        Vm.VentanaMensajeError("La cantidad debe ser mayor que 0.");
        //        todook = false;
        //    }

        //    if (usuarioActual.Saldo < totalCompra)  //validar que saldo sea mayor a compra
        //    {
        //        Vm.VentanaMensajeError("Saldo insuficiente.");
        //        todook = false;
        //    }

        //    //cancelar compra
        //    if (todook)
        //    {
        //        if (Vm.VentanaMensajeConfirmar("Confirmar compra?", "") != DialogResult.OK)
        //        {
        //            Vm.VentanaMensaje("Compra", "Cancelada");
        //            todook = false;
        //        }
        //    }
        //    return todook;
        //}




        //private static void ActualizarActivos(Usuario usuarioActual, string titulo, int cantidad)
        //{
        //    Activos nuevoActivo = new Activos();
        //    nuevoActivo.Nombre = titulo;
        //    nuevoActivo.Cantidad = cantidad;
        //    bool encontrada = false;

        //    foreach (Activos a in usuarioActual.ListadoDeActivosPropios)
        //    {
        //        if (a.Nombre == nuevoActivo.Nombre)
        //        {
        //            nuevoActivo.Cantidad += a.Cantidad;
        //            usuarioActual.modificarCartera(usuarioActual, nuevoActivo);
        //            encontrada = true;
        //            break;
        //        }
        //    }
        //    if (!encontrada)
        //    {
        //        DatabaseSQL.comprarActivo(usuarioActual, nuevoActivo);
        //    }
        //    Vm.VentanaMensaje("Transaccion exitosa", $"Adquirido {cantidad}\nde\n{nuevoActivo.Nombre}");
        //}




        //public static void ActivosUsuario(Usuario usuario, string tipo)
        //{
        //    if (usuario.ListadoDeActivosPropios == null)
        //    {
        //        usuario.ListadoDeActivosPropios = new List<Activos>();
        //    }

        //    //List<Activos> lista = DatabaseSQL.CarteraUsuario(usuario, tipo);    //codigo viejo
        //    List<Activos> lista = Usuario.CarteraUsuario(usuario, tipo);

        //    foreach (Activos a in lista)
        //    {
        //        usuario.ListadoDeActivosPropios.Add(a);
        //    }
        //}
        /******************************************************************************************/


        //public static void BajaDeActivosEnCartera(Usuario usuario, Activos activos)
        //{
        //    IUsuarioDao usuarioDao = new UsuarioDao();
        //    usuarioDao.BajasEnCartera(usuario, activos);
        //    //DatabaseSQL.BajasEnCartera(usuario, activos); //codigo viejo
        //}








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
        /// crea las listas de activos adquiridos por el usuario
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="tipo"></param>
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
                        /*******************************************************/
                        /////ver que onda/////////////
                        usuario.ListadoDeActivosPropios.Add(activo);
                        /***********************************************************/
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

        public void ModificarSaldo(Usuario usuario)
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

        public void BajasEnCartera(Usuario usuario, Activos activos)
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

        public void modificarCartera(Usuario usuario, Activos activos)
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
                        Vm.VentanaMensaje("Exito", "Transaccion realizada.");
                    }
                }
            }

        }























    }
}
