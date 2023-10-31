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
    public partial class FormAltaAcciones : Form
    {

        private List<Acciones> listaAccionesGral = Serializadora.LeerListaAcciones();
        private List<Monedas> listaMonedasGral = Serializadora.LeerListaMonedas();
        

        public FormAltaAcciones(string tipoActivo)
        {
            InitializeComponent();
            txt_tipo.Text = tipoActivo;
        }
        private void btn_aceptar_Click(object sender, EventArgs e)
        {
            string titulo = txt_Titulo.Text;

            try
            {
                decimal valorCompra = decimal.Parse(Txt_ValorCompra.Text);
                decimal valorVenta = decimal.Parse(txt_ValorVenta.Text);
                if (titulo == "" || valorCompra.ToString() == "" || valorVenta.ToString() == "")
                {
                    Vm.VentanaMensajeError("Tanto el titulo como los precios \nson obligatorios.");
                    return;
                }

                if ((listaAccionesGral.Any(a => a.Nombre == titulo) && txt_tipo.Text == "Acciones") || 
                     (listaMonedasGral.Any(a => a.Nombre == titulo) && txt_tipo.Text == "Monedas"))
                {
                    Vm.VentanaMensajeError("El titulo ya se encuentra dado de alta");
                }
                else
                {
                    try
                    {
                        if (txt_tipo.Text == "Acciones")//lista acciones
                        {
                            int cantidad = 0;
                            Acciones.CrearAccion(titulo, valorCompra, valorVenta, cantidad, listaAccionesGral);
                        }
                        
                        if (txt_tipo.Text == "Monedas")//lista monedas
                        {
                            Monedas.CrearMoneda(titulo, valorCompra, valorVenta, listaMonedasGral);
                        }
                        
                        Vm.VentanaMensaje("Exito", "Titulo ingresado correctamente.");

                        txt_Titulo.Clear(); // Limpiar los campos después de agregar
                        Txt_ValorCompra.Clear();
                        txt_ValorVenta.Clear();
                    }
                    catch (Exception)
                    {
                        Vm.VentanaMensajeError("No se pudo grabar el Archivo");                       
                    }
                }
            }
            catch (Exception)
            {
                Vm.VentanaMensajeError("los precios ingresados no son validos.");
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

