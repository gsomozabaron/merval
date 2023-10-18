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




        /// <summary>
        /// actualiza el usuario con sus atributos en el listado y graba a archivo
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="lista"></param>
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

        

        /// <summary>
        /// para generar un historial de 7 dias de valores de acciones random a efectos de mostrar los graficos de los nugets
        /// </summary>
        public static void HistorialAcciones()
        {
            List<Acciones> lista = LeerListaAcciones();
            List<Acciones> historicoAcciones = new List<Acciones>();

            Random random = new Random(); 

            for (int i = 0; i < 7; i++)
            {
                int dias = 1; 
                foreach (Acciones acc in lista)
                {
                    Acciones nuevaAccion = new Acciones(); 
                    nuevaAccion.Fecha = DateTime.Now - TimeSpan.FromDays(dias);
                    nuevaAccion.Valor = random.Next(0, 1000).ToString();  
                    nuevaAccion.Nombre = acc.Nombre;    
                    historicoAcciones.Add(nuevaAccion);
                    dias++;
                }
            }

            GuardarHistorialAcciones(historicoAcciones);
        }
        /// <summary>
        /// leer historico desde archivo
        /// </summary>
        /// <returns></returns>
        public static List<Acciones> CargarHistoricoAcciones()
        {
            string path = @"E:\utnprogramacion1\2do cuatrimestre\progra 2B\merval\archivos\historialAcciones.txt";

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
        /// <summary>
        /// guardar en un archivo el historico
        /// </summary>
        /// <param name="lista"></param>
        public static void GuardarHistorialAcciones(List<Acciones> lista)
        {
            string path = @"E:\utnprogramacion1\2do cuatrimestre\progra 2B\merval\archivos\historialAcciones.txt";

            using (StreamWriter streamWriter = new StreamWriter(path))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Acciones>));
                serializer.Serialize(streamWriter, lista);
            }
        }


    }
}
