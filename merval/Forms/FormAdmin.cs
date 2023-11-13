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
using merval.entidades;
using merval.Serializadores;
using merval.DB;
using merval.DAO;

namespace merval
{
    public partial class FormAdmin : Form
    {
        private List<Usuario> lista; /// para usar la interface

        public FormAdmin()
        {
            InitializeComponent();
            this.dataGridView1.Visible = false;
        }
        private void btn_ocultarDataGrid_Click(object sender, EventArgs e)
        {
            this.dataGridView1.Visible = false;
        }


        //////////////////////ver y modificar usuarios//////////////////////////////

        /// <summary>
        /// muestra un listado con todos los usuarios y sus datos, oculta el password y el saldo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VerUsuarios_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario();
            lista = usuario.MostrarUsuarios();
            dataGridView1.DataSource = lista;
            //this.dataGridView1.Columns["Pass"].Visible = false;     //[5]
            //this.dataGridView1.Columns["Saldo"].Visible = false;    //[7]
            this.dataGridView1.Columns[5].Visible = false;     //[5]
            this.dataGridView1.Columns[7].Visible = false;    //[7]
            this.dataGridView1.Visible = true;

        }


        /// altas de usuarios
        private void altasUsuarios_Click(object sender, EventArgs e)
        {
            this.dataGridView1.Visible = false;
            string alta = "admin";
            FormRegistroUsuarios fr = new FormRegistroUsuarios(alta);
            fr.ShowDialog();
        }

        /// bajar o modificar datos de usuarios                 
        private void Mts_ModificarDatos_Click(object sender, EventArgs e)
        {
            this.dataGridView1.Visible = false;
            FormModificarUsuario fm = new FormModificarUsuario();
            fm.ShowDialog();
        }


        ///////////// alta,baja,modificacion y vista de titulos////////////////
        /////////////////////    acciones    //////////////////////

        /// <summary>
        /// muestra el listado de acciones
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TSP_AccionesVerTitulos_Click(object sender, EventArgs e)
        {
            this.dataGridView1.DataSource = DatabaseSQL.MostrarActivos("Acciones");
            this.dataGridView1.Visible = true;
            this.dataGridView1.Columns["cantidad"].Visible = false;
        }
        private void TSP_AccionesAltas_Click(object sender, EventArgs e)
        {
            this.dataGridView1.Visible = false;
            string tipo = "Acciones";
            FormAltaAcciones faa = new FormAltaAcciones(tipo);
            faa.Show();
        }
        private void TSP_AccionesBajas_Click(object sender, EventArgs e)
        {
            this.dataGridView1.Visible = false;
            string tipo = "Acciones";
            FormBajaDeAcciones fb = new FormBajaDeAcciones(tipo);
            fb.ShowDialog();

        }
        private void TSP_AccionesModificar_Click(object sender, EventArgs e)
        {
            this.dataGridView1.Visible = false;
            string tipo = "Acciones";
            FormModificarAcciones fm = new FormModificarAcciones(tipo);
            fm.ShowDialog();
        }


        /////////////////////////  monedas ///////////////////////////////
        private void TSM_altasMoneda_Click(object sender, EventArgs e)
        {
            this.dataGridView1.Visible = false;
            FormAltaAcciones fa = new FormAltaAcciones("Monedas");
            fa.ShowDialog();
        }
        private void TSM_bajasMoneda_Click(object sender, EventArgs e)
        {
            this.dataGridView1.Visible = false;
            string tipo = "Monedas";
            FormBajaDeAcciones fb = new FormBajaDeAcciones(tipo);
            fb.ShowDialog();

        }
        private void TSM_modificarMoneda_Click(object sender, EventArgs e)
        {
            this.dataGridView1.Visible = false;
            string tipo = "Monedas";
            FormModificarAcciones fm = new FormModificarAcciones(tipo);
            fm.ShowDialog();

        }
        private void TSM_VerMonedas_Click(object sender, EventArgs e)
        {

            this.dataGridView1.DataSource = DatabaseSQL.MostrarActivos("Monedas");
            this.dataGridView1.Visible = true;
            this.dataGridView1.Columns["cantidad"].Visible = false;

        }


        //////////////////////////salir de la aplicacion/////////////////////////////// 
        private void btn_salir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
