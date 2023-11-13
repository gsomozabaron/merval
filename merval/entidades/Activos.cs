using merval.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace merval
{
    [Serializable]
    public class Activos 
    {
        #region constructores atributos y propiedades
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


        public Activos(string nombre, int cantidad)
        {
            this.nombre = nombre;
            this.cantidad = cantidad;
        }

        public string Nombre { get => nombre; set => nombre = value; }
        
        public decimal ValorCompra { get => valorCompra; set => valorCompra = value; }
        
        public decimal ValorVenta { get => valorVenta; set => valorVenta = value; }
        
        public int Cantidad { get => cantidad; set => cantidad = value; }


        public static bool operator ==(Activos activo1, Activos activo2)
        {
            if (ReferenceEquals(activo1, activo2))
            {
                return true;
            }

            if (ReferenceEquals(activo1, null) || ReferenceEquals(activo2, null))
            {
                return false;
            }

            return activo1.nombre == activo2.nombre;
        }

        public static bool operator !=(Activos activo1, Activos activo2)
        {
            return !(activo1 == activo2);
        }
        #endregion




       






    }
}
