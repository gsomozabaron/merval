using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace merval.Serializadores
{
    internal interface Iserializable<T>
    {
        bool Serializar(T datos);

        T Deserializar();



    }
}
