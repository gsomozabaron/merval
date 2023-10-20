using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace merval
{
    public partial class FormAltaAcciones : Form
    {
        private List<Acciones> listaAccionesGral = Serializadora.LeerListaAcciones();

        public FormAltaAcciones()
        {
            InitializeComponent();
        }
        private void btn_aceptar_Click(object sender, EventArgs e)
        {
            string titulo = txt_Titulo.Text;
            string valor = Txt_precio.Text;

            if (titulo == "" || valor.ToString() == "")
            {
                FormMetodos.VentanaMensajeError("Tanto el título como el precio \nson obligatorios.");
                return;
            }


            if (!decimal.TryParse(valor, out decimal valorDec))
            {
                FormMetodos.VentanaMensajeError("El precio ingresado no es un valor numérico válido.");
                return;
            }

            if (listaAccionesGral.Any(a => a.Nombre == titulo))
            {
                FormMetodos.VentanaMensajeError("El título ya se encuentra dado de alta");
            }
            else
            {
            Acciones nuevaAccion = new Acciones(titulo, valor);
            listaAccionesGral.Add(nuevaAccion);
            Serializadora.GuardarGralAcciones(listaAccionesGral);
            FormMetodos.VentanaMensaje("Éxito", "Título ingresado correctamente.");
            txt_Titulo.Clear(); // Limpiar los campos después de agregar
            Txt_precio.Clear();
                ///Guardar(titulo, valor);
            }
        }


        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// ////////////////////////////////////////////////////////////////////////////
        /// </summary>
        private void Guardar()///sacar a otra clase!!
        {

        }
        //////////////////////////////////////////////////////////////////////////////////////
    }
}

