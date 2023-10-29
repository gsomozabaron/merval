using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace merval
{
    public class Activos
    {
        private string nombre;
        private decimal valorCompra;
        private decimal valorVenta;

        public Activos()
        {
        }

        public Activos(string nombre, decimal valorCompra, decimal valorVenta)
        {
            this.nombre = nombre;
            this.valorCompra = valorCompra;
            this.valorVenta = valorVenta;
        }

        public string Nombre { get => nombre; set => nombre = value; }
        public decimal ValorCompra { get => valorCompra; set => valorCompra = value; }
        public decimal ValorVenta { get => valorVenta; set => valorVenta = value; }

        public static void ModificarDato(string nombre, decimal valorCompra, decimal valorVenta, List<Activos> lista)
        {
            foreach (var activo in lista)
            {
                if (activo.Nombre == nombre)
                {
                    activo.ValorCompra = valorCompra;
                    activo.ValorVenta = valorVenta;
                } 
            }
        }
    }
}
