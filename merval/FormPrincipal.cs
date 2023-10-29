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
        private Usuario usuario;

        public FormPrincipal(Usuario usuarioActual)
        {
            InitializeComponent();
            this.IsMdiContainer = true;
            this.usuario = usuarioActual;
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            this.dataGridView1.Visible = false;
        }

        /// <summary>
        /// muestra los titulos disponibles
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void verMercado_Click(object sender, EventArgs e)
        {
            List<Acciones> listaAccionesGral = Serializadora.LeerListaAcciones();
            this.dataGridView1.DataSource = null;
            this.dataGridView1.Visible = true;
            this.dataGridView1.DataSource = listaAccionesGral;

            this.dataGridView1.Columns["Cantidad"].Visible = false;
        }

        /// <summary>
        /// muestra en un datagrid las acciones del usuario con sus valores
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Ver_AccionesPropias_Click(object sender, EventArgs e)
        {
            VerAccionesDatagrid();
        }

        /// <summary>
        /// dispara el form de compra
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComprarTitulos_Click(object sender, EventArgs e)
        {
            FormOperar Fo = new FormOperar(usuario);
            this.dataGridView1.Visible = false;
            Fo.ShowDialog();
        }

        /// <summary>
        /// dispara el form de saldos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void consultarSaldo_TSM_Click(object sender, EventArgs e)
        {
            FormSaldo Fs = new FormSaldo(usuario);
            this.dataGridView1.Visible = false;
            Fs.ShowDialog();
        }

        /// <summary>
        /// dispara el form de venta
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void venderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.dataGridView1.Visible = false;
            FormVender Fv = new FormVender(usuario);
            Fv.ShowDialog();
        }

        /// <summary>
        /// genera un listado de titulos con sus valores para mostrar en el datagrid
        /// toma las acciones del usuario y le agrega los precios de compra y venta del listado de acciones general
        /// </summary>
        private void VerAccionesDatagrid()
        {
            List<Acciones> listaAccionesGral = Serializadora.LeerListaAcciones();
            
            List<Acciones> listDTG = new List<Acciones>();
            
            foreach (Acciones acc in usuario.ListadoDeAccionesPropias)
            {
                foreach (Acciones a in listaAccionesGral)
                {
                    if (acc.Nombre == a.Nombre)
                    {
                        string nombre = acc.Nombre;
                        decimal compra = a.ValorCompra;
                        decimal venta = a.ValorVenta;
                        int cantidad = acc.Cantidad;

                        Acciones dtg = new Acciones(nombre, compra, venta, cantidad);
                        listDTG.Add(dtg);
                    }
                }
            }
            this.dataGridView1.DataSource = null;///para hacer un refresh
            this.dataGridView1.Visible = true;
            this.dataGridView1.DataSource = listDTG;
            // Cambiar el orden de las columnas
            this.dataGridView1.Columns["Nombre"].DisplayIndex = 0;
            this.dataGridView1.Columns["Cantidad"].DisplayIndex = 1;
            this.dataGridView1.Columns["ValorCompra"].DisplayIndex = 2;
            this.dataGridView1.Columns["ValorVenta"].DisplayIndex = 3;
            this.dataGridView1.Columns["ValorCompra"].HeaderText = "Valor\nCompra";
            this.dataGridView1.Columns["ValorVenta"].HeaderText = "Valor\nVenta";
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }
    }
}
