using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using merval.Interfaces;
using merval.Serializadores;

namespace merval
{
    [Serializable]
    public class Monedas : Activos, IActivosDao
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



        public void comprarActivo(Usuario usuario, Activos activos)
        {
            throw new NotImplementedException();
        }

        public List<Acciones> CrearListaAcciones()
        {
            throw new NotImplementedException();
        }

        public List<Acciones> CrearListaActivo()
        {
            throw new NotImplementedException();
        }

        public List<Activos> CrearListaDeActivos(string tipo)
        {
            throw new NotImplementedException();
        }

        public List<Monedas> CrearListaMonedas()
        {
            throw new NotImplementedException();
        }

        public void EliminarActivo(Activos activos, string tipo)
        {
            throw new NotImplementedException();
        }

        public void InsertarActivo(string tipo, Activos activo)
        {
            throw new NotImplementedException();
        }

        public void ModificarActivo(string tipo, string nombre, decimal valorCompra, decimal valorVenta, string id)
        {
            throw new NotImplementedException();
        }

        public DataTable MostrarActivos(string tipo)
        {
            throw new NotImplementedException();
        }
    }
}
