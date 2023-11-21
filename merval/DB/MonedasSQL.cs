using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace merval.DB
{
    internal class MonedasSQL
    {



        /*
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
        */

    }
}
