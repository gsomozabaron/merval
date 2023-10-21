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
            string path = @"E:\utnprogramacion1\2do cuatrimestre\progra 2B\merval\archivos\listaUsuarios.xml";
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

        /// guardar XML lista de usuarios en listaAcciones.txt

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
        /// leer XML lista de usuarios en listaAcciones.txt
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


        //////////Historial de acciones///////////////
        
        /// para generar un historial de 7 dias de valores de acciones random a efectos de mostrar los graficos de los nugets
 
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
                    nuevaAccion.ValorCompra = random.Next(0, 1000);
                    nuevaAccion.ValorVenta = random.Next(0, 1000);
                    nuevaAccion.Nombre = acc.Nombre;
                    historicoAcciones.Add(nuevaAccion);
                    dias++;
                }
            }

            GuardarHistorialAcciones(historicoAcciones);
        }
       
        /// leer historico desde archivo 
        public static List<Acciones> CargarHistoricoAcciones()
        {
            string path = @"E:\utnprogramacion1\2do cuatrimestre\progra 2B\merval\archivos\historialAcciones.xml";

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
       
        /// guardar en un archivo el historico
        public static void GuardarHistorialAcciones(List<Acciones> lista)
        {
            string path = @"E:\utnprogramacion1\2do cuatrimestre\progra 2B\merval\archivos\historialAcciones.xml";

            using (StreamWriter streamWriter = new StreamWriter(path))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Acciones>));
                serializer.Serialize(streamWriter, lista);
            }
        }



        public static void GuardarHistorialordenado(List<string> historial)
        {
            string path = @"E:\utnprogramacion1\2do cuatrimestre\progra 2B\merval\archivos\historialOrdenado.xml";

            using (StreamWriter streamWriter = new StreamWriter(path))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<string>));
                serializer.Serialize(streamWriter, historial);
            }
        }
        public static List<string> CargarHistoricoOrdenado()
        {
            string path = @"E:\utnprogramacion1\2do cuatrimestre\progra 2B\merval\archivos\historialOrdenado.xml";

            List<string> lista = null;

            if (File.Exists(path))
            {
                using (StreamReader streamReader = new StreamReader(path))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(List<string>));
                    lista = (List<string>)serializer.Deserialize(streamReader);
                }
            }
            return lista;
        }
    }
}
