using merval.Serializadores;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace merval.Ventanas_Emergentes
{
    public partial class VentanaRecibo : Form
    {
        private string recibo;

        public VentanaRecibo(string recibo)
        {
            InitializeComponent();
            this.label1.Text = recibo;
            this.recibo = recibo;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_guardarXml_Click(object sender, EventArgs e)
        {
            try
            {
                Serializadora.GuardarReciboDeCompra(recibo);
                Vm.VentanaMensaje("Exito", "Recibo guardado");
            }
            catch (Exception)
            {
                Vm.VentanaMensajeError("No se pudo\nguardar el recibo");
            }
            this.Close();
        }
    }
}
