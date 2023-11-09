﻿using merval.DB;
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
    public partial class FormAltaAcciones : Form
    {
        public FormAltaAcciones(string tipoActivo)
        {
            InitializeComponent();
            txt_tipo.Text = tipoActivo;
        }

        //aceptar da de alta nuevos activos
        private void btn_aceptar_Click(object sender, EventArgs e)
        {
            string form = "Admin, Alta de acciones";
               
            ManejadorDeExcepciones.ManejarExcepcion(form, () =>
            {
                string titulo = txt_Titulo.Text;
        
                List<Acciones> listaAccionesGral = DatabaseSQL.CrearListaAcciones();
                List<Monedas> listaMonedasGral = DatabaseSQL.CrearListaMonedas();

                
                decimal valorCompra = decimal.Parse(Txt_ValorCompra.Text);
                decimal valorVenta = decimal.Parse(txt_ValorVenta.Text);

                if (ValidarDatos.CadenaVacia(titulo) 
                    || ValidarDatos.CadenaVacia(valorCompra.ToString()) 
                    || ValidarDatos.CadenaVacia(valorVenta.ToString()))
                {
                    Vm.VentanaMensajeError("Tanto el titulo como los precios \nson obligatorios.");
                    return;
                }


                else if ((listaAccionesGral.Any(a => a.Nombre == titulo) && txt_tipo.Text == "Acciones") ||
                        (listaMonedasGral.Any(a => a.Nombre == titulo) && txt_tipo.Text == "Monedas"))
                {
                    Vm.VentanaMensajeError("El titulo ya se encuentra dado de alta");
                }

                else    //crear activos!
                {
                    if (txt_tipo.Text == "Acciones")
                    {
                        Acciones a = Acciones.CrearAccion(titulo, valorCompra, valorVenta);
                        DatabaseSQL.InsertarActivo("acciones", a);
                    }

                    if (txt_tipo.Text == "Monedas")
                    {
                        Monedas m = Monedas.CrearMoneda(titulo, valorCompra, valorVenta);
                        DatabaseSQL.InsertarActivo("monedas", m);
                    }
                                    
                    txt_Titulo.Clear(); // Limpiar los campos después de agregar
                    Txt_ValorCompra.Clear();
                    txt_ValorVenta.Clear();
                }

            });
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
