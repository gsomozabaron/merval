using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace merval
{
    public partial class FormOperar : Form
    {
        private List<Usuario> listaUsuarios;
        private Usuario usuarioActual;

        public FormOperar(Usuario usuario)
        {
            InitializeComponent();
            usuarioActual = usuario;
            listaUsuarios = Serializadora.LeerListadoUsuarios();
        }


        /// <summary>
        /// muestra el form de compras
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormOperar_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }


        /// <summary>
        /// selecciona el titulo con doble click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Dtg1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            btn_Comprar.Enabled = false;
            lbl_totalventa.Text = "$$$$$";
            txt_Cantidad.Clear();

            if (Dtg1.SelectedRows.Count > 0)
            {
                Acciones Seleccionado = (Acciones)Dtg1.SelectedRows[0].DataBoundItem;

                txt_titulo.Text = Seleccionado.Nombre;
                txt_cotizacion.Text = Seleccionado.ValorCompra.ToString();
            }
        }


        /// <summary>
        /// añade titulos a la lista de acciones del usuario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Comprar_Click(object sender, EventArgs e)
        {
            string titulo = txt_titulo.Text;

            (decimal cotizacion, int cantidad, decimal totalCompra) = calcularCompra();

            Usuario.ComprarAccion(usuarioActual, titulo, cantidad, totalCompra);
        
            lbl_saldo.Text = null;  //borra saldo viejo para cargar el nuevo saldo
            lbl_saldo.Text = usuarioActual.Saldo.ToString();    //refresh saldo
            CargarDatos();  //efresh datagrid
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
            catch (FormatException)
            {
                Vm.VentanaMensajeError("Ingresa una cantidad valida.");
                return (0,0,0);
            }
        }
        

        /// <summary>
        /// genera una lista de acciones propias del usuario con sus precios y lo carga al datagrid
        /// </summary>
        private void CargarDatos()
        {
            List<Acciones>listaAcciones = Serializadora.LeerListaAcciones();
            //Dtg1.Columns["cantidad"].Visible = false;
            lbl_saldo.Text = usuarioActual.Saldo.ToString();

            if (usuarioActual.ListadoDeAccionesPropias.Count > 0 ) //por si el usuario no tiene ninguna accion
            {
                foreach (Acciones a in listaAcciones) //a = acciones en listado general de acciones
                {
                    foreach (Acciones au in usuarioActual.ListadoDeAccionesPropias) //au = acciones usuario
                    {
                        if (a.Nombre == au.Nombre)
                        {
                            a.Cantidad = au.Cantidad;
                        }
                    }
                }
            }
            this.Dtg1.DataSource = listaAcciones;
            // Cambiar el orden de las columnas
            this.Dtg1.Columns["Nombre"].DisplayIndex = 0;
            this.Dtg1.Columns["ValorCompra"].DisplayIndex = 1;
            this.Dtg1.Columns["ValorVenta"].DisplayIndex = 2;
            this.Dtg1.Columns["Cantidad"].DisplayIndex = 3;
            this.Dtg1.Columns["Cantidad"].HeaderText = "Propias";
            this.Dtg1.Columns["ValorCompra"].HeaderText = "Valor\nCompra";
            this.Dtg1.Columns["ValorVenta"].HeaderText = "Valor\nVenta";
            btn_Comprar.Enabled = false;
        }

        private void btn_Salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

