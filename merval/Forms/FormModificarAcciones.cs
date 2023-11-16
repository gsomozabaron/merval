using merval.DB;
using merval.entidades;
using merval.Serializadores;
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
        private List<Acciones> listaAcciones;
        private List<Monedas> listaMonedas;



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
                txt_id.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
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

            List<Activos> lista = (txt_tipo.Text == "Monedas") ? 
                listaMonedas.Cast<Activos>().ToList() : listaAcciones.Cast<Activos>().ToList();

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

        private async void ResetearBotones()
        {
            
            if (txt_tipo.Text == "Monedas")
            {
                
                listaMonedas = await Monedas.CrearListaMonedas();
                this.dataGridView1.DataSource = listaMonedas;
            }
            else if (txt_tipo.Text == "Acciones")
            {
                listaAcciones = await Acciones.CrearListaAcciones();
                this.dataGridView1.DataSource = listaAcciones;
            }
            this.dataGridView1.Columns["cantidad"].Visible = false;
            this.Btn_modificar.Enabled = false;
            this.Btn_modificar.BackColor = System.Drawing.Color.Yellow;
             
        }

        private async void Btn_modificar_Click(object sender, EventArgs e)
        {
            try
            {
                string tipo = txt_tipo.Text;
                decimal valorCompra = decimal.Parse(txt_Vcompra.Text);
                decimal valorVenta = decimal.Parse(txt_Vventa.Text);
                string nombre = txt_Titulo.Text;
                string id = txt_id.Text;

                if (Vm.VentanaMensajeConfirmar("confirmar", "cambios") == DialogResult.OK)
                {
                    Activos a = new Activos();   
                    await a.ModificarActivo(tipo, nombre, valorCompra, valorVenta, id);
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
            finally 
            {
                dataGridView1.DataSource = null;
                ResetearBotones();
            }

        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
