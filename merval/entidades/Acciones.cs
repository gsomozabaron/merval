using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;



namespace merval
{
    public class Acciones : Activos
    {
        private DateTime fecha;
        private int cantidad;
      
        public Acciones(): base()
        {

        }
        public Acciones(string nombre, decimal valorCompra, decimal valorVenta) : base(nombre, valorCompra, valorVenta)  
        {

        }


        public Acciones(string nombre, decimal valorCompra, decimal valorVenta, DateTime fecha, int cantidad) : base(nombre, valorCompra, valorVenta)
        {
            this.fecha = fecha; 
            this.cantidad = cantidad;
        }

        
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }

        public static void CrearAccion(string titulo,decimal valorCompra,decimal valorVenta, List<Acciones> listaAccionesGral)
        {
            Acciones nuevaAccion = new Acciones(titulo, valorCompra, valorVenta);     
            listaAccionesGral.Add(nuevaAccion);

            Serializadora.GuardarGralAcciones(listaAccionesGral);

        }

    }
}
