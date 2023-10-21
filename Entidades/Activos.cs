using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
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
    }
}
