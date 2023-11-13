using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace merval.Interfaces
{
    internal interface IActivosDao
    {
        public void comprarActivo(Usuario usuario, Activos activos);

        public DataTable MostrarActivos(string tipo);

        public void InsertarActivo(string tipo, Activos activo);

        public void EliminarActivo(Activos activos, string tipo);

        public void ModificarActivo(string tipo, string nombre, decimal valorCompra, decimal valorVenta, string id);

        public List<Activos> CrearListaDeActivos(string tipo);

        public List<Acciones> CrearListaActivo();

        public List<Acciones> CrearListaAcciones();

        public  List<Monedas> CrearListaMonedas();




    }
}
