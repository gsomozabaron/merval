using merval.DB;
using merval.entidades;
using merval.Interfaces;
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
    public partial class FormBajaDeActivos : Form
    {
        string formName = "Admin, baja acciones";
        string mensaje = string.Empty;

        public FormBajaDeActivos(string tipo)
        {
            InitializeComponent();
            txt_tipo.Text = tipo;
        }

        private void FormBajaDeAcciones_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private async void CargarDatos()
        {
            Activos activos = new Activos();
            List<Activos> lista = await activos.CrearListaDeActivos(txt_tipo.Text);
            DTG_BajaAcciones.DataSource = lista;
            DTG_BajaAcciones.Columns["cantidad"].Visible = false;
        }

        private async Task<List<Activos>> CrearListaActivos()
        {
            Activos a = new Activos();
            List<Activos> lista = await a.CrearListaDeActivos(txt_tipo.Text);
            return lista;
        }

        private async void btn_Buscar_Click(object sender, EventArgs e)
        {
            try
            {
                List<Activos> lista = await CrearListaActivos();
                bool encontro = false;
                txt_Nombre.Text = "nombre";
                string buscar = txt_clave.Text;

                if (buscar == "")   //si la casilla buscar esta vacia mensaje y retornar
                {
                    Vm.VentanaMensaje("Ingrese", "nombre o parte del nombre");
                    return;
                }

                foreach (Activos a in lista)
                {
                    if (a.Nombre.ToLower().Contains(buscar))    //recorrer la lista de acciones buscando coincidencias en accion.nombre
                    {
                        if (Vm.VentanaMensajeConfirmar($"{a.Nombre}", "es la indicada?") == DialogResult.OK)
                        {
                            txt_Nombre.Text = a.Nombre.ToString();
                            encontro = true;
                            break;
                        }
                    }
                }
                
                if (!encontro)
                {   //si no encontro coincidencia tira mensaje
                    Vm.VentanaMensajeError("Titulo no encontrado");
                }
            }
            catch (Exception ex)
            {
                Vm.VentanaMensajeError($"Error: {ex.Message}");    //si rompe.. mensaje
            }
        }

        private void btn_EliminarAccion_Click(object sender, EventArgs e)
        {
            Activos a = (Activos)DTG_BajaAcciones.SelectedRows[0].DataBoundItem;

            if (Vm.VentanaMensaje("ATENCION", "SE ELIMINARA\n PERMANENTEMENTE EL TITULO") == DialogResult.OK)
            {
                a.EliminarActivo(a, txt_tipo.Text);
            }
            else
            {
                Vm.VentanaMensaje("OPERACION", "CANCELADA");
            }
            CargarDatos();
        }

        private void DTG_BajaAcciones_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Activos a = (Activos)DTG_BajaAcciones.SelectedRows[0].DataBoundItem;
            txt_Nombre.Text = a.Nombre;
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
