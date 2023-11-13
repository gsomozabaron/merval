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

namespace merval
{
    [Serializable]
    public class Acciones : Activos, IActivosDao
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


        #region metodos interfase
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

        #endregion
    }
}
