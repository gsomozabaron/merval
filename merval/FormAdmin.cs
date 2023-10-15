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
        List<Usuario> listUsuarios = Serializadora.LeerListadoUsuarios();
        List<Acciones> listadeAccionesGral = Serializadora.LeerListaAcciones();

        public FormAdmin()
        {
            InitializeComponent();
            this.dataGridView1.Visible = false;
        }

        private void FormAdmin_Load(object sender, EventArgs e)
        {

        }

        private void VerUsuarios_Click(object sender, EventArgs e)
        {
            listUsuarios = Serializadora.LeerListadoUsuarios();
            this.dataGridView1.DataSource = this.listUsuarios;
            this.dataGridView1.Visible = true;
            this.dataGridView1.Columns["Pass"].Visible = false;
        }

        private void AltasAcciones_Click(object sender, EventArgs e)
        {
            FormAltaAcciones faa = new FormAltaAcciones();
            faa.Show();
        }

        private void VerTitulos_Click(object sender, EventArgs e)
        {
            listadeAccionesGral = Serializadora.LeerListaAcciones();
            this.dataGridView1.DataSource = listadeAccionesGral;
            this.dataGridView1.Visible = true;
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void btn_ocultarDataGrid_Click(object sender, EventArgs e)
        {
            this.dataGridView1.Visible = false;
        }

        private void altasUsuarios_Click(object sender, EventArgs e)
        {
            FormRegistroUsuarios fr = new FormRegistroUsuarios();
            fr.ShowDialog();
        }

        private void Mts_ModificarDatos_Click(object sender, EventArgs e)
        {
            FormModificarUsuario fm = new FormModificarUsuario();
            fm.Show();
        }

        private void BajasAcciones_Click(object sender, EventArgs e)
        {
            FormBajaDeAcciones fb = new FormBajaDeAcciones();
            fb.ShowDialog();
        }

        private void ModificarUsuarios_Click(object sender, EventArgs e)
        {

        }
    }
}
