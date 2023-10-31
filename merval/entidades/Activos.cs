using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace merval
{
    [Serializable]
    public abstract class Activos
    {
        private string nombre;
        private decimal valorCompra;
        private decimal valorVenta;
        private int cantidad;

        public Activos()
        {
        }

        public Activos(string nombre, decimal valorCompra, decimal valorVenta, int cantidad)
        {
            this.nombre = nombre;
            this.valorCompra = valorCompra;
            this.valorVenta = valorVenta;
            this.cantidad = cantidad;
        }

        public string Nombre { get => nombre; set => nombre = value; }
        public decimal ValorCompra { get => valorCompra; set => valorCompra = value; }
        public decimal ValorVenta { get => valorVenta; set => valorVenta = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }   



    }
}
