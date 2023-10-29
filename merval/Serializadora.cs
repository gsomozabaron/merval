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
        /// <param name="path">ubicación relativa al directorio del proyecto>
        /// <param name="lista">listadoDeUsuarios</param>
        public static void GuardarListadoUsuarios(List<Usuario> lista)
        {
            //string path = @"E:\utnprogramacion1\2do cuatrimestre\progra 2B\merval\archivos\listaUsuarios.xml";
            string path = Path.Combine(Application.StartupPath, "listaUsuarios.xml");//guardar archivos en la ubicación relativa al directorio del proyecto
            using (StreamWriter streamWriter = new StreamWriter(path))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Usuario>));
                serializer.Serialize(streamWriter, lista);
            }
        }

        /// <summary>
        /// leer XML lista de usuarios en listaUsuarios.xml
        /// </summary>
        /// <param name="path">ubicación relativa al directorio del proyecto>
        /// <returns>listadoDeUsuarios</returns>
        public static List<Usuario> LeerListadoUsuarios()
        {
            //string path = @"E:\utnprogramacion1\2do cuatrimestre\progra 2B\merval\archivos\listaUsuarios.xml";
            string path = Path.Combine(Application.StartupPath, "listaUsuarios.xml");//guardar archivos en la ubicación relativa al directorio del proyecto
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
            //string path = @"E:\utnprogramacion1\2do cuatrimestre\progra 2B\merval\archivos\listaAcciones.xml";
            string path = Path.Combine(Application.StartupPath, "listaAcciones.xml");//guardar archivos en la ubicación relativa al directorio del proyecto

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
            //string path = @"E:\utnprogramacion1\2do cuatrimestre\progra 2B\merval\archivos\listaAcciones.xml";
            string path = Path.Combine(Application.StartupPath, "listaAcciones.xml"); //guardar archivos en la ubicación relativa al directorio del proyecto

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


        public static void CopiarArchivos()
        {
            string sourceDirectory = @"E:\utnprogramacion1\2do cuatrimestre\progra 2B\merval\archivos";
            string destinationDirectory = Path.Combine(Application.StartupPath, "Archivos");

            // Verifica si la carpeta de destino no existe y créala si es necesario
            if (!Directory.Exists(destinationDirectory))
            {
                Directory.CreateDirectory(destinationDirectory);
            }

            // Obtiene una lista de archivos en la carpeta de origen
            string[] files = Directory.GetFiles(sourceDirectory);

            // Copia cada archivo desde la carpeta de origen a la carpeta de destino
            foreach (string file in files)
            {
                string fileName = Path.GetFileName(file);
                string destinationPath = Path.Combine(destinationDirectory, fileName);
                File.Copy(file, destinationPath, true); // El tercer argumento (true) permite sobrescribir si ya existe el archivo en la carpeta de destino
            }

        }
    }
}
