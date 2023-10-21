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

        private void FormOperar_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void CargarDatos()
        {
            Dtg1.DataSource = Serializadora.LeerListaAcciones();
            Dtg1.Columns["fecha"].Visible = false;
            Dtg1.Columns["cantidad"].Visible = false;
            lbl_saldo.Text = usuarioActual.Saldo.ToString();
            btn_Comprar.Enabled = false;
        }

        private void btn_Salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

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

        private void btn_Comprar_Click(object sender, EventArgs e)
        {
            if (txt_titulo.Text == "")
            {
                Vm.VentanaMensajeError("Selecciona un accion");
                return;
            }
            try
            {
                float cotizacion = float.Parse(txt_cotizacion.Text);
                int cantidad = int.Parse(txt_Cantidad.Text);
                float totalCompra = cotizacion * cantidad;
                lbl_totalventa.Text = totalCompra.ToString();

                if (cantidad <= 0)
                {
                    Vm.VentanaMensajeError("La cantidad debe ser mayor que 0.");
                    return;
                }

                if (usuarioActual.Saldo < totalCompra)
                {
                    Vm.VentanaMensajeError("Saldo insuficiente.");
                    return;
                }

                if (Vm.VentanaMensajeConfirmar("Confirmar compra?", "") != DialogResult.OK)
                {
                    Vm.VentanaMensaje("Compra", "Cancelada");
                    return;
                }

                Acciones nuevaAccion = new Acciones();
                nuevaAccion.Nombre = txt_titulo.Text;
                nuevaAccion.ValorCompra = decimal.Parse(txt_cotizacion.Text);
                nuevaAccion.Fecha = DateTime.Now;
                nuevaAccion.Cantidad = cantidad;

                usuarioActual.Saldo -= totalCompra;
                usuarioActual.ListadoDeAccionesPropias = usuarioActual.ListadoDeAccionesPropias ?? new List<Acciones>();

                bool estaEnLista = false;
                foreach (Acciones a in usuarioActual.ListadoDeAccionesPropias)
                {
                    if (a.Nombre == nuevaAccion.Nombre)
                    {
                        a.Cantidad += nuevaAccion.Cantidad;
                        estaEnLista = true;
                        break;
                    }
                }

                if (!estaEnLista)
                {
                    usuarioActual.ListadoDeAccionesPropias.Add(nuevaAccion);
                }

                Serializadora.ActualizarUsuario(usuarioActual, listaUsuarios);
                Vm.VentanaMensaje("Transaccion exitosa", $"Adquirido {cantidad}\nde\n{nuevaAccion.Nombre}");
            }
            catch (FormatException)
            {
                Vm.VentanaMensajeError("Ingresa una cantidad valida.");
            }
            catch (Exception ex)
            {
                Vm.VentanaMensajeError($"Error: {ex.Message}");
            }
        }

        private void btn_calcularCompra_Click(object sender, EventArgs e)
        {
            btn_Comprar.Enabled = true;
            try
            {
                float cotizacion = float.Parse(txt_cotizacion.Text);
                int cantidad = int.Parse(txt_Cantidad.Text);
                float totalCompra = cotizacion * cantidad;
                lbl_totalventa.Text = totalCompra.ToString();
            }
            catch (FormatException)
            {
                Vm.VentanaMensajeError("Ingresa una cantidad valida.");
            }
        }
    }
}

