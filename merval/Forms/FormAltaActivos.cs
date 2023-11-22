using merval.Excepciones;


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
                List<Acciones> listaAccionesGral = await Acciones.CrearListaAcciones();
                List<Monedas> listaMonedasGral = await Monedas.CrearListaMonedas();

                decimal valorCompra = ParsearValores(Txt_ValorCompra.Text); //.Replace('.', ','));
                decimal valorVenta = ParsearValores(txt_ValorVenta.Text);   //.Replace('.', ','));

                if (valorCompra < 1 || valorVenta < 1)
                {
                    throw new ExcepcionPersonalizada("no admite valores negativos");
                }

                if (string.IsNullOrEmpty(titulo))
                {
                    mensaje = "Tanto el titulo como los precios \nson obligatorios.";
                    throw new ExcepcionPersonalizada(mensaje);
                }

                if (valorCompra < valorVenta)
                {
                    mensaje = "Te van a rajar a la mierda no puede ser mayor el valor de compra al de venta";
                    throw new ExcepcionPersonalizada(mensaje);
                }

                if ((listaAccionesGral.Any(a => a.Nombre == titulo) && txt_tipo.Text == "Acciones") ||
                        (listaMonedasGral.Any(a => a.Nombre == titulo) && txt_tipo.Text == "Monedas"))
                {
                    mensaje = ("El titulo ya se encuentra dado de alta");
                    throw new ExcepcionPersonalizada(mensaje);
                }

                else    //crear activos!
                {
                    await CrearActivo(txt_tipo.Text, titulo, valorCompra, valorVenta);

                    txt_Titulo.Clear(); // Limpiar los campos después de agregar
                    Txt_ValorCompra.Clear();
                    txt_ValorVenta.Clear();
                }

            }
            catch (ExcepcionPersonalizada ex)
            {
                Vm.VentanaMensajeError(ex.Message);
            }
            catch (OverflowException)
            {
                Vm.VentanaMensajeError("cantidades fuera de rango ");
            }
            catch (FormatException)
            {
                Vm.VentanaMensajeError("Los precios \nson obligatorios.");
            }
            catch (Exception ex)
            {
                mensaje = "inesperado";
                ReporteExcepciones.CrearErrorLog(formName, ex, mensaje);
            }
        }



        //crear el nuevo activo
        private async Task CrearActivo(string tipo, string titulo, decimal valorCompra, decimal valorVenta)
        {
            Activos activos = new Activos(titulo, valorCompra, valorVenta, 0);
            await activos.InsertarActivo(tipo, activos);
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

