using System.Xml.Serialization;

namespace merval.Serializadores
{
    public class SerializadorXML<T> : Serializador, Iserializable<List<T>> where T : new()
    {
        public SerializadorXML(string path) : base(path)
        {
        }
        public bool Serializar(List<T> datos)
        {
            using (var stream = new StreamWriter(Path))
            {
                if (stream != null)
                {
                    var xml = new XmlSerializer(typeof(T));

                    xml.Serialize(stream, datos);
                }
            }
            return true;
        }


        public List<T> Deserializar()
        {
            var lista = new List<T>();
            using (var stream = new StreamReader(Path))
            {
                if (stream != null)
                {
                    var xml = new XmlSerializer(typeof(T));

                    var listaDeserializada = xml.Deserialize(stream);

                    if (listaDeserializada != null)
                    {
                        lista = (List<T>)listaDeserializada;
                    }
                }
            }
            return lista;
        }

    }

}
