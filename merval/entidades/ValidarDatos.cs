using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace merval.entidades
{
    internal class ValidarDatos
    {
        public static bool ValidarDniValido(string numero)
        {
            bool validar = true;
            
            return validar;
        }

        public static bool CadenaVacia(string datoString) 
        {
            Vm.VentanaMensajeError("campos vacios");
            return string.IsNullOrEmpty(datoString);
        }
        


    }
}
