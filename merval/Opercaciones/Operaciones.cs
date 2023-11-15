using merval.DB;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace merval.Opercaciones
{

    public class Operaciones
    {
        public static MySqlConnection Connection;

        public static MySqlCommand commandSql;

        static Operaciones()
        {
            var SqlStringConnection = @"Server=localhost;Database=merval;Uid=root;Pwd=;";
            Connection = new MySqlConnection(SqlStringConnection);

            commandSql = new MySqlCommand();
            commandSql.CommandType = System.Data.CommandType.Text;
            commandSql.Connection = Connection;
        }

        /// <summary>
        /// logica de venta de activos
        /// </summary>
        /// <param name="usuarioActual">usuario en uso</param>
        /// <param name="tipoDeActivo">tipo de activo</param>
        /// <param name="Ventastr">total de venta, info almacenada en lbl totalventa</param>
        /// <param name="titulo">nombre del activo</param>
        /// <param name="cantidadStr">cantidad a vender</param>
        /// <returns>retorna true si se pudo hacer la transaccion, false si hubo algun error</returns>
        public static bool VentaDeActivos(Usuario usuarioActual, string tipoDeActivo, string Ventastr, string titulo, string cantidadStr)
        {
            bool resultado = true;

            try
            {
                //Usuario.CarteraUsuario(usuarioActual, tipoDeActivo);
                Operaciones.CarteraUsuario(usuarioActual, tipoDeActivo);
                decimal totalVenta = decimal.Parse(Ventastr);

                usuarioActual.Saldo = usuarioActual.Saldo + totalVenta;

                foreach (Activos a in usuarioActual.ListadoDeActivosPropios)
                {
                    if (a.Nombre == titulo && int.Parse(cantidadStr) <= a.Cantidad)
                    {
                        if (Vm.VentanaMensajeConfirmar("Comfirmar venta?", $"{cantidadStr} de: {titulo}") == DialogResult.OK)
                        {
                            a.Cantidad = a.Cantidad - int.Parse(cantidadStr);
                            if (a.Cantidad == 0)
                            {
                                usuarioActual.BajasEnCartera(usuarioActual, a);
                            }
                            else
                            {
                                usuarioActual.modificarCartera(usuarioActual, a);
                            }

                            usuarioActual.ModificarSaldo(usuarioActual);
                            break;
                        }
                        else
                        {
                            Vm.VentanaMensaje("Venta", "cancelada");
                            resultado = false;
                        }
                    }
                    else
                    {
                        if (a.Nombre == titulo && int.Parse(cantidadStr) > a.Cantidad)
                        {
                            Vm.VentanaMensajeError($"maximo {a.Cantidad}\nde {a.Nombre}");
                            break;
                            resultado = false;
                        }
                    }
                }

            }
            catch (Exception)
            {
                Vm.VentanaMensajeError("Faltan datos");
                resultado = false;
            }

            return resultado;
        }

        /// <summary>
        /// logica de compra de activos añade acciones a la lista de acciones de un usuario
        /// </summary>
        /// <param name="usuarioActual">usuario logueado</param>
        /// <param name="titulo">nombre del activo</param>
        /// <param name="cantidad">cantidad a comprar</param>
        /// <param name="totalCompra">total de la compra</param>
        /// <param name="tipo">tipo de activo</param>
        /// <returns></returns>
        public static bool CompraDeActivos(Usuario usuarioActual, string titulo, int cantidad, decimal totalCompra, string tipo)
        {
            bool resultado = true;
            try
            {
                if (HacerValidaciones(usuarioActual, titulo, cantidad, totalCompra))
                {
                    usuarioActual.Saldo -= totalCompra;

                    if (usuarioActual.ListadoDeActivosPropios == null)
                    {
                        usuarioActual.ListadoDeActivosPropios = new List<Activos>();
                    }
                    usuarioActual.ModificarSaldo(usuarioActual);
                    ActualizarActivos(usuarioActual, titulo, cantidad);
                }
            }
            catch (Exception)
            {

                throw;
            }


            return resultado;
        }
  
        private static void ActualizarActivos(Usuario usuarioActual, string titulo, int cantidad)
        {
            Activos nuevoActivo = new Activos();
            nuevoActivo.Nombre = titulo;
            nuevoActivo.Cantidad = cantidad;
            bool encontrada = false;

            foreach (Activos a in usuarioActual.ListadoDeActivosPropios)
            {
                if (a.Nombre == nuevoActivo.Nombre)
                {
                    nuevoActivo.Cantidad += a.Cantidad;
                    usuarioActual.modificarCartera(usuarioActual, nuevoActivo);
                    encontrada = true;
                    break;
                }
            }
            if (!encontrada)
            {
                nuevoActivo.comprarActivo(usuarioActual, nuevoActivo);
            }
            Vm.VentanaMensaje("Transaccion exitosa", $"Adquirido {cantidad}\nde\n{nuevoActivo.Nombre}");
        }

        private static bool HacerValidaciones(Usuario usuarioActual, string titulo, int cantidad, decimal totalCompra)
        {
            bool todook = true;

            if (titulo == "")   //validar que haya algun titulo seleccionado
            {
                Vm.VentanaMensajeError("Selecciona un accion");
                todook = false;
            }

            if (cantidad <= 0)  //validar cantidad mayor a cero
            {
                Vm.VentanaMensajeError("La cantidad debe ser mayor que 0.");
                todook = false;
            }

            if (usuarioActual.Saldo < totalCompra)  //validar que saldo sea mayor a compra
            {
                Vm.VentanaMensajeError("Saldo insuficiente.");
                todook = false;
            }
            //cancelar compra
            if (todook)
            {
                if (Vm.VentanaMensajeConfirmar("Confirmar compra?", "") != DialogResult.OK)
                {
                    Vm.VentanaMensaje("Compra", "Cancelada");
                    todook = false;
                }
            }
            return todook;

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
