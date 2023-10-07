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
        public FormAdmin(Usuario usuario)
        {
            InitializeComponent();
        }

        private void FormAdmin_Load(object sender, EventArgs e)
        {


        }

        private void verUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = listUsuarios;
            dataGridView1.Columns["Pass"].Visible = false;
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
    }
}
