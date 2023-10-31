using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


namespace merval
{
    [Serializable]
    public class Acciones : Activos
    {
      
        public Acciones(): base()
        {
        }

        public Acciones(string nombre, decimal valorCompra, decimal valorVenta, int cantidad) : base(nombre, valorCompra, valorVenta, cantidad)  
        {
        }


        public static void CrearAccion(string titulo,decimal valorCompra,decimal valorVenta,int cantidad ,List<Acciones> listaAccionesGral)
        {
            Acciones nuevaAccion = new Acciones(titulo, valorCompra, valorVenta, cantidad);     
            listaAccionesGral.Add(nuevaAccion);

            Serializadora.GuardarGralAcciones(listaAccionesGral);
        }

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


        


        //public override void CrearAcciones
        //    (string titulo, decimal valorCompra, decimal valorVenta, List<Acciones> listaAccionesGral)
        //{
            
        //    Acciones nuevaAccion = new Acciones(titulo, valorCompra, valorVenta);
        //    listaAccionesGral.Add(nuevaAccion);

        //    Serializadora.GuardarGralAcciones(listaAccionesGral);
        //}

        //public override void ModificarDato
        //    (string nombre, decimal valorCompra, decimal valorVenta, List<Acciones> lista)
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
