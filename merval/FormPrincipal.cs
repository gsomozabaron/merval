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
        List<Acciones> listaAccionesGral = formLogin.ListadeAccionesGral;///new List<Acciones>();
        Usuario usuario = formLogin.UsuarioActual;

        ///Form Formulario; //formulario es una instancia del formulario acciones hay que agregar el "Form formulario justo abajo del contructor"


        public FormPrincipal()
        {
            InitializeComponent();
            this.IsMdiContainer = true;
        }


        private void mostrarUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.dataGridView1.DataSource = usuario.ListadoDeAccionesPropias;

            //this.dataGridView1.Columns["nombre"].Visible = true;
            //this.dataGridView1.Columns["dni"].Visible = true;
            //this.dataGridView1.Columns["NombreUsuario"].Visible = true;
            //this.dataGridView1.Columns["pass"].Visible = true;

            //BindingSource sb = new BindingSource(); //para poder bindear el diccionario al datasource 
            //sb.DataSource = stock;
            //this.dataGridView1.DataSource = sb;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void verMercadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.dataGridView1.DataSource = listaAccionesGral;
        }

        private void adquirirAccioneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.dataGridView1.DataSource = listaAccionesGral;
            
        }

        private void venderTitulosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.dataGridView1.DataSource = usuario.ListadoDeAccionesPropias;
        }
    }
}
