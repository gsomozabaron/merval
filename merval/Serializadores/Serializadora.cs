using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using merval.DB;
using merval.entidades;
using Newtonsoft.Json;


namespace merval.Serializadores
{
    public class Serializadora
    {
       
        /*********************leer xml *********************************/

        /// <summary>
        /// leer XML lista de usuarios en listaUsuarios.xml
        /// </summary>
        /// <returns></returns>
        private static List<UsuarioSQL> LeerListadoUsuarios()
        {
            string path = Path.Combine(Application.StartupPath, "listaUsuarios.xml");//guardar archivos en la ubicación relativa al directorio del proyecto
            List<UsuarioSQL> lista = null;

            if (File.Exists(path))
            {
                using (StreamReader streamReader = new StreamReader(path))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(List<UsuarioSQL>));
                    lista = (List<UsuarioSQL>)serializer.Deserialize(streamReader);
                }
            }
            return lista;
        }

        private static List<Acciones> LeerListaAcciones()
        {
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

        private static List<Monedas> LeerListaMonedas()
        {
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




        /********************* grabar ***************************/    

        /// <summary>
        /// grabar XML lista de usuarios en listaUsuarios.xml
        /// </summary>
        /// <param name="lista"></param>
        private static void GuardarListadoUsuarios(List<UsuarioSQL> lista)
        {
            string path = Path.Combine(Application.StartupPath, "listaUsuarios.xml");//guardar archivos en la ubicación relativa al directorio del proyecto
            using (StreamWriter streamWriter = new StreamWriter(path))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<UsuarioSQL>));
                serializer.Serialize(streamWriter, lista);
            }
        }

        /// <summary>
        /// guarda una lista de acciones en xml
        /// </summary>
        /// <param name="lista"></param>
        private static void GuardarGralAcciones(List<Acciones> lista)
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
        /// guarda una lista de monedas en archivo xml  
        /// </summary>
        /// <param name="lista"></param>
        private static void GuardarGralMonedas(List<Monedas> lista)
        {
            string path = Path.Combine(Application.StartupPath, "listaMonedas.xml");//guardar archivos en la ubicación relativa al directorio del proyecto

            using (StreamWriter streamWriter = new StreamWriter(path))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Monedas>));
                serializer.Serialize(streamWriter, lista);
            }
        }



        /***************** generar backup*****************************/
        /// <summary>
        /// genera una copia de la base de datos
        /// </summary>
        public static async void GenerarBackupXML()
        {
            try
            {
                List<Monedas> monedas = await Monedas.CrearListaMonedas();
                GuardarGralMonedas(monedas);

                List<Acciones> acciones = await Acciones.CrearListaAcciones();
                GuardarGralAcciones(acciones);

                List<UsuarioSQL> usuarios = await UsuarioSQL.CrearListaDeUsuarios();
                GuardarListadoUsuarios(usuarios);

                Vm.VentanaMensaje("Exito", "backup ok!");
            }
            catch (Exception)
            {

                throw;
            }

        }

        public static void GuardarReciboDeCompra(string recibo)
        {
            string path = Path.Combine(Application.StartupPath, "ReciboCompra.xml");//guardar archivos en la ubicación relativa al directorio del proyecto

            using (StreamWriter streamWriter = new StreamWriter(path))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(string));
                serializer.Serialize(streamWriter, recibo);
            }
        }


        /******************* recuperar DB ******************************/
        public static async void DeXMLaMySql()
        {
            List<UsuarioSQL> listaUsuarios = LeerListadoUsuarios();
            foreach (UsuarioSQL usuario in listaUsuarios)
            {
                await usuario.AgregarUsuario();

            }
            
            
            List<Monedas> listaMonedas = LeerListaMonedas();

            List<Acciones> listaAcciones = LeerListaAcciones(); 
        }


    }
}
