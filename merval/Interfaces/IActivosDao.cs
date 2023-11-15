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
        public Task comprarActivo(Usuario usuario, Activos activos);

        public DataTable MostrarActivos(string tipo);

        public Task InsertarActivo(string tipo, Activos activo);

        public Task EliminarActivo(Activos activos, string tipo);

        public Task ModificarActivo(string tipo, string nombre, decimal valorCompra, decimal valorVenta, string id);

        public List<Activos> CrearListaDeActivos(string tipo);





    }
}
