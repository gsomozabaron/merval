﻿using merval.DB;
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
    public partial class FormBajaDeAcciones : Form
    {

        List<Acciones> listadeAccionesGral = DatabaseSQL.CrearListaAcciones();
        List<Monedas> listadeMonedasGral = DatabaseSQL.CrearListaMonedas();

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
            try
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
                }
                else if (txt_tipo.Text == "Monedas")
                {
                    foreach (Monedas a in listadeMonedasGral)
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
            Acciones a = (Acciones)DTG_BajaAcciones.SelectedRows[0].DataBoundItem;

            if (Vm.VentanaMensaje("ATENCION", "SE ELIMINARA\n PERMANENTEMENTE EL TITULO") == DialogResult.OK)
            {
                DatabaseSQL.EliminarActivo(a, txt_tipo.Text);
            }
            else
            {
                Vm.VentanaMensaje("OPERACION", "CANCELADA");
            }
            DTG_BajaAcciones = null;
            CargarDatos();
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
                    //DTG_BajaAcciones.DataSource = Serializadora.LeerListaAcciones();
                    DTG_BajaAcciones.DataSource = DatabaseSQL.CrearListaAcciones();
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