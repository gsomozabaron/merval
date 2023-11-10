using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using merval.Serializadores;

namespace merval
{
    [Serializable]
    public class Monedas : Activos
    {

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

        public static Monedas CrearMoneda(string titulo, decimal valorCompra, decimal valorVenta)
        {
            int cantidad = 0;
            Monedas nuevaMoneda = new Monedas(titulo, valorCompra, valorVenta, cantidad);

            return nuevaMoneda;
        }


        //public static void ModificarDatos (string nombre, decimal valorCompra, decimal valorVenta, List<Monedas> lista)
        //{
        //    foreach (Monedas a in lista)
        //    {
        //        if (a.Nombre == nombre)
        //        {
        //            a.ValorCompra = valorCompra;
        //            a.ValorVenta = valorVenta;
        //            Serializadora.GuardarGralMonedas(lista);
        //            break;
        //        }
        //    }
        //}
        
    }
}
