using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace merval
{
    public partial class FormAcciones : Form
    {
        //private List<Usuario> listaDeUsuarios = formLogin.listadoDeUsuarios;
        //private Usuario usuario = formLogin.usuarioActual; 

        //List<Usuario> listaDeUsuarios = formLogin.ListadoDeUsuarios;
        //Usuario usuario = formLogin.UsuarioActual;

        public FormAcciones()
        {
            InitializeComponent();
        }

        private void acciones_Load(object sender, EventArgs e)
        {
            //List<Usuario> listaUsuario = new List<Usuario> { usuario };///lista de un solo usuario para poder mostrarlo
            //this.dtg_Acciones.DataSource = listaUsuario;

            //this.dtg_Acciones.Columns["nombre"].Visible = true;
            //this.dtg_Acciones.Columns["dni"].Visible = true;
            //this.dtg_Acciones.Columns["NombreUsuario"].Visible = true;
            //this.dtg_Acciones.Columns["pass"].Visible = true;


            //BindingSource sb = new BindingSource(); //para poder bindear el diccionario al datasource 
            //sb.DataSource = stock;
            //this.dataGridView1.DataSource = sb;

        }

        private void dtg_Acciones_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
