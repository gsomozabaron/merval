using merval.DB;
using merval.entidades;
using merval.Serializadores;
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

        /// dispara el form de compra de acciones
        private void ComprarAcciones_Click(object sender, EventArgs e)
        {
            FormOperar Fo = new FormOperar(usuario, "Acciones");
            this.dataGridView1.Visible = false;
            Fo.ShowDialog();
        }
        private void ComprarMonedas_Click(object sender, EventArgs e)
        {
            FormOperar Fo = new FormOperar(usuario, "Monedas");
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
        private void venderAcciones_Click(object sender, EventArgs e)
        {
            this.dataGridView1.Visible = false;
            FormVender Fv = new FormVender(usuario, "Acciones");
            Fv.ShowDialog();
        }
        private void VenderMonedas_Click(object sender, EventArgs e)
        {
            this.dataGridView1.Visible = false;
            FormVender Fv = new FormVender(usuario, "Monedas");
            Fv.ShowDialog();
        }

        private void TSM_carteraAcciones_Click(object sender, EventArgs e)
        {
            //List<Acciones> listaAccionesGral = Serializadora.LeerListaAcciones();
            List<Acciones> listaAccionesGral = DatabaseSQL.CrearListaAcciones();

            List<Acciones> listDTG = new List<Acciones>();

            foreach (Activos acc in usuario.ListadoDeActivosPropios)
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

        private void TSM_CarteraMonedas_Click(object sender, EventArgs e)
        {
            List<Monedas> lista = Serializadora.LeerListaMonedas();

            List<Activos> monedasDTG = new List<Activos>();

            foreach (Activos m in usuario.ListadoDeActivosPropios)
            {
                foreach (Monedas a in lista)
                {
                    if (m.Nombre == a.Nombre)
                    {
                        string nombre = m.Nombre;
                        decimal compra = a.ValorCompra;
                        decimal venta = a.ValorVenta;
                        int cantidad = m.Cantidad;

                        Monedas dtg = new Monedas(nombre, compra, venta, cantidad);
                        monedasDTG.Add(dtg);
                    }
                }
            }
            this.dataGridView1.DataSource = null;///para hacer un refresh
            this.dataGridView1.Visible = true;
            this.dataGridView1.DataSource = monedasDTG;
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

        private void VerMercadoMonedas_Click(object sender, EventArgs e)
        {
            List<Monedas> lista = Serializadora.LeerListaMonedas();
            this.dataGridView1.DataSource = null;
            this.dataGridView1.Visible = true;
            this.dataGridView1.DataSource = lista;

            this.dataGridView1.Columns["Cantidad"].Visible = false;

        }

        private void VerMercadoAcciones_Click(object sender, EventArgs e)
        {
            //List<Acciones> listaAccionesGral = Serializadora.LeerListaAcciones();
            List<Acciones> listaAccionesGral = DatabaseSQL.CrearListaAcciones();
            this.dataGridView1.DataSource = null;
            this.dataGridView1.Visible = true;
            this.dataGridView1.DataSource = listaAccionesGral;

            this.dataGridView1.Columns["Cantidad"].Visible = false;
        }

    }
}
