using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using merval.Interfaces;
using merval.Serializadores;
using MySql.Data.MySqlClient;

namespace merval
{
    [Serializable]

    public class Acciones : Activos
    {
        #region constructores atributos y propiedades
        private int _id;

        public Acciones(): base()
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
        public static void ModificarDatos(string nombre, decimal valorCompra, decimal valorVenta, List<Acciones> lista)
        {
            foreach (Acciones a in lista)
            {
                if (a.Nombre == nombre)
                {
                    a.ValorCompra = valorCompra;
                    a.ValorVenta = valorVenta;
                    Serializadora.GuardarGralAcciones(lista);
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
                    Vm.VentanaMensajeError("No se pudo conectar a la DB: " + ex.Message);
                }
                finally
                {
                    Connection.Close();
                }
               

            return lista;
        }





    }
}
