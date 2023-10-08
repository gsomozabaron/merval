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
    public partial class FormAdmin : Form
    {
        Usuario usuario = formLogin.UsuarioActual;
        List<Usuario> listUsuarios = formLogin.ListadoDeUsuarios;
        public FormAdmin()
        {
            InitializeComponent();
        }

        private void FormAdmin_Load(object sender, EventArgs e)
        {
        }

        private void verUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;//para que se actualice si hay algun cambio
            dataGridView1.DataSource = listUsuarios;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void altasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormRegistroUsuarios fr = new FormRegistroUsuarios();
            fr.Show();
            this.Hide();
        }

        private void altasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormAltaAcciones faa = new FormAltaAcciones();
            faa.Show();
        }

        private void verTitulosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;//para que se actualice si hay algun cambio
            dataGridView1.DataSource = formLogin.ListadeAccionesGral;
        }

        private void guardarDatosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                VentanaEmergente ve = new VentanaEmergente("grabar datos", "error");
                ve.ShowDialog();

            }
            catch (Exception)
            {
                VentanaEmergente ve = new VentanaEmergente("grabar datos", "error");
                ve.ShowDialog();
            }
        }

        private void cargarDatosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                VentanaEmergente ve = new VentanaEmergente("cargar datos", "exito");
                ve.ShowDialog();
            }
            catch (Exception)
            {
                VentanaEmergente ve = new VentanaEmergente("cargar datos", "error");
                ve.ShowDialog();
            }
        }

        private void modificarUsuarios_Click(object sender, EventArgs e)
        {
        }
    }
}
