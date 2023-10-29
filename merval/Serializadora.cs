using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Newtonsoft.Json;


namespace merval
{
    public class Serializadora
    {
        //////////// listado general de usuarios ///////////////
        /// <summary>
        /// grabar XML lista de usuarios en listaUsuarios.xml
        /// </summary>
        /// <param name="path">@"E:\utnprogramacion1\2do cuatrimestre\progra 2B\merval\archivos\listaUsuarios.txt"</param>
        /// <param name="lista">listadoDeUsuarios</param>
        public static void GuardarListadoUsuarios(List<Usuario> lista)
        {
            string path = @"E:\utnprogramacion1\2do cuatrimestre\progra 2B\merval\archivos\listaUsuarios.xml";
            using (StreamWriter streamWriter = new StreamWriter(path))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Usuario>));
                serializer.Serialize(streamWriter, lista);
            }
        }

        /// <summary>
        /// leer XML lista de usuarios en listaUsuarios.xml
        /// </summary>
        /// <param name="path">@"E:\utnprogramacion1\2do cuatrimestre\progra 2B\merval\archivos\listaUsuarios.txt"</param>
        /// <returns>listadoDeUsuarios</returns>
        public static List<Usuario> LeerListadoUsuarios()
        {
            string path = @"E:\utnprogramacion1\2do cuatrimestre\progra 2B\merval\archivos\listaUsuarios.xml";
            List<Usuario> lista = null;

            if (File.Exists(path))
            {
                using (StreamReader streamReader = new StreamReader(path))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(List<Usuario>));
                    lista = (List<Usuario>)serializer.Deserialize(streamReader);
                }
            }
            return lista;
        }




        ////////////listados de acciones general////////////

        /// guardar XML lista de usuarios en listaAcciones.xml

        public static void GuardarGralAcciones(List<Acciones> lista)
        {
            string path = @"E:\utnprogramacion1\2do cuatrimestre\progra 2B\merval\archivos\listaAcciones.xml";

            using (StreamWriter streamWriter = new StreamWriter(path))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Acciones>));
                serializer.Serialize(streamWriter, lista);
            }
        }

        /// <summary>
        /// leer XML lista de usuarios en listaAcciones.xml
        /// </summary>
        /// <returns>listadoDeUsuarios</returns>
        public static List<Acciones> LeerListaAcciones()
        {
            string path = @"E:\utnprogramacion1\2do cuatrimestre\progra 2B\merval\archivos\listaAcciones.xml";

            List<Acciones> lista = null;

            if (File.Exists(path))
            {
                using (StreamReader streamReader = new StreamReader(path))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(List<Acciones>));
                    lista = (List<Acciones>)serializer.Deserialize(streamReader);
                }
            }
            return lista;
        }




        /// actualiza el usuario con sus atributos en el listado y graba a archivo
        public static void ActualizarUsuario(Usuario usuario, List<Usuario> lista)
        {
            foreach (Usuario u in lista)
            {
                if (u.NombreUsuario == usuario.NombreUsuario)
                {
                    u.ListadoDeAccionesPropias = usuario.ListadoDeAccionesPropias;
                    u.Saldo = usuario.Saldo;
                }
            }
            Serializadora.GuardarListadoUsuarios(lista);
        }

    }
}
