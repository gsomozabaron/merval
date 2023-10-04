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
        private List<Usuario> listaDeUsuarios = formLogin.listadoDeUsuarios;
        
        public FormAcciones()
        {
            InitializeComponent();
        }

        private void acciones_Load(object sender, EventArgs e)
        {
            this.dtg_Acciones.DataSource = listaDeUsuarios;
            this.dtg_Acciones.Columns["nombre"].Visible = true;
            this.dtg_Acciones.Columns["dni"].Visible = true;
            this.dtg_Acciones.Columns["NombreUsuario"].Visible = true;
            this.dtg_Acciones.Columns["pass"].Visible = true;
            




        }

        private void dtg_Acciones_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
