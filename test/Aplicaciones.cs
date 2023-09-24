using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace celular_clases
{
    internal class Aplicaciones
    {
        private string nombre;
        private float peso;

        public Aplicaciones(string nombre, float peso)
        {
            this.nombre = nombre;
            this.peso = peso;
        }

        public string Nombre { get => nombre; set => nombre = value; }
        public float Peso { get => peso; set => peso = value; }
    }
}
