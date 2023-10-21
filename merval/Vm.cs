using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace merval
{
    public class Vm
    {
        public static DialogResult VentanaMensaje(string titulo,string mensaje)
        {
            VentanaEmergente ve = new VentanaEmergente(titulo,mensaje);
            
            return ve.ShowDialog();
        }

        public static DialogResult VentanaMensajeError(string mensaje)
        {
            VentanaError ve = new VentanaError(mensaje);
            return ve.ShowDialog();
        }

        public static DialogResult VentanaMensajeConfirmar(string titulo, string mensaje)
        {
            VentanaConfirmar ve = new VentanaConfirmar(titulo, mensaje);
            return ve.ShowDialog();
        }

    }
}
