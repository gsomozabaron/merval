using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using merval.entidades;
using Newtonsoft.Json;


namespace merval
{
    public class Serializadora
    {
        //////////// listado general de usuarios ///////////////
      
        // grabar XML lista de usuarios en listaUsuarios.xml
        public static void GuardarListadoUsuarios(List<Usuario> lista)
        {
            string path = Path.Combine(Application.StartupPath, "listaUsuarios.xml");//guardar archivos en la ubicación relativa al directorio del proyecto
            using (StreamWriter streamWriter = new StreamWriter(path))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Usuario>));
                serializer.Serialize(streamWriter, lista);
            }
        }

        // leer XML lista de usuarios en listaUsuarios.xml
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
                    u.ListadoDeActivosPropios = usuario.ListadoDeActivosPropios;
                    u.Saldo = usuario.Saldo;
                    break;
                }
            }
            Serializadora.GuardarListadoUsuarios(lista);
        }


        /// ////////////////////// guardar lista monedas //////////////////////
        public static void GuardarGralMonedas(List<Monedas> lista)
        {
            string path = Path.Combine(Application.StartupPath, "listaMonedas.xml");//guardar archivos en la ubicación relativa al directorio del proyecto

            using (StreamWriter streamWriter = new StreamWriter(path))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Monedas>));
                serializer.Serialize(streamWriter, lista);
            }
        }

        public static List<Monedas> LeerListaMonedas()
        {
            //string path = @"E:\utnprogramacion1\2do cuatrimestre\progra 2B\merval\archivos\listaAcciones.xml";
            string path = Path.Combine(Application.StartupPath, "listaMonedas.xml"); //guardar archivos en la ubicación relativa al directorio del proyecto

            List<Monedas> lista = null;

            if (File.Exists(path))
            {
                using (StreamReader streamReader = new StreamReader(path))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(List<Monedas>));
                    lista = (List<Monedas>)serializer.Deserialize(streamReader);
                }
            }
            return lista;
        }

    }
}
