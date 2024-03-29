﻿using merval.DB;
using System.Data;

namespace merval.Interfaces
{
    internal interface IActivosSQL
    {
        public Task comprarActivo(UsuarioSQL usuario, Activos activos);

        public Task<DataTable> MostrarActivos(string tipo);

        public Task InsertarActivo(string tipo, Activos activo);

        public Task EliminarActivo(Activos activos, string tipo);

        public Task ModificarActivo(string tipo, string nombre, decimal valorCompra, decimal valorVenta, string id);

        public Task<List<Activos>> CrearListaDeActivos(string tipo);





    }
}
