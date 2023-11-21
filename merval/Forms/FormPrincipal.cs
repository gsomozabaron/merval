using merval.DB;


namespace merval
{
    public partial class FormPrincipal : Form
    {
        private UsuarioSQL usuario;

        public FormPrincipal(UsuarioSQL usuarioActual)
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
        /// dispara el form de compra de acciones
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComprarAcciones_Click(object sender, EventArgs e)
        {
            FormOperar Fo = new FormOperar(usuario, "Acciones");
            this.dataGridView1.Visible = false;
            Fo.ShowDialog();
        }


        /// <summary>
        /// dispara el form de compra de Monedas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// dispara el form de venta
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VenderMonedas_Click(object sender, EventArgs e)
        {
            this.dataGridView1.Visible = false;
            FormVender Fv = new FormVender(usuario, "Monedas");
            Fv.ShowDialog();
        }


        private async void TSM_carteraAcciones_Click(object sender, EventArgs e)
        {
            string tipo = "Acciones";

            List<Activos> listDTG = UsuarioSQL.CarteraUsuario(usuario, tipo);
            DatagridCarteraUsuario(listDTG);
        }

        private void TSM_CarteraMonedas_Click(object sender, EventArgs e)
        {
            string tipo = "Monedas";

            List<Activos> listDTG = UsuarioSQL.CarteraUsuario(usuario, tipo);
            DatagridCarteraUsuario(listDTG);
        }

        private void DatagridCarteraUsuario(List<Activos> listDTG)
        {
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

        private async void VerMercadoMonedas_Click(object sender, EventArgs e)
        {
            Activos activos = new Activos();
            string tipo = "monedas";
            //List<Activos> lista = DatabaseSQL.CrearListaDeActivos(tipo);
            List<Activos> lista = await activos.CrearListaDeActivos(tipo);

            this.dataGridView1.DataSource = null;
            this.dataGridView1.Visible = true;
            this.dataGridView1.DataSource = lista;

            this.dataGridView1.Columns["Cantidad"].Visible = false;

        }

        private async void VerMercadoAcciones_Click(object sender, EventArgs e)
        {
            Activos activos = new Activos();
            string tipo = "Acciones";
            List<Activos> lista = await activos.CrearListaDeActivos(tipo);


            this.dataGridView1.DataSource = null;
            this.dataGridView1.Visible = true;
            this.dataGridView1.DataSource = lista;

            this.dataGridView1.Columns["Cantidad"].Visible = false;
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }
    }
}
