using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace merval
{
    [Serializable]
    public class Monedas : Activos
    {
        private int cantidad;

        public Monedas() : base()
        {
        }

        public Monedas(string nombre, decimal valorCompra, decimal valorVenta, int cantidad) : base(nombre, valorCompra, valorVenta, cantidad)
        {
        }

        public static void CrearMoneda(string titulo, decimal valorCompra, decimal valorVenta, List<Monedas> listaMonedasGral)
        {
            if (listaMonedasGral == null)
            {
                listaMonedasGral = new List<Monedas>();
            }
            int cantidad = 0;
            Monedas nuevaMoneda = new Monedas(titulo, valorCompra, valorVenta, cantidad);
            listaMonedasGral.Add(nuevaMoneda);

            Serializadora.GuardarGralMonedas(listaMonedasGral);

        }

        public static void ModificarDatos (string nombre, decimal valorCompra, decimal valorVenta, List<Monedas> lista)
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
        
    }
}
