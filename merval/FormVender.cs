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
    public partial class FormVender : Form
    {
        private List<Usuario> listaUsuarios = Serializadora.LeerListadoUsuarios();
        private Usuario usuarioActual;

        public FormVender(Usuario usuario)
        {
            InitializeComponent();
            usuarioActual = usuario;
        }

        private void FormVender_Load(object sender, EventArgs e)
        {
            VerAccionesDatagrid();
        }
        private void VerAccionesDatagrid()
        {
            List<Acciones> listaAccionesGral = Serializadora.LeerListaAcciones();
            /////////////////
            List<Acciones> listDTG = new List<Acciones>();
            foreach (Acciones acc in usuarioActual.ListadoDeAccionesPropias)
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
            this.Dtg1.DataSource = null;///para hacer un refresh
            this.Dtg1.Visible = true;
            this.Dtg1.DataSource = listDTG;
            // Cambiar el orden de las columnas
            this.Dtg1.Columns["Nombre"].DisplayIndex = 0;
            this.Dtg1.Columns["Cantidad"].DisplayIndex = 1;
            this.Dtg1.Columns["ValorCompra"].DisplayIndex = 2;
            this.Dtg1.Columns["ValorVenta"].DisplayIndex = 3;
        }

        private void btn_Salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_calcularVenta_Click(object sender, EventArgs e)
        {
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
                Acciones Seleccionado = (Acciones)Dtg1.SelectedRows[0].DataBoundItem;

                txt_titulo.Text = Seleccionado.Nombre;
                txt_cotizacion.Text = Seleccionado.ValorVenta.ToString();
            }
        }

        private void btn_Vender_Click(object sender, EventArgs e)
        {
            foreach (Acciones a in usuarioActual.ListadoDeAccionesPropias)
            {
                if ((a.Nombre == txt_titulo.Text) && (int.Parse(txt_Cantidad.Text) <= a.Cantidad))
                {
                    if (Vm.VentanaMensajeConfirmar("Comfirmar venta?", $"{txt_Cantidad.Text} de: {txt_titulo.Text}") == DialogResult.OK)
                    {
                        a.Cantidad = a.Cantidad - int.Parse(txt_Cantidad.Text);
                        if (a.Cantidad == 0)
                        {
                            usuarioActual.ListadoDeAccionesPropias.Remove(a);
                        }
                        usuarioActual.Saldo = usuarioActual.Saldo + decimal.Parse(lbl_totalVenta.Text);
                        Serializadora.ActualizarUsuario(usuarioActual, listaUsuarios);
                        this.Close();
                        break;
                    }
                    else
                    {
                        Vm.VentanaMensaje("Venta", "cancelada");
                    }
                }
                else
                {
                    if ((a.Nombre == txt_titulo.Text) && (int.Parse(txt_Cantidad.Text) > a.Cantidad))
                    {
                        Vm.VentanaMensajeError($"maximo {a.Cantidad}\nde {a.Nombre}");
                        break;
                    }
                }
            }
        }
    }
}
