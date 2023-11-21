using merval.DB;
using merval.Excepciones;
using System.Windows.Forms;

namespace merval
{
    public partial class FormSaldo : Form
    {
        private string mensaje;
        private string formName = "FormSaldo";
        private UsuarioSQL usuarioActual;
        private List<UsuarioSQL> listaUsuarios;


        public FormSaldo(UsuarioSQL usuario)
        {
            InitializeComponent();
            usuarioActual = usuario;
        }


        private void btn_CargarSaldo_Click(object sender, EventArgs e)
        {
            //cambiar el punto por coma, no se por que si pongo 154.5 lo toma como 1545
            string puntoPorComa = txt_MontoAumentar.Text.Replace('.', ',');
            try
            {
                if (decimal.TryParse(puntoPorComa, out decimal montoAumentar) && (montoAumentar > 0))
                {
                    if (Vm.VentanaMensajeConfirmar("confirmar Transferencia", "Esta Seguro?") == DialogResult.OK)
                    {
                        ///sumar el monto agregado al saldo
                        usuarioActual.Saldo += montoAumentar;
                        lbl_NuevoSaldo.Text = $"${usuarioActual.Saldo}";
                        lbl_NuevoSaldoTag.Text = "Nuevo saldo";


                        usuarioActual.ModificarSaldo(usuarioActual);
                        txt_MontoAumentar.Clear();///limpia la casilla 
                    }
                    else
                    {
                        ///si el resultado de la ventana confirmar es == cancelar
                        txt_MontoAumentar.Clear();///limpia la casilla 
                        Vm.VentanaMensaje("Operacion", "Cancelada");
                    }
                }
                else
                {
                    ///en caso que se ingrese letras o vacio
                    txt_MontoAumentar.Clear();
                    Vm.VentanaMensajeError("Debe ingresar solo numeros");
                }
            }
            catch (Exception ex)
            {
                mensaje = "inesperado";
                Vm.VentanaMensajeError(mensaje);
                ReporteExcepciones.CrearErrorLog(formName, ex, mensaje);
            }
        }

        private void btn_Salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormSaldo_Load(object sender, EventArgs e)
        {
            lbl_NuevoSaldo.Text = $"${usuarioActual.Saldo}";
            lbl_NuevoSaldoTag.Text = "Saldo Actual";
        }

        private void btn_extraer_Click(object sender, EventArgs e)
        {
            //cambiar el punto por coma, no se por que si pong 154.5 lo toma como 1545
            string puntoPorComa = txt_montoExtraer.Text.Replace('.', ',');
            try
            {
                if (decimal.TryParse(puntoPorComa, out decimal montoExtraer) && (montoExtraer > 0))
                {
                    if (usuarioActual.Saldo >= montoExtraer)///cheq si saldo es mayor al monto a extraer
                    {
                        if (Vm.VentanaMensajeConfirmar("confirmar Extraccion", "Esta Seguro?") == DialogResult.OK)
                        {
                            usuarioActual.Saldo -= montoExtraer;
                            lbl_NuevoSaldo.Text = $"${usuarioActual.Saldo}";
                            lbl_NuevoSaldoTag.Text = "Nuevo saldo";
                            txt_montoExtraer.Clear();

                            usuarioActual.ModificarSaldo(usuarioActual);
                        }
                        else
                        {
                            ///si cancelamos la extraccion
                            Vm.VentanaMensaje("Operacion", "Cancelada");
                            txt_montoExtraer.Clear();
                        }
                    }
                    else
                    {
                        ///si el monto a extraer es mayor que el saldo...
                        Vm.VentanaMensajeError("AJA! PILLIN\nNO TENES TANTA GUITA");
                        txt_montoExtraer.Clear();
                    }
                }
                else
                {
                    ///si se ingresan letras o simbolos o falla el parse_float
                    Vm.VentanaMensajeError("Solo numeros mayores a 0");
                    txt_montoExtraer.Clear();
                }
            }
            catch (Exception ex)
            {
                mensaje = "inesperado";
                Vm.VentanaMensajeError(mensaje);
                ReporteExcepciones.CrearErrorLog(formName, ex, mensaje);
            }
        }
    }
}
