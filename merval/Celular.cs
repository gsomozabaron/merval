using merval;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace merval
{
    internal class celular
    {
        EMarca marca;
        string pantalla;
        int memoria;
        int capacidad;

        public celular(EMarca marca, string pantalla, int memoria, int capacidad)
        {
            this.marca = marca;
            this.pantalla = pantalla;
            this.memoria = memoria;
            this.capacidad = capacidad;
        }

        public EMarca Marca { get => marca; set => marca = value; }
        public string Pantalla { get => pantalla; set => pantalla = value; }
        public int Memoria { get => memoria; set => memoria = value; }
        public int Capacidad { get => capacidad; set => capacidad = value; }

        public static int ContarEnLista(List<celular> lc, EMarca m)
        {
            int count = 0;
            if (lc == null)
            {
                return -1;
            }

            foreach (var item in lc)
            {
                if (item.marca == m)
                {
                    count++;
                }
            }
            return count;
        }




    }
}

