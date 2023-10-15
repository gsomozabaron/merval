using Entidades;
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
        /// grabar XML lista de usuarios en listaUsuarios.txt
        /// </summary>
        /// <param name="path">@"E:\utnprogramacion1\2do cuatrimestre\progra 2B\merval\archivos\listaUsuarios.txt"</param>
        /// <param name="lista">listadoDeUsuarios</param>
        public static void GuardarListadoUsuarios(List<Usuario> lista)
        {
            string path = @"E:\utnprogramacion1\2do cuatrimestre\progra 2B\merval\archivos\listaUsuarios.txt";
            using (StreamWriter streamWriter = new StreamWriter(path))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Usuario>));
                serializer.Serialize(streamWriter, lista);
            }
        }

        /// <summary>
        /// leer XML lista de usuarios en listaUsuarios.txt
        /// </summary>
        /// <param name="path">@"E:\utnprogramacion1\2do cuatrimestre\progra 2B\merval\archivos\listaUsuarios.txt"</param>
        /// <returns>listadoDeUsuarios</returns>
        public static List<Usuario> LeerListadoUsuarios()
        {
            string path = @"E:\utnprogramacion1\2do cuatrimestre\progra 2B\merval\archivos\listaUsuarios.txt";
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



        /////////diccionario usuario pass para el log in////////
        #region borrar esta parte, ya no se usa
        /// grabar diccionario Json, pares usuario-pass del login
        /// <param name="path">@"E:\utnprogramacion1\2do cuatrimestre\progra 2B\merval\archivos\UsuariosLogin.txt"</param>
        /// <param name="dict">dictUsuarioPassword</param>
        //public static void Grabar_dict_login(Dictionary<string, string> dict)
        //{
        //    string path = @"E:\utnprogramacion1\2do cuatrimestre\progra 2B\merval\archivos\UsuariosLogin.txt";
        //    string json = JsonConvert.SerializeObject(dict);

        //    using (StreamWriter streamWriter = new StreamWriter(path))
        //    {
        //        streamWriter.Write(json);
        //    }
        //}

        ///// <summary>
        ///// Leer diccionario Json, pares usuario-pass del login
        ///// </summary>
        ///// <param name="path">@"E:\utnprogramacion1\2do cuatrimestre\progra 2B\merval\archivos\UsuariosLogin.txt"</param>
        ///// <returns>Dictionary<string,string> dictUsuarioPassword</returns>
        //public static Dictionary<string, string> LeerDictLogin()
        //{
        //    string path = @"E:\utnprogramacion1\2do cuatrimestre\progra 2B\merval\archivos\UsuariosLogin.txt";
        //    Dictionary<string, string> dict = null;

        //    if (File.Exists(path))
        //    {
        //        string json = File.ReadAllText(path);
        //        dict = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
        //    }
        //    return dict;
        //}
        #endregion


        ////////////listados de acciones general////////////
        /// <summary>
        /// guardar XML lista de usuarios en listaAcciones.txt
        /// </summary>
        /// <param name="lista">/param>
        public static void GuardarGralAcciones(List<Acciones> lista)
        {
            string path = @"E:\utnprogramacion1\2do cuatrimestre\progra 2B\merval\archivos\listaAcciones.txt";

            using (StreamWriter streamWriter = new StreamWriter(path))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Acciones>));
                serializer.Serialize(streamWriter, lista);
            }
        }

        /// <summary>
        /// leer XML lista de usuarios en listaAcciones.txt
        /// </summary>
        /// <returns>listadoDeUsuarios</returns>
        public static List<Acciones> LeerListaAcciones()
        {
            string path = @"E:\utnprogramacion1\2do cuatrimestre\progra 2B\merval\archivos\listaAcciones.txt";

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
        


















        public static void GuardarListadoUsuarios2(List<Usuario> lista)
        {
            string path = @"E:\utnprogramacion1\2do cuatrimestre\progra 2B\merval\archivos\UsuariosTemporal.txt";
            using (StreamWriter streamWriter = new StreamWriter(path))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Usuario>));
                serializer.Serialize(streamWriter, lista);
            }
        }
        public static void Grabar_dict_login2(Dictionary<string, string> dict)
        {
            string path = @"E:\utnprogramacion1\2do cuatrimestre\progra 2B\merval\archivos\Login2.txt";
            string json = JsonConvert.SerializeObject(dict);

            using (StreamWriter streamWriter = new StreamWriter(path))
            {
                streamWriter.Write(json);
            }
        }

    }
}
