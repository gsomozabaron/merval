using Entidades;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace merval
{
    [Serializable]
    public class GuardarDatos
    {
        public List<Usuario> ListadoDeUsuarios { get; set; }
        public List<KeyValuePair<string, string>> ListaUsuarioPassword { get; set; }
        public List<Acciones> ListadeAccionesGral { get; set; }

        public void GuardarListas(string rutaArchivo)
        {
            GuardarDatos datosGuardar = new GuardarDatos();
            datosGuardar.CargarArchivo("listas.xml");
            //Convierte la lista de pares clave-valor en un diccionario
            Dictionary<string, string> dictUsuarioPassword = datosGuardar.ListaUsuarioPassword.ToDictionary(pair => pair.Key, pair => pair.Value);

        }

        public void CargarArchivo(string rutaArchivo)
        {
            if (File.Exists(rutaArchivo))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(GuardarDatos));
                using (FileStream fs = new FileStream(rutaArchivo, FileMode.Open))
                {
                    GuardarDatos datosGuardar = new GuardarDatos();
                    datosGuardar.CargarArchivo("listas.xml");
                    // Convierte la lista de pares clave-valor en un diccionario
                    Dictionary<string, string> dictUsuarioPassword = datosGuardar.ListaUsuarioPassword.ToDictionary(pair => pair.Key, pair => pair.Value);

                }
            }
        }
    }
}

///GuardarDatosEnArchivo("datos.xml");
