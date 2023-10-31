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
    public partial class FormBajaDeAcciones : Form
    {

        List<Acciones> listadeAccionesGral = Serializadora.LeerListaAcciones();
        List<Monedas> listadeMonedasGral = Serializadora.LeerListaMonedas();

        public FormBajaDeAcciones(string tipo)
        {
            InitializeComponent();
            txt_tipo.Text = tipo;
        }

        private void FormBajaDeAcciones_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void CargarDatos()
        {
            if (txt_tipo.Text == "Acciones")
            {
                DTG_BajaAcciones.DataSource = listadeAccionesGral;
            }
            if (txt_tipo.Text == "Monedas")
            {
                DTG_BajaAcciones.DataSource = listadeMonedasGral;
            }
            DTG_BajaAcciones.Columns["cantidad"].Visible = false;
        }

        private void btn_Buscar_Click(object sender, EventArgs e)
        {
            bool encontro = false;
            txt_Nombre.Text = "nombre";
            string buscar = txt_clave.Text;

            if (buscar == "")   //si la casilla buscar esta vacia mensaje y retornar
            {
                Vm.VentanaMensaje("Ingrese", "nombre o parte del nombre");
                return;
            }

            if (txt_tipo.Text == "Acciones")
            {
                foreach (Acciones a in listadeAccionesGral)
                {
                    try
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
                    catch (Exception ex)
                    {
                        Vm.VentanaMensajeError($"Error: {ex.Message}");    //si rompe.. mensaje
                    }
                }
            }
            else if (txt_tipo.Text == "Monedas")
            {
                foreach (Monedas a in listadeMonedasGral)
                {
                    try
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
                    catch (Exception ex)
                    {
                        Vm.VentanaMensajeError($"Error: {ex.Message}");    //si rompe.. mensaje
                    }
                }
            }

            if (!encontro)
            {   //si no encontro coincidencia tira mensaje
                Vm.VentanaMensajeError("Titulo no encontrado");
            }
        }






        ////////////////////////////////////////////////////////////////////////
        private void btn_EliminarAccion_Click(object sender, EventArgs e)
        {
            if (txt_tipo.Text == "Acciones")
            {
                Acciones a = (Acciones)DTG_BajaAcciones.SelectedRows[0].DataBoundItem;

                if (Vm.VentanaMensaje("ATENCION", "SE ELIMINARA\n PERMANENTEMENTE EL TITULO") == DialogResult.OK)
                {
                    listadeAccionesGral.Remove(a);
                    Serializadora.GuardarGralAcciones(listadeAccionesGral);///guarda en archivo la lista de acciones
                    Vm.VentanaMensaje("TITULO", "ELIMINADO");
                    this.Close();
                    //DTG_BajaAcciones.DataSource = Serializadora.LeerListaAcciones();///carga el datagrid con la lista actualizada
                }
                else
                {
                    Vm.VentanaMensaje("OPERACION", "CANCELADA");
                }
                /**************************************************************************/
                ////////////    arreglar!!!!!!   //////////////////////////////////////////
            }/////////////polimorfismoooo/////////////////////////////////////////////
            else if (txt_tipo.Text == "Monedas")
            {
                Monedas a = (Monedas)DTG_BajaAcciones.SelectedRows[0].DataBoundItem;

                if (Vm.VentanaMensaje("ATENCION", "SE ELIMINARA\n PERMANENTEMENTE EL TITULO") == DialogResult.OK)
                {
                    listadeMonedasGral.Remove(a);
                    Serializadora.GuardarGralMonedas(listadeMonedasGral);///guarda en archivo la lista de acciones
                    Vm.VentanaMensaje("TITULO", "ELIMINADO");
                    this.Close();
                    ///DTG_BajaAcciones.DataSource = Serializadora.LeerListaMonedas();///carga el datagrid con la lista actualizada
                }
                else
                {
                    Vm.VentanaMensaje("OPERACION", "CANCELADA");
                }
            }
        }

        private void DTG_BajaAcciones_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //seleccionar con doble click
            if (txt_tipo.Text == "Acciones")
            {
                if (DTG_BajaAcciones.SelectedRows.Count > 0)
                {
                    Acciones a = (Acciones)DTG_BajaAcciones.SelectedRows[0].DataBoundItem;
                    txt_Nombre.Text = a.Nombre;
                }
            }
            if (txt_tipo.Text == "Monedas")
            {
                if (DTG_BajaAcciones.SelectedRows.Count > 0)
                {
                    Monedas a = (Monedas)DTG_BajaAcciones.SelectedRows[0].DataBoundItem;
                    txt_Nombre.Text = a.Nombre;              
                }
            }
        }

        private void btn_actualizar_Click(object sender, EventArgs e)
        {
            if (txt_tipo.Text == "Acciones")
            {
                Acciones a = (Acciones)DTG_BajaAcciones.SelectedRows[0].DataBoundItem;
                a.Nombre = txt_Nombre.Text;

                if (Vm.VentanaMensajeConfirmar("ATENCION", "esta seguro?\nSe sobreescribira el archivo ") == DialogResult.OK)
                {
                    Serializadora.GuardarGralAcciones(listadeAccionesGral);
                    DTG_BajaAcciones.DataSource = Serializadora.LeerListaAcciones();
                }
                else
                {
                    DTG_BajaAcciones.DataSource = listadeAccionesGral;
                }
            }
            else if (txt_tipo.Text == "Monedas")
            {
                Monedas a = (Monedas)DTG_BajaAcciones.SelectedRows[0].DataBoundItem;
                a.Nombre = txt_Nombre.Text;

                if (Vm.VentanaMensajeConfirmar("ATENCION", "esta seguro?\nSe sobreescribira el archivo ") == DialogResult.OK)
                {
                    Serializadora.GuardarGralMonedas(listadeMonedasGral);
                    DTG_BajaAcciones.DataSource = Serializadora.LeerListaMonedas();
                }
                else
                {
                    DTG_BajaAcciones.DataSource = listadeMonedasGral;
                }
            }
        }
        
        
        
        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
