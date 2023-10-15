using Entidades;
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
        private List<Usuario> listaUsuarios = Serializadora.LeerListadoUsuarios();
        private Usuario usuarioActual;
        public FormOperar(Usuario usuario)
        {
            InitializeComponent();
            usuarioActual = usuario;
        }

        private void FormOperar_Load(object sender, EventArgs e)
        {
            Dtg1.DataSource = Serializadora.LeerListaAcciones();
            lbl_saldo.Text = usuarioActual.Saldo.ToString();
        }

        private void btn_Salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Dtg1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (Dtg1.SelectedRows.Count > 0)
            {
                Acciones Seleccionado = (Acciones)Dtg1.SelectedRows[0].DataBoundItem;

                txt_titulo.Text = Seleccionado.Nombre;
                txt_cotizacion.Text = Seleccionado.Valor;
            }
        }


        private void btn_Comprar_Click(object sender, EventArgs e)
        {
            try
            {
                float cotizacion = float.Parse(txt_cotizacion.Text);
                int cantidad = int.Parse(txt_Cantidad.Text);
                float totalCompra = cotizacion * cantidad;
                lbl_totalCompra.Text = totalCompra.ToString();

                try
                {
                    if (usuarioActual.Saldo >= totalCompra)
                    {
                        Acciones nuevaAccion = new Acciones();
                        nuevaAccion.Nombre = txt_titulo.Text;
                        nuevaAccion.Valor = txt_cotizacion.Text;
                        nuevaAccion.Fecha = DateTime.Now;
                        cantidad = Convert.ToInt32(txt_Cantidad.Text);
                        nuevaAccion.Cantidad = cantidad;
                        usuarioActual.Saldo -= totalCompra;
                        VentanaConfirmar Vc = new VentanaConfirmar("Confirmar", "compra?");

                        if (Vc.ShowDialog() == DialogResult.OK)
                        {
                            AgregarAcciones(usuarioActual, nuevaAccion);
                            Serializadora.ActualizarUsuario(usuarioActual, listaUsuarios);
                        }
                        else
                        {
                            VentanaEmergente Ve = new VentanaEmergente("Compra", "Cancelada");
                            ShowDialog();
                        }
                    }
                    else
                    {
                        Ventana_error ve = new Ventana_error("SALDO INSUFICIENTE");
                        ve.ShowDialog();
                    }
                }
                catch (FormatException)
                {
                    // Manejo de excepciones en caso de que la conversión falle
                    Ventana_error ve = new Ventana_error("Inesperado");
                    ve.ShowDialog();

                }
            }
            catch (Exception)
            {
                Ventana_error ve = new Ventana_error("Inesperado");
                ve.ShowDialog();
            }

        }

        private void btn_calcularCompra_Click(object sender, EventArgs e)
        {
            float cotizacion = float.Parse(txt_cotizacion.Text);
            int cantidad = int.Parse(txt_Cantidad.Text);
            float totalCompra = cotizacion * cantidad;
            lbl_totalCompra.Text = totalCompra.ToString();
        }
        public void AgregarAcciones(Usuario usuario, Acciones accion)
        {
            if (usuario.ListadoDeAccionesPropias == null)
            {
                usuario.ListadoDeAccionesPropias.Add(accion);
            }
            else
            {
                foreach (Acciones a in usuario.ListadoDeAccionesPropias)
                {
                    if (a.Nombre == accion.Nombre)
                    {
                        a.Cantidad = accion.Cantidad + a.Cantidad;
                        break;
                    }

                }
            }
        }
    }
}
