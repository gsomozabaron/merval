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
            Dtg1.AutoGenerateColumns = false;
            Dtg1.Columns.Add("Titulo", "Título");
            Dtg1.Columns.Add("Cotizacion", "Cotización");
            Dtg1.Columns.Add("Cartera", "Cartera");
            Dtg1.Columns.Add("PrecioCompra", "Precio de Compra");
            Dtg1.Columns.Add("Cantidad", "Cantidad");
            Dtg1.Columns.Add("FechaCompra", "Fecha de Compra");

            Dtg1.DataSource = usuarioActual.ListadoDeAccionesPropias;
        }

        private void Dtg1_CellFormatting_1(object sender, DataGridViewCellFormattingEventArgs e)
        {

            if (e.RowIndex >= 0 && e.RowIndex < Dtg1.Rows.Count)
            {
                if (e.ColumnIndex == Dtg1.Columns["Titulo"].Index)
                {
                    e.Value = usuarioActual.ListadoDeAccionesPropias[e.RowIndex].Nombre;
                }
                else if (e.ColumnIndex == Dtg1.Columns["Cotizacion"].Index)
                {
                    e.Value = usuarioActual.ListadoDeAccionesPropias[e.RowIndex].Valor.ToString();
                }
                else if (e.ColumnIndex == Dtg1.Columns["Cartera"].Index)
                {
                    e.Value = usuarioActual.ListadoDeAccionesPropias[e.RowIndex].Nombre;
                }
                else if (e.ColumnIndex == Dtg1.Columns["PrecioCompra"].Index)
                {
                    e.Value = usuarioActual.ListadoDeAccionesPropias[e.RowIndex].Valor.ToString();
                }
                else if (e.ColumnIndex == Dtg1.Columns["Cantidad"].Index)
                {
                    e.Value = usuarioActual.ListadoDeAccionesPropias[e.RowIndex].Cantidad.ToString();
                }
                else if (e.ColumnIndex == Dtg1.Columns["FechaCompra"].Index)
                {
                    e.Value = usuarioActual.ListadoDeAccionesPropias[e.RowIndex].Fecha.ToString("dd/MM/yyyy");
                }
            }

        }

        private void btn_Salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_calcularVenta_Click(object sender, EventArgs e)
        {
            float cotizacion = float.Parse(txt_cotizacion.Text);
            int cantidad = int.Parse(txt_Cantidad.Text);
            float totalVenta = cotizacion * cantidad;
            lbl_totalVenta.Text = totalVenta.ToString();
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

        private void btn_Vender_Click(object sender, EventArgs e)
        {
            foreach (Acciones a in usuarioActual.ListadoDeAccionesPropias)
            {
                if ((a.Nombre == txt_titulo.Text) && (int.Parse(txt_Cantidad.Text) <= a.Cantidad))
                {
                    VentanaConfirmar vc = new VentanaConfirmar("Comfirmar venta?", $"{txt_Cantidad.Text} de: {txt_titulo.Text}");
                    if (vc.ShowDialog() == DialogResult.OK)
                    {
                        a.Cantidad = a.Cantidad - int.Parse(txt_Cantidad.Text);
                        if (a.Cantidad == 0)
                        {
                            usuarioActual.ListadoDeAccionesPropias.Remove(a);
                        }
                        usuarioActual.Saldo = usuarioActual.Saldo + float.Parse(lbl_totalVenta.Text);
                        Serializadora.ActualizarUsuario(usuarioActual, listaUsuarios);
                        this.Close();
                        break;
                    }
                    else
                    {
                        VentanaEmergente ve = new VentanaEmergente("Venta", "cancelada");
                        ve.ShowDialog();
                    }
                }
                else
                {
                    if ((a.Nombre == txt_titulo.Text) && (int.Parse(txt_Cantidad.Text) > a.Cantidad))
                    {
                        Ventana_error ve = new Ventana_error($"maximo {a.Cantidad}\nde {a.Nombre}");
                        ve.ShowDialog();
                        break;
                    }
                }
            }
        }
    }
}
