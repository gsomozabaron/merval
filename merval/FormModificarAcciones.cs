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
    public partial class FormModificarAcciones : Form
    {
        List<Acciones> lista = Serializadora.LeerListaAcciones();

        public FormModificarAcciones()
        {
            InitializeComponent();
            ResetearBotones();
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                Acciones seleccion = (Acciones)dataGridView1.SelectedRows[0].DataBoundItem;
                ///llena las celdas con los datos de la accion seleccionada con doble click
                txt_Titulo.Text = seleccion.Nombre;
                txt_Vcompra.Text = seleccion.ValorCompra.ToString();
                txt_Vventa.Text = seleccion.ValorVenta.ToString();
                txt_Vcompra.Enabled = true;
                txt_Vventa.Enabled = true;
                Btn_modificar.Enabled = true;
                Btn_modificar.BackColor = System.Drawing.Color.Green;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool encontro = false;
            txt_Titulo.Text = "nombre";
            txt_Vcompra.Text = "Valor compra";
            txt_Vventa.Text = "Valor venta";
            string buscar = txt_BuscarTitulo.Text.ToLower();

            foreach (Acciones a in lista)
            {
                try
                {
                    if (a.Nombre.ToLower().Contains(buscar))
                    {
                        if (Vm.VentanaMensajeConfirmar($"{a.Nombre}", "es la buscada?") == DialogResult.OK)
                        {
                            txt_Titulo.Text = a.Nombre.ToString();
                            txt_Vcompra.Text = a.ValorCompra.ToString();
                            txt_Vventa.Text = a.ValorVenta.ToString();
                            encontro = true;
                            Btn_modificar.BackColor = System.Drawing.Color.Green;
                            Btn_modificar.Enabled = true;
                            break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Vm.VentanaMensajeError($"Error: {ex.Message}");
                }
            }
            if (!encontro)
            {
                Vm.VentanaMensajeError("titulo no encontrado");
            }
        }

        private void ResetearBotones()
        {
            this.dataGridView1.DataSource = lista;
            this.dataGridView1.Columns["cantidad"].Visible = false;
            this.dataGridView1.Columns["fecha"].Visible = false;
            this.Btn_modificar.Enabled = false;
            this.Btn_modificar.BackColor = System.Drawing.Color.Yellow;
        }

        private void Btn_modificar_Click(object sender, EventArgs e)
        {
            try
            {
                decimal valorCompra = decimal.Parse(txt_Vcompra.Text);
                decimal valorVenta = decimal.Parse(txt_Vventa.Text);
                string nombre = txt_Titulo.Text;
                if (Vm.VentanaMensajeConfirmar("confirmar", "cambios") == DialogResult.OK)
                {
                    Acciones.ModificarDatos(nombre, valorCompra, valorVenta, lista);
                    dataGridView1.DataSource = null;
                    ResetearBotones();
                }
                else
                {
                    Vm.VentanaMensaje("Operacion", "cancelada");
                }
            }
            catch (Exception)
            {
                Vm.VentanaMensajeError("ingrese solo\nvalores numericos");
            }

        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
