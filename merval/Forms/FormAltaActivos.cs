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
    public partial class FormAltaActivos : Form
    {
        string formName = "Admin, alta acciones";
        string mensaje = string.Empty;

        public FormAltaActivos(string tipoActivo)
        {
            InitializeComponent();
            txt_tipo.Text = tipoActivo;
        }

        private static decimal ParsearValores(string valor)
        {
            return decimal.Parse(valor);
        }
      
        
        //aceptar da de alta nuevos activos
        private async void btn_aceptar_Click(object sender, EventArgs e)
        {      
            try
            {
                string titulo = txt_Titulo.Text;
                List <Acciones> listaAccionesGral = await Acciones.CrearListaAcciones();
                List<Monedas>listaMonedasGral = await Monedas.CrearListaMonedas();

                
                decimal valorCompra = ParsearValores(Txt_ValorCompra.Text);
                decimal valorVenta = ParsearValores(txt_ValorVenta.Text);


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
                    await CrearActivo(txt_tipo.Text, titulo, valorCompra, valorVenta);
                                    
                    txt_Titulo.Clear(); // Limpiar los campos después de agregar
                    Txt_ValorCompra.Clear();
                    txt_ValorVenta.Clear();
                }

            }
            catch (Exception ex)
            {
                string mensaje ="";
                string form = "Admin, Alta de acciones";
                ManejadorDeExcepciones.CrearErrorLog(form, ex, mensaje);
            }
        }


        //crear el nuevo activo
        private async Task CrearActivo(string tipo, string titulo, decimal valorCompra, decimal valorVenta)
        {
            Activos activos = new Activos(titulo, valorCompra, valorVenta,0);
            await activos.InsertarActivo(tipo,activos);
        }
        
        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

