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
using System.IO;
using System.Xml.Serialization;

namespace merval
{
    public partial class FormAdmin : Form
    {

        public FormAdmin()
        {
            InitializeComponent();
            dataGridView1.Visible = false;
        }

        private void FormAdmin_Load(object sender, EventArgs e)
        {
        
        }

        private void VerUsuarios_Click(object sender, EventArgs e)
        {
            List<Usuario> listUsuarios = Serializadora.LeerListadoUsuarios();
            dataGridView1.DataSource = listUsuarios;
            dataGridView1.Visible = true;
            dataGridView1.Columns["Pass"].Visible = false;
            ///dataGridView1.Visible = !(dataGridView1.Visible);
        }

        private void AltasAcciones_Click(object sender, EventArgs e)
        {
            FormAltaAcciones faa = new FormAltaAcciones();
            faa.Show();
        }

        private void VerTitulos_Click(object sender, EventArgs e)
        {
            List<Acciones> listadeAccionesGral = Serializadora.LeerListaAcciones();
            dataGridView1.DataSource = listadeAccionesGral;
            dataGridView1.Visible = true;
            ///dataGridView1.Visible = !(dataGridView1.Visible);
        }

        private void modificarUsuarios_Click(object sender, EventArgs e)
        {

        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void btn_ocultarDataGrid_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
        }


        private void BajaUsuariosMenu_Click(object sender, EventArgs e)
        {
            FormBajaUsuarios menu = new FormBajaUsuarios();
            menu.ShowDialog();
        }

        private void altasUsuarios_Click(object sender, EventArgs e)
        {
            FormRegistroUsuarios fr = new FormRegistroUsuarios();
            fr.ShowDialog();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
