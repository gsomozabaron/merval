using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace celular_clases
{
    internal class llamada
    {
        private DateTime fechaLlamada;
        private string numeroDestino;
        private double duracionLlamada;

        public llamada(DateTime fechaLlamada, string numeroDestino, double duracionLlamada)
        {
            this.fechaLlamada = fechaLlamada;
            this.numeroDestino = numeroDestino;
            this.duracionLlamada = duracionLlamada;
        }

        public DateTime FechaLlamada { get => fechaLlamada; set => fechaLlamada = value; }
        public string NumeroDestino { get => numeroDestino; set => numeroDestino = value; }
        public double DuracionLlamada { get => duracionLlamada; set => duracionLlamada = value; }


    }
}
