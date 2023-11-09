using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace merval.Serializadores
{
    public abstract class Serializador
    {
        public string Path {  get; set; }

        public Serializador(string path)
        {
            Path = path;
        }

    }

}
