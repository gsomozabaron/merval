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
        string formName = "principal Admin";
        string mensaje = string.Empty;

        private List<UsuarioSQL> lista; /// para usar la interface

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
        private async void VerUsuarios_Click(object sender, EventArgs e)
        {
            lista = await UsuarioSQL.CrearListaDeUsuarios();
            dataGridView1.DataSource = lista;
            //this.dataGridView1.Columns["Pass"].Visible = false;     //[5]
            //this.dataGridView1.Columns["Saldo"].Visible = false;    //[7]
            this.dataGridView1.Columns[5].Visible = false;     //[5]
            this.dataGridView1.Columns[7].Visible = false;    //[7]
            this.dataGridView1.Visible = true;

        }

        /// <summary>
        /// altas de usuarios
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void altasUsuarios_Click(object sender, EventArgs e)
        {
            this.dataGridView1.Visible = false;
            string alta = "admin";
            FormRegistroUsuarios fr = new FormRegistroUsuarios(alta);
            fr.ShowDialog();
        }

        /// <summary>
        /// bajar o modificar datos de usuarios                 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Mts_ModificarDatos_Click(object sender, EventArgs e)
        {
            this.dataGridView1.Visible = false;
            FormModificarUsuario fm = new FormModificarUsuario();
            fm.ShowDialog();
        }


        ///////////// Menus alta,baja,modificacion y vista de titulos////////////////
        /////////////////////    acciones    //////////////////////
        private async void TSP_AccionesVerTitulos_Click(object sender, EventArgs e)
        {
            Activos activos = new Activos();
            this.dataGridView1.DataSource = await activos.MostrarActivos("Acciones");
            this.dataGridView1.Visible = true;
            this.dataGridView1.Columns["cantidad"].Visible = false;
        }
        private void TSP_AccionesAltas_Click(object sender, EventArgs e)
        {
            this.dataGridView1.Visible = false;
            string tipo = "Acciones";
            FormAltaActivos faa = new FormAltaActivos(tipo);
            faa.Show();
        }
        private void TSP_AccionesBajas_Click(object sender, EventArgs e)
        {
            this.dataGridView1.Visible = false;
            string tipo = "Acciones";
            FormBajaDeActivos fb = new FormBajaDeActivos(tipo);
            fb.ShowDialog();

        }
        private void TSP_AccionesModificar_Click(object sender, EventArgs e)
        {
            this.dataGridView1.Visible = false;
            string tipo = "Acciones";
            FormModificarActivos fm = new FormModificarActivos(tipo);
            fm.ShowDialog();
        }


        /////////////////////////  monedas ///////////////////////////////
        private void TSM_altasMoneda_Click(object sender, EventArgs e)
        {
            this.dataGridView1.Visible = false;
            FormAltaActivos fa = new FormAltaActivos("Monedas");
            fa.ShowDialog();
        }
        private void TSM_bajasMoneda_Click(object sender, EventArgs e)
        {
            this.dataGridView1.Visible = false;
            string tipo = "Monedas";
            FormBajaDeActivos fb = new FormBajaDeActivos(tipo);
            fb.ShowDialog();

        }
        private void TSM_modificarMoneda_Click(object sender, EventArgs e)
        {
            this.dataGridView1.Visible = false;
            string tipo = "Monedas";
            FormModificarActivos fm = new FormModificarActivos(tipo);
            fm.ShowDialog();

        }
        private async void TSM_VerMonedas_Click(object sender, EventArgs e)
        {
            Activos activos = new Activos();
            this.dataGridView1.DataSource = await activos.MostrarActivos("Monedas");
            this.dataGridView1.Visible = true;
            this.dataGridView1.Columns["cantidad"].Visible = false;

        }


        //////////////////////////salir de la aplicacion/////////////////////////////// 
        private void btn_salir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// hace un backup de los activos y los usuarios
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backupAXMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Serializadora.GenerarBackupXML();
        }
    }
}
