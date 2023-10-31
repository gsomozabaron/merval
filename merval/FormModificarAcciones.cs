using merval.entidades;
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
        List<Monedas> listaM = Serializadora.LeerListaMonedas();



        public FormModificarAcciones(string tipo)
        {
            InitializeComponent();
            txt_tipo.Text = tipo;
        }
        private void FormModificarAcciones_Load(object sender, EventArgs e)
        {
            ResetearBotones();
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            if (dataGridView1.SelectedRows.Count > 0)
            {
                Activos seleccion = (Activos)dataGridView1.SelectedRows[0].DataBoundItem;
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

            foreach (Activos a in lista)
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
            if (txt_tipo.Text == "Monedas")
            {
                this.dataGridView1.DataSource = listaM;
                this.dataGridView1.Columns["cantidad"].Visible = false;
                this.Btn_modificar.Enabled = false;
                this.Btn_modificar.BackColor = System.Drawing.Color.Yellow;
            }
            else if (txt_tipo.Text == "Acciones")
            {
                this.dataGridView1.DataSource = lista;
                this.dataGridView1.Columns["cantidad"].Visible = false;
                this.Btn_modificar.Enabled = false;
                this.Btn_modificar.BackColor = System.Drawing.Color.Yellow;
            }

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
                    if (txt_tipo.Text == "Acciones")
                    {
                        Acciones.ModificarDatos(nombre, valorCompra, valorVenta, lista);
                    }
                    else if(txt_tipo.Text == "Monedas")
                    {
                        Monedas.ModificarDatos(nombre, valorCompra, valorVenta, listaM);
                    }
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
