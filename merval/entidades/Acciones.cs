using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using merval.Serializadores;

namespace merval
{
    [Serializable]
    public class Acciones : Activos
    {
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

        public static Acciones CrearAccion(string titulo, decimal valorCompra, decimal valorVenta)
        {
            int cantidad = 0;
            Acciones nuevaAccion = new Acciones(titulo, valorCompra, valorVenta, cantidad);
         
            return nuevaAccion;
        }

        //public static void ModificarDatos(string nombre, decimal valorCompra, decimal valorVenta, List<Acciones> lista)
        //{
        //    foreach (Acciones a in lista)
        //    {
        //        if (a.Nombre == nombre)
        //        {
        //            a.ValorCompra = valorCompra;
        //            a.ValorVenta = valorVenta;
        //            Serializadora.GuardarGralAcciones(lista);
        //            break;
        //        }
        //    }
        //}

        




    }
}
