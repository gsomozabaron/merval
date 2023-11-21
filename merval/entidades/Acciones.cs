using merval.Excepciones;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace merval
{
    [Serializable]

    public class Acciones : Activos
    {
        #region constructores atributos y propiedades
        private int _id;

        public Acciones() : base()
        {
        }

        public Acciones(string nombre, decimal valorCompra, decimal valorVenta, int cantidad) : base(nombre, valorCompra, valorVenta, cantidad)
        {
        }

        public Acciones(int id, string nombre, decimal valorCompra, decimal valorVenta, int cantidad) : base(nombre, valorCompra, valorVenta, cantidad)
        {
            Id = id;
        }

        public int Id { get => _id; set => _id = value; }
        #endregion


        public static Acciones CrearAccion(string titulo, decimal valorCompra, decimal valorVenta)
        {
            int cantidad = 0;
            Acciones nuevaAccion = new Acciones(titulo, valorCompra, valorVenta, cantidad);

            return nuevaAccion;
        }

        /// <summary>
        /// para trabajars offline con archivos xml
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="valorCompra"></param>
        /// <param name="valorVenta"></param>
        /// <param name="lista"></param>



        #region data de coneccion sql

        public static MySqlConnection Connection;

        public static MySqlCommand commandSql;

        /// <summary>
        /// data de coneccion mysql
        /// </summary>
        static Acciones()
        {
            var SqlStringConnection = @"Server=localhost;Database=merval;Uid=root;Pwd=;";
            Connection = new MySqlConnection(SqlStringConnection);

            commandSql = new MySqlCommand();
            commandSql.CommandType = System.Data.CommandType.Text;
            commandSql.Connection = Connection;
        }
        #endregion

        /// <summary>
        /// crea una lista con las acciones, retorna una lista de acciones
        /// </summary>
        /// <returns>lista de acciones</returns>
        public static async Task<List<Acciones>> CrearListaAcciones()
        {
            List<Acciones> lista = new List<Acciones>();
            try
            {
                await Connection.OpenAsync();
                commandSql.CommandText = string.Empty;
                var query = "SELECT * FROM Acciones";
                commandSql.CommandText = query;

                using (var reader = await commandSql.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
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
                string mensaje = "No se pudo conectar a la DB: ";
                Vm.VentanaMensajeError("No se pudo conectar a la DB: " + ex.Message);
                ReporteExcepciones.CrearErrorLog("Acciones", ex, mensaje);
            }
            finally
            {
                Connection.Close();
            }
            return lista;
        }
    }
}
