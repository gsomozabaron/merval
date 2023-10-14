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
    public partial class VentanaConfirmar : Form
    {
        string titulo;
        string mensaje;
        public VentanaConfirmar(string titulo, string mensaje)
        {
            InitializeComponent();
            this.lbl_Titulo.Text = titulo;
            this.lbl_Mensaje.Text = mensaje;
        }

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void VentanaConfirmar_Load(object sender, EventArgs e)
        {
        }

        private void btn_Aceptar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }


    }
}
