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
            Dtg1.Columns["fecha"].Visible = false;
            Dtg1.Columns["cantidad"].Visible = false;
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
                lbl_totalventa.Text = totalCompra.ToString();
                bool estaEnLista = false;

                try
                {
                    if (usuarioActual.Saldo >= totalCompra)
                    {
                        Acciones nuevaAccion = new Acciones();
                        nuevaAccion.Nombre = txt_titulo.Text;
                        nuevaAccion.Valor = txt_cotizacion.Text;
                        nuevaAccion.Fecha = DateTime.Now;
                        nuevaAccion.Cantidad = cantidad;

                        VentanaConfirmar Vc = new VentanaConfirmar("Confirmar compra?", "");

                        if (Vc.ShowDialog() == DialogResult.OK)
                        {
                            usuarioActual.Saldo -= totalCompra;
                            if (usuarioActual.ListadoDeAccionesPropias == null)
                            {
                                usuarioActual.ListadoDeAccionesPropias.Add(nuevaAccion);
                            }
                            else
                            {
                                foreach (Acciones a in usuarioActual.ListadoDeAccionesPropias)
                                {
                                    if (a.Nombre == nuevaAccion.Nombre)
                                    {
                                        a.Cantidad = nuevaAccion.Cantidad + a.Cantidad;
                                        estaEnLista = true;
                                        break;
                                    }
                                }
                            }
                            if (estaEnLista == false)
                            {
                                usuarioActual.ListadoDeAccionesPropias.Add(nuevaAccion);
                            }
                            VentanaEmergente ve = new VentanaEmergente("Transaccion exitosa", $"adquirido {cantidad} acciones, de {nuevaAccion.Nombre}");
                            ve.ShowDialog();
                            Serializadora.ActualizarUsuario(usuarioActual, listaUsuarios);
                            this.Close();
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
                    // Manejo de excepciones en caso de que la conversion falle
                    Ventana_error ve = new Ventana_error("Inesperado");
                    ve.ShowDialog();

                }
            }
            catch (Exception)
            {
                Ventana_error ve = new Ventana_error("Ingresa una cantidad");
                ve.ShowDialog();
            }

        }

        private void btn_calcularCompra_Click(object sender, EventArgs e)
        {
            try
            {
                float cotizacion = float.Parse(txt_cotizacion.Text);
                int cantidad = int.Parse(txt_Cantidad.Text);
                float totalCompra = cotizacion * cantidad;
                lbl_totalventa.Text = totalCompra.ToString();

            }
            catch (Exception)
            {
                Ventana_error ve = new Ventana_error("ingresa cantidad\nen numeros");
                ve.ShowDialog();
            }
        }

    }
}
