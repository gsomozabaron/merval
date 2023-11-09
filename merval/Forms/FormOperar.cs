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
using merval.entidades;
using merval.Serializadores;
using merval.DB;

namespace merval
{
    public partial class FormOperar : Form
    {
        private List<Usuario> listaUsuarios;
        private Usuario usuarioActual;
        private string tipoDeActivo;

        public FormOperar(Usuario usuario, string tipo)
        {
            InitializeComponent();
            tipoDeActivo = tipo;
            usuarioActual = usuario;
            //listaUsuarios = Serializadora.LeerListadoUsuarios();
            listaUsuarios = DatabaseSQL.GetUsuarios();
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
            string titulo = txt_titulo.Text;

            (decimal cotizacion,int cantidad, decimal totalCompra) = calcularCompra();

            Usuario.ComprarActivo(usuarioActual, titulo, cantidad, totalCompra, tipoDeActivo);

            lbl_saldo.Text = null;  //borra saldo viejo para cargar el nuevo saldo
            lbl_saldo.Text = usuarioActual.Saldo.ToString();    //refresh saldo
            CargarDatos();  //refresh datagrid
        }


   
        /// llama a la funcion calcular compra
        private void btn_calcularCompra_Click(object sender, EventArgs e)
        {
            btn_Comprar.Enabled = true;
            calcularCompra();
        }

        /// clacula el total de la compra
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
                return (0, 0, 0);
            }
        }
       
        /// genera una lista de acciones propias del usuario con sus precios y lo carga al datagrid
        private void CargarDatos()
        {
            
            lbl_saldo.Text = usuarioActual.Saldo.ToString();
            
            if (tipoDeActivo == "Monedas")
            {
                List<Monedas> listaMonedas = Serializadora.LeerListaMonedas();
                if (usuarioActual.ListadoDeActivosPropios.Count > 0) //por si el usuario no tiene ninguna accion
                {
                    foreach (Activos a in listaMonedas) //a = acciones en listado general de acciones
                    {
                        foreach (Activos ac in usuarioActual.ListadoDeActivosPropios) //au = acciones usuario
                        {
                            if (a.Nombre == ac.Nombre)
                            {
                                a.Cantidad = ac.Cantidad;
                            }
                        }
                    }
                }
                this.Dtg1.DataSource = listaMonedas;
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
            else if (tipoDeActivo == "Acciones")
            {
                //List<Acciones> listaAcciones = Serializadora.LeerListaAcciones();
                List<Acciones> listaAcciones = DatabaseSQL.CrearListaAcciones();

                if (usuarioActual.ListadoDeActivosPropios.Count > 0) //por si el usuario no tiene ninguna accion
                {
                    foreach (Activos a in listaAcciones) //a = acciones en listado general de acciones
                    {
                        foreach (Activos ac in usuarioActual.ListadoDeActivosPropios) //au = acciones usuario
                        {
                            if (a.Nombre == ac.Nombre)
                            {
                                a.Cantidad = ac.Cantidad;
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
        }

        private void btn_Salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

