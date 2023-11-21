using merval.DB;
using merval.Excepciones;
using merval.Opercaciones;
using merval.Ventanas_Emergentes;
using System.Text;
using System.Windows.Forms;

namespace merval
{
    public partial class FormOperar : Form
    {
        private string mensaje;
        private string formName = "Form operar";
        private UsuarioSQL usuarioActual;
        private string tipoDeActivo;

        public FormOperar(UsuarioSQL usuario, string tipo)
        {
            InitializeComponent();
            tipoDeActivo = tipo;
            usuarioActual = usuario;
        }


        private void FormOperar_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        /// selecciona el titulo con doble click
        private void Dtg1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            btn_Comprar.Enabled = false;
            lbl_totalventa.Text = "$$$$$";
            txt_Cantidad.Clear();

            if (Dtg1.SelectedRows.Count > 0)
            {
                Activos Seleccionado = (Activos)Dtg1.SelectedRows[0].DataBoundItem;

                txt_titulo.Text = Seleccionado.Nombre;
                txt_cotizacion.Text = Seleccionado.ValorCompra.ToString();
            }
        }


        /// añade titulos a la lista de acciones del usuario
        private void btn_Comprar_Click(object sender, EventArgs e)
        {
            btn_Comprar.Enabled = false;
            if (txt_cotizacion.Text != "$$$$$")
            {
                btn_Comprar.Enabled = true;
                string titulo = txt_titulo.Text;

                (decimal cotizacion, int cantidad, decimal totalCompra) = calcularCompra();

                if (Operaciones.CompraDeActivos(usuarioActual, titulo, cantidad, totalCompra, tipoDeActivo))
                {
                    this.btn_Comprar.Click -= btn_Comprar_Click;
                    this.btn_Comprar.Click += BotonRecibo;
                    btn_Comprar.ForeColor = System.Drawing.Color.Aquamarine;
                    btn_Comprar.Text = "Obtener Recibo";

                    btn_Comprar.Enabled = true;

                    lbl_saldo.Text = null;  //borra saldo viejo para cargar el nuevo saldo
                    lbl_saldo.Text = usuarioActual.Saldo.ToString();    //refresh saldo

                    CargarDatos();  //refresh datagrid
                }
            }
        }

        private void BotonRecibo(object sender, EventArgs e)
        {
            string compraOventa = "compra";
            decimal cotizacion = decimal.Parse(txt_cotizacion.Text);
            int cantidad = int.Parse(txt_Cantidad.Text);
            decimal totalCompra = cotizacion * cantidad;
            lbl_totalventa.Text = totalCompra.ToString();
            string titulo = txt_titulo.Text;

            string recibo = CrearRecibo(compraOventa, usuarioActual, titulo, cantidad, totalCompra, tipoDeActivo);

            VentanaRecibo vr = new VentanaRecibo(recibo);
            btn_Comprar.ForeColor = System.Drawing.Color.Aquamarine;
            btn_Comprar.Text = "Comprar";
            btn_Comprar.Enabled = false;
            this.btn_Comprar.Click -= BotonRecibo;
            this.btn_Comprar.Click += btn_Comprar_Click;
            vr.ShowDialog();

        }

        /// <summary>
        /// confecciona el recibo de compra
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="titulo"></param>
        /// <param name="cantidad"></param>
        /// <param name="totalCompra"></param>
        /// <param name="tipoDeActivo"></param>
        public static string CrearRecibo(string compraOventa, UsuarioSQL usuario, string titulo, int cantidad, decimal total, string tipoDeActivo)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("** Merval appp **");
            sb.AppendLine($"*** fecha: {DateTime.Now.ToString("dd,MM,yyyy")}***");
            sb.AppendLine("*****************");
            sb.AppendLine($"* Recibo de {compraOventa} *");
            sb.AppendLine($"*** {usuario.Apellido} {usuario.Nombre} ***");
            sb.AppendLine("****");
            sb.AppendLine($"*** activo: {titulo} ***");
            sb.AppendLine("****");
            sb.AppendLine($"*** cantidad {cantidad} ***");
            sb.AppendLine($"***Total $ {total} ***");
            sb.AppendLine($"*****************");
            return sb.ToString();
        }


        /// <summary>
        /// llama a la funcion calcular compra
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_calcularCompra_Click(object sender, EventArgs e)
        {
            btn_Comprar.Enabled = true;
            calcularCompra();
        }

        /// <summary>
        /// clacula el total de la compra
        /// </summary>
        /// <returns></returns>
        private (decimal cotizacion, int cantidad, decimal totalcompra) calcularCompra()
        {
            try
            {
                decimal cotizacion = decimal.Parse(txt_cotizacion.Text);
                int cantidad = int.Parse(txt_Cantidad.Text);
                decimal totalCompra = cotizacion * cantidad;
                lbl_totalventa.Text = totalCompra.ToString();
                
                return (cotizacion, cantidad, totalCompra);
            }
            catch (FormatException ex)
            {
                mensaje = "Ingresa una cantidad valida.";
                Vm.VentanaMensajeError(mensaje);
                //ReporteExcepciones.CrearErrorLog(formName, ex, mensaje);
                return (0, 0, 0);
            }
            catch (OverflowException ex)
            {
                mensaje = "dato fuera de rango: ";
                Vm.VentanaMensajeError(mensaje);
                ///ReporteExcepciones.CrearErrorLog(formName, ex, mensaje);
                return (0, 0, 0);
            }
            catch (Exception ex)
            {
                mensaje = "inesperado";
                Vm.VentanaMensajeError(mensaje);
                ReporteExcepciones.CrearErrorLog(formName, ex, mensaje);
                return (0, 0, 0);
            }

        }

        /// <summary>
        /// genera una lista de acciones propias del usuario con sus precios y lo carga al datagrid
        /// </summary>
        private async void CargarDatos()
        {


            lbl_saldo.Text = usuarioActual.Saldo.ToString();

            string tipo = tipoDeActivo;
            Activos listaActivo = new Activos();
            List<Activos> todas = await listaActivo.CrearListaDeActivos(tipoDeActivo);

            List<Activos> propias = Operaciones.CarteraUsuario(usuarioActual, tipo);

            List<Activos> listaDTG = new List<Activos>();


            foreach (var a in todas)
            {
                Activos existente = listaDTG.Find(x => x.Nombre == a.Nombre);

                if (existente != null)
                {
                    // La acción ya está en la lista, actualiza la cantidad
                    existente.Cantidad += propias.Find(b => b.Nombre == a.Nombre)?.Cantidad ?? 0;
                }
                else
                {
                    // La acción no está en la lista, agrégala
                    Activos dtg = new Activos(a.Nombre, a.ValorCompra, a.ValorVenta,
                        propias.Find(b => b.Nombre == a.Nombre)?.Cantidad ?? 0);
                    listaDTG.Add(dtg);
                }
            }


            this.Dtg1.DataSource = null;
            this.Dtg1.DataSource = listaDTG;
            // Cambiar el orden de las columnas
            this.Dtg1.Columns["Nombre"].DisplayIndex = 0;
            this.Dtg1.Columns["ValorCompra"].DisplayIndex = 1;
            this.Dtg1.Columns["ValorVenta"].DisplayIndex = 2;
            this.Dtg1.Columns["Cantidad"].DisplayIndex = 3;
            this.Dtg1.Columns["Cantidad"].HeaderText = "Propias";
            this.Dtg1.Columns["ValorCompra"].HeaderText = "Valor\nCompra";
            this.Dtg1.Columns["ValorVenta"].HeaderText = "Valor\nVenta";

        }

        private void btn_Salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

