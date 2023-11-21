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


        /// <summary>
        /// /// crea una lista con las monedas, retorna una lista de monedas
        /// </summary>
        /// <returns>lista de monedas</returns>
        public static async Task<List<Monedas>> CrearListaMonedas()
        {
            List<Monedas> lista = new List<Monedas>();
            try
            {
                await Connection.OpenAsync();

                commandSql.CommandText = string.Empty;
                var query = "SELECT * FROM Monedas";
                commandSql.CommandText = query;

                using (var reader = await commandSql.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
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


    }
}
