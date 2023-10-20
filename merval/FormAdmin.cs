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

        /// <summary>
        /// muestra un listado con todos los usuarios y sus datos, oculta el password y el saldo
        /// </summary>
        private void VerUsuarios_Click(object sender, EventArgs e)
        {
            listUsuarios = Serializadora.LeerListadoUsuarios();
            this.dataGridView1.DataSource = this.listUsuarios;
            this.dataGridView1.Visible = true;
            this.dataGridView1.Columns["Pass"].Visible = false;
            this.dataGridView1.Columns["saldo"].Visible = false;
        }

        private void AltasAcciones_Click(object sender, EventArgs e)
        {
            this.dataGridView1.Visible = false;
            FormAltaAcciones faa = new FormAltaAcciones();
            faa.Show();
        }

        /// <summary>
        /// muestra el listado de acciones general
        /// </summary>
        private void VerTitulos_Click(object sender, EventArgs e)
        {
            listadeAccionesGral = Serializadora.LeerListaAcciones();
            this.dataGridView1.DataSource = listadeAccionesGral;
            this.dataGridView1.Visible = true;
            this.dataGridView1.Columns["cantidad"].Visible = false;
            this.dataGridView1.Columns["fecha"].Visible = false;
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_ocultarDataGrid_Click(object sender, EventArgs e)
        {
            this.dataGridView1.Visible = false;
        }

        private void altasUsuarios_Click(object sender, EventArgs e)
        {
            this.dataGridView1.Visible = false;
            string alta = "admin";
            FormRegistroUsuarios fr = new FormRegistroUsuarios(alta);
            fr.ShowDialog();
        }

        private void Mts_ModificarDatos_Click(object sender, EventArgs e)
        {
            this.dataGridView1.Visible = false;
            FormModificarUsuario fm = new FormModificarUsuario();
            fm.ShowDialog();
        }

        private void BajasAcciones_Click(object sender, EventArgs e)
        {
            this.dataGridView1.Visible = false;
            FormBajaDeAcciones fb = new FormBajaDeAcciones();
            fb.ShowDialog();
        }
    }
}
