using merval.DB;
using merval.entidades;
using merval.Excepciones;
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
    public partial class FormModificarActivos : Form
    {
        string formName = "Admin Modificar activos";
        string mensaje = string.Empty;  


        public FormModificarActivos(string tipo)
        {
            InitializeComponent();
            txt_tipo.Text = tipo;
            txt_id.Visible = true;
        }
        private void FormModificarAcciones_Load(object sender, EventArgs e)
        {
            ActualizarGrid();
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
                txt_id.Text = seleccion.Id.ToString();
                txt_Vcompra.Enabled = true;
                txt_Vventa.Enabled = true;
                Btn_modificar.Enabled = true;
                Btn_modificar.BackColor = System.Drawing.Color.Green;
            }

        }


        private async Task<List<Activos>> ObtenerListaDeActivos()
        {
            
            txt_Titulo.Text = "nombre";
            txt_Vcompra.Text = "Valor compra";
            txt_Vventa.Text = "Valor venta";
            string tipo = txt_tipo.Text;
            Activos a = new Activos();
            List<Activos> lista = await a.CrearListaDeActivos(tipo);
            
            return lista;
        }
        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                List<Activos> lista = await ObtenerListaDeActivos();
                bool encontro = false;
                string buscar = txt_BuscarTitulo.Text.ToLower();

                foreach (Activos a in lista)
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
                if (!encontro)
                {
                    Vm.VentanaMensajeError("titulo no encontrado");
                    txt_BuscarTitulo.Clear();
                }
            }
            catch (Exception ex)
            {
                Vm.VentanaMensajeError($"Error: {ex.Message}");
            }
        }

        private async void ActualizarGrid()
        {
            try
            {
                List<Activos> lista = await ObtenerListaDeActivos();
                this.dataGridView1.DataSource = lista;
                this.dataGridView1.Columns["cantidad"].Visible = false;
                this.Btn_modificar.Enabled = false;
                this.Btn_modificar.BackColor = System.Drawing.Color.Yellow;

            }
            catch (NullReferenceException ex)
            {
                mensaje = "No se encontro la lista";
                Vm.VentanaMensajeError (mensaje);
                ManejadorDeExcepciones.CrearErrorLog(formName, ex, mensaje);
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                mensaje = "Al conectar a la base de datos ";
                ManejadorDeExcepciones.CrearErrorLog(formName, ex, mensaje);
            }

        }
        private void LimpiarLabels()
        {
            txt_Vcompra.Clear();
            txt_Vventa.Clear();
            txt_Titulo.Clear();
            txt_id.Clear();
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

                    LimpiarLabels();
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
                
                ActualizarGrid();
            }

        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
