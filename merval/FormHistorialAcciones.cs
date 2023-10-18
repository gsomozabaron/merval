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
using merval;
using System.Xml;
using FastReport.DataVisualization.Charting;

namespace merval
{
    public partial class FormHistorialAcciones : Form
    {
        public FormHistorialAcciones()
        {
            InitializeComponent();
        }

        private void FormHistorialAcciones_Load(object sender, EventArgs e)
        {

        }

        private void btn_Salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
}
