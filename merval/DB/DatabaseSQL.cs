using merval.DAO;
using merval.entidades;
using merval.Serializadores;
using Microsoft.VisualBasic;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace merval.DB
{
    public class DatabaseSQL
    {
        
        public static MySqlConnection Connection;

        public static MySqlCommand commandSql;

        /// <summary>
        /// data de coneccion mysql
        /// </summary>
        static DatabaseSQL()
        {
            var SqlStringConnection = @"Server=localhost;Database=merval;Uid=root;Pwd=;";
            Connection = new MySqlConnection(SqlStringConnection);

            commandSql = new MySqlCommand();
            commandSql.CommandType = System.Data.CommandType.Text;
            commandSql.Connection = Connection;
        }

        /// <summary>
        /// para cargar las listas desde XML por primera vez
        /// </summary>
        //public static void CargaSQL()
        //{
        //    List<Usuario> listu = Serializadora.LeerListadoUsuarios();
        //    foreach (Usuario usuario in listu)
        //    {
        //        //InsertarUsuario(usuario);

        //        foreach (Activos a in usuario.ListadoDeActivosPropios)
        //        {
        //            //InsertarActivosPropios(usuario, a);
        //        }
        //    }

        //    List<Monedas> listm = Serializadora.LeerListaMonedas();
        //    foreach (Monedas m in listm)
        //    {
        //        //InsertarMonedas(m);
        //    }

        //    List<Acciones> lista = Serializadora.LeerListaAcciones();
        //    foreach (Acciones a in lista)
        //    {
        //        //InsertarAcciones(a);
        //    }

        

    }
}
