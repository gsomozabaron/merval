using Entidades;
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
    public partial class FormSaldo : Form
    {
        private Usuario usuarioActual;
        private List<Usuario> listaUsuarios;

        public FormSaldo(Usuario usuario)
        {
            InitializeComponent();
            usuarioActual = usuario;
            listaUsuarios = Serializadora.LeerListadoUsuarios();
        }


        private void btn_CargarSaldo_Click(object sender, EventArgs e)
        {
            //cambiar el punto por coma, no se por que si pong 154.5 lo toma como 1545
            string puntoPorComa = txt_MontoAumentar.Text.Replace('.', ',');

            if (float.TryParse(puntoPorComa, out float montoAumentar)&& (montoAumentar > 0))
            {
                VentanaConfirmar vc = new VentanaConfirmar("confirmar Transferencia", "Esta Seguro?");

                if (vc.ShowDialog() == DialogResult.OK)
                {
                    usuarioActual.Saldo += montoAumentar;
                    lbl_NuevoSaldo.Text = $"${usuarioActual.Saldo.ToString()}";
                    lbl_NuevoSaldoTag.Text = "Nuevo saldo";

                    Serializadora.ActualizarUsuario(usuarioActual, listaUsuarios);
                    txt_MontoAumentar.Clear();
                }
                else
                {
                    txt_MontoAumentar.Clear();
                    VentanaEmergente ve = new VentanaEmergente("Operacion", "Cancelada");
                    ve.ShowDialog();
                }
            }
            else
            {
                txt_MontoAumentar.Clear();
                Ventana_error ve = new Ventana_error("Debe ingresar solo numeros");
                ve.ShowDialog();
            }
        }

        private void btn_Salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormSaldo_Load(object sender, EventArgs e)
        {
            lbl_NuevoSaldo.Text = $"${usuarioActual.Saldo.ToString()}";
            lbl_NuevoSaldoTag.Text = "Saldo Actual";
        }

        private void btn_extraer_Click(object sender, EventArgs e)
        {
            //cambiar el punto por coma, no se por que si pong 154.5 lo toma como 1545
            string puntoPorComa = txt_montoExtraer.Text.Replace('.', ',');

            if (float.TryParse(puntoPorComa, out float montoExtraer)&& (montoExtraer > 0))
            {
                if (usuarioActual.Saldo >= montoExtraer)
                {
                    VentanaConfirmar vc = new VentanaConfirmar("confirmar Extraccion", "Esta Seguro?");

                    if (vc.ShowDialog() == DialogResult.OK)
                    {
                        usuarioActual.Saldo -= montoExtraer;
                        lbl_NuevoSaldo.Text = $"${usuarioActual.Saldo.ToString()}";
                        lbl_NuevoSaldoTag.Text = "Nuevo saldo";
                        txt_montoExtraer.Clear();
                        Serializadora.ActualizarUsuario(usuarioActual, listaUsuarios);
                    }
                    else
                    {
                        VentanaEmergente ve = new VentanaEmergente("Operacion", "Cancelada");
                        ve.ShowDialog();
                        txt_montoExtraer.Clear();
                    }
                }
                else
                {
                    Ventana_error ve = new Ventana_error("AJA! PILLIN\nNO TENES TANTA GUITA");
                    ve.ShowDialog();
                    txt_montoExtraer.Clear();
                }
            }
            else
            {
                Ventana_error ve = new Ventana_error("solo numeros mayores a 0");
                ve.ShowDialog();
                txt_montoExtraer.Clear();
            }
        }
    }
}
