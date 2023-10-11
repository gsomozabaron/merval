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
    public partial class Ventana_error : Form
    {
        private string mensaje;

        public Ventana_error(string mensaje)
        {
            InitializeComponent();
            this.lbl_MensajeError.Text = mensaje;
        }



        private void Btn_Aceptar_Click_1(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
