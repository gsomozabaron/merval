using merval.DAO;
using MySql.Data.MySqlClient;
using System.Xml.Serialization;


namespace merval.DB
{
    [Serializable]
    [XmlInclude(typeof(Activos))]
    [XmlInclude(typeof(Acciones))]
    [XmlInclude(typeof(Monedas))]

    public class UsuarioSQL : Usuario, IUsuarioSQL
    {
        #region SQL Coneccion
        public static MySqlConnection Connection;

        public static MySqlCommand commandSql;

        static UsuarioSQL()
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
        public UsuarioSQL() : base()
        {
        }

        public UsuarioSQL(string nombre, string dni, string nombreUsuario, string pass, Tipo tipoDeUsuario, decimal saldo, string apellido) : base(nombre, dni, nombreUsuario, pass, tipoDeUsuario, saldo, apellido)
        {
        }

        public UsuarioSQL(int id) : this()
        {
            _id = id;
            ListadoDeActivosPropios = new List<Activos>();
        }

        public UsuarioSQL(int id, string nombre, string dni, string nombreUsuario, string pass,
            Tipo tipoDeUsuario, decimal saldo, string apellido)
            : base(id, nombre, dni, nombreUsuario, pass, tipoDeUsuario, saldo, apellido)
        {
            _id = id;
            _nombre = nombre;
            _dni = dni;
            _tipoDeUsuario = tipoDeUsuario;
            _saldo = saldo;
            _apellido = apellido;
            ListadoDeActivosPropios = new List<Activos>();
        }

        #endregion

        /// crear nuevo usuario
        public static UsuarioSQL CrearUsuario(string nombre, string dni, string nombreUsuario, string pass, Tipo tipoDeUsuario, decimal saldo, string apellido)
        {
            UsuarioSQL nuevoUsuario = new(nombre, dni, nombreUsuario, pass, tipoDeUsuario, saldo, apellido);
            return nuevoUsuario;
        }

        #region metodos interfase
        public async Task ModificarUsuarios()
        {
            int id = Id;
            try
            {
                using (MySqlConnection connection = new MySqlConnection(Connection.ConnectionString))
                {
                    await connection.OpenAsync();

                    string updateQuery = "UPDATE `usuario` SET `Nombre` = @Nombre, `apellido` = @apellido, `Dni` = @dni, `NombreUsuario` = @NombreUsuario, `Saldo` = @Saldo WHERE `id` = @id";

                    using (MySqlCommand cmd = new MySqlCommand(updateQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@Nombre", Nombre);
                        cmd.Parameters.AddWithValue("@apellido", Apellido);
                        cmd.Parameters.AddWithValue("@dni", Dni);
                        cmd.Parameters.AddWithValue("@NombreUsuario", NombreUsuario);
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@Saldo", Saldo);

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
            }
        }

        public async Task AgregarUsuario()
        {

            using (MySqlConnection connection = new MySqlConnection(Connection.ConnectionString))
            {
                await connection.OpenAsync();

                string insertQuery = "INSERT INTO usuario (nombre, dni, nombreUsuario, pass, tipoDeUsuario, saldo, apellido) " +
                                     "VALUES (@nombre, @dni, @nombreUsuario, @pass, @tipoDeUsuario, @saldo, @apellido)";

                using (MySqlCommand cmd = new MySqlCommand(insertQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@nombre", Nombre);
                    cmd.Parameters.AddWithValue("@dni", Dni);
                    cmd.Parameters.AddWithValue("@nombreUsuario", NombreUsuario);
                    cmd.Parameters.AddWithValue("@pass", Pass);
                    cmd.Parameters.AddWithValue("@tipoDeUsuario", TipoDeUsuario);
                    cmd.Parameters.AddWithValue("@saldo", Saldo);
                    cmd.Parameters.AddWithValue("@apellido", Apellido);

                    int filasAfectadas = await cmd.ExecuteNonQueryAsync();

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

        public async Task BajaUsuario()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(Connection.ConnectionString))
                {
                    await connection.OpenAsync();

                    string deleteQuery = "DELETE FROM usuario WHERE id = @UserId";

                    using (MySqlCommand cmd = new MySqlCommand(deleteQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@UserId", Id);

                        int cambioFilas = await cmd.ExecuteNonQueryAsync();

                        if (cambioFilas > 0)
                        {
                            Vm.VentanaMensaje($"Usuario --{NombreUsuario}--\n--{Nombre}--", "dado de baja");
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
            }

        }
        #endregion

        public async static Task<List<UsuarioSQL>> CrearListaDeUsuarios()
        {
            List<UsuarioSQL> lista = new List<UsuarioSQL>();

            try
            {
                await Connection.OpenAsync();
                commandSql.CommandText = string.Empty;
                var query = "SELECT * FROM Usuario";
                commandSql.CommandText = query;

                using var reader = await commandSql.ExecuteReaderAsync();
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


                        UsuarioSQL usuario = new UsuarioSQL(id, nombre, dni, nombreUsuario, pass, tipoDeUsuario, saldo, apellido);

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
        public static List<Activos> CarteraUsuario(UsuarioSQL usuario, string tipo)
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

        public void ModificarSaldo(UsuarioSQL usuario)
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

        public void BajasEnCartera(UsuarioSQL usuario, Activos activos)
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

        public void modificarCartera(UsuarioSQL usuario, Activos activos)
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
