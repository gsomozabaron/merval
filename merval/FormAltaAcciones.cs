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
            try
            {
                decimal valorCompra = decimal.Parse(Txt_ValorCompra.Text);
                decimal valorVenta = decimal.Parse(txt_ValorVenta.Text);
                if (titulo == "" || valorCompra.ToString() == "" || valorVenta.ToString() == "")
                {
                    Vm.VentanaMensajeError("Tanto el título como los precios \nson obligatorios.");
                    return;
                }

                if (listaAccionesGral.Any(a => a.Nombre == titulo))
                {
                    Vm.VentanaMensajeError("El título ya se encuentra dado de alta");
                }
                else
                {
                    Acciones.CrearAccion(titulo, valorCompra, valorVenta, listaAccionesGral);

                    Vm.VentanaMensaje("Éxito", "Título ingresado correctamente.");

                    txt_Titulo.Clear(); // Limpiar los campos después de agregar
                    Txt_ValorCompra.Clear();
                }
            }
            catch (Exception)
            {
                Vm.VentanaMensajeError("los precios ingresados no son un valor numérico válido.");
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

