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
    public partial class FormPrincipal : Form
    {
        List<Acciones> listaAccionesGral = formLogin.ListadeAccionesGral;
        Usuario usuario = formLogin.UsuarioActual;


        public FormPrincipal()
        {
            InitializeComponent();
            this.IsMdiContainer = true;
        }

        private void verMercado_Click(object sender, EventArgs e)
        {
            this.dataGridView1.Visible = true;
            this.dataGridView1.DataSource = listaAccionesGral;
            this.dataGridView1.Columns[2].Visible = false;
            this.dataGridView1.Columns[3].Visible = false;

        }

        private void Ver_AccionesPropias_Click(object sender, EventArgs e)
        {
            this.dataGridView1.Visible = true;
            this.dataGridView1.DataSource = usuario.ListadoDeAccionesPropias;
            this.dataGridView1.Columns[2].Visible = true;
            this.dataGridView1.Columns[3].Visible = true;


        }

        private void ComprarTitulos_Click(object sender, EventArgs e)
        {
            FormOperar Fo = new FormOperar(usuario);
            Fo.ShowDialog();
        }

        private void consultarSaldo_TSM_Click(object sender, EventArgs e)
        {
            FormSaldo Fs = new FormSaldo(usuario);
            Fs.ShowDialog();
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            this.dataGridView1.Visible = false;
        }

        private void venderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormVender Fv = new FormVender(usuario);
            Fv.ShowDialog();
        }
    }
}
