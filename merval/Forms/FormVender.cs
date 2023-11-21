using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using merval.DB;
using merval.Opercaciones;
using merval.Serializadores;
using merval.Ventanas_Emergentes;

namespace merval
{
    public partial class FormVender : Form
    {

        private UsuarioSQL usuarioActual;
        private string tipoDeActivo;

        public FormVender(UsuarioSQL usuario, string tipo)
        {
            InitializeComponent();
            usuarioActual = usuario;
            tipoDeActivo = tipo;
        }

        private void FormVender_Load(object sender, EventArgs e)
        {
            if (tipoDeActivo == "Acciones")
            {
                VerAccionesDatagrid();
            }
            else if (tipoDeActivo == "Monedas")
            {
                VerMonedasDatagrid();
            }
            btn_Vender.Enabled = false;


        }

        private void VerAccionesDatagrid()
        {
            List<Activos> listDTG = UsuarioSQL.CarteraUsuario(usuarioActual, tipoDeActivo);
            LlenarDatagrid(listDTG);
        }

        private void VerMonedasDatagrid()
        {
            List<Activos> listDTG = UsuarioSQL.CarteraUsuario(usuarioActual, tipoDeActivo);
            LlenarDatagrid(listDTG);
        }

        private void LlenarDatagrid(List<Activos> listDTG)
        {
            this.Dtg1.DataSource = null;///para hacer un refresh
            this.Dtg1.Visible = true;
            this.Dtg1.DataSource = listDTG;
            // Cambiar el orden de las columnas 
            this.Dtg1.Columns["Nombre"].DisplayIndex = 0;
            this.Dtg1.Columns["Cantidad"].DisplayIndex = 1;
            this.Dtg1.Columns["ValorCompra"].DisplayIndex = 2;
            this.Dtg1.Columns["ValorVenta"].DisplayIndex = 3;
        }

        private void btn_calcularVenta_Click(object sender, EventArgs e)
        {
            btn_Vender.Enabled = true;

            try
            {
                float cotizacion = float.Parse(txt_cotizacion.Text);
                int cantidad = int.Parse(txt_Cantidad.Text);
                float totalVenta = cotizacion * cantidad;
                lbl_totalVenta.Text = totalVenta.ToString();

            }
            catch (Exception)
            {
                if (txt_Cantidad.Text == "")
                {
                    Vm.VentanaMensajeError("Ingresa cantidad");
                }
                else
                {
                    Vm.VentanaMensajeError("Solo numeros");
                }
            }
        }

        private void Dtg1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (Dtg1.SelectedRows.Count > 0)
            {
                Activos Seleccionado = (Activos)Dtg1.SelectedRows[0].DataBoundItem;

                txt_titulo.Text = Seleccionado.Nombre;
                txt_cotizacion.Text = Seleccionado.ValorVenta.ToString();
            }
        }


        private void btn_Vender_Click(object sender, EventArgs e)
        {
            string Ventastr = lbl_totalVenta.Text;
            string titulo = txt_titulo.Text;
            string cantidadStr = txt_Cantidad.Text;
            
            bool vendido = Operaciones.VentaDeActivos(usuarioActual,tipoDeActivo,Ventastr,titulo,cantidadStr);
            if (vendido)
            {
                this.btn_Vender.Click -= btn_Vender_Click;
                this.btn_Vender.Click += BotonRecibo;
                btn_Vender.Text = "Obtener Recibo";
            }
        }

        private void BotonRecibo(object sender, EventArgs e)
        {
            string compraOventa = "Venta";
            decimal cotizacion = decimal.Parse(txt_cotizacion.Text);
            int cantidad = int.Parse(txt_Cantidad.Text);
            decimal totalCompra = cotizacion * cantidad;
            lbl_totalVenta.Text = totalCompra.ToString();
            string titulo = txt_titulo.Text;

            string recibo = FormOperar.CrearRecibo(compraOventa, usuarioActual, titulo, cantidad, totalCompra, tipoDeActivo);

            VentanaRecibo vr = new VentanaRecibo(recibo);
            btn_Vender.ForeColor = System.Drawing.Color.Aquamarine;
            btn_Vender.Text = "VENDER";
            this.btn_Vender.Click -= BotonRecibo;
            this.btn_Vender.Click += btn_Vender_Click;
            btn_Vender.Enabled = false;
            vr.ShowDialog();

        }


        private void btn_Salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
