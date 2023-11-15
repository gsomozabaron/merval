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
    public partial class FormAltaAcciones : Form
    {
        public FormAltaAcciones(string tipoActivo)
        {
            InitializeComponent();
            txt_tipo.Text = tipoActivo;
        }

        //aceptar da de alta nuevos activos
        private async void btn_aceptar_Click(object sender, EventArgs e)
        {      
            try
            {
                string titulo = txt_Titulo.Text;
        
                List<Acciones> listaAccionesGral = Acciones.CrearListaAcciones();
                List<Monedas> listaMonedasGral = Monedas.CrearListaMonedas();

                
                decimal valorCompra = decimal.Parse(Txt_ValorCompra.Text);
                decimal valorVenta = decimal.Parse(txt_ValorVenta.Text);

                if (string.IsNullOrEmpty(titulo) || string.IsNullOrEmpty(valorCompra.ToString()) || string.IsNullOrEmpty(valorVenta.ToString()))
                    
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
                        await a.InsertarActivo("acciones", a); 
                    }

                    if (txt_tipo.Text == "Monedas")
                    {
                        Monedas m = Monedas.CrearMoneda(titulo, valorCompra, valorVenta);
                        await m.InsertarActivo("monedas", m);
                    }
                                    
                    txt_Titulo.Clear(); // Limpiar los campos después de agregar
                    Txt_ValorCompra.Clear();
                    txt_ValorVenta.Clear();
                }

            }
            catch (Exception ex)
            {
                string form = "Admin, Alta de acciones";

            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

