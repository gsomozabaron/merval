using merval.Serializadores;

namespace merval.Ventanas_Emergentes
{
    public partial class VentanaRecibo : Form
    {
        private string recibo;

        public VentanaRecibo(string recibo)
        {
            InitializeComponent();
            this.label1.Text = recibo;
            this.recibo = recibo;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_guardarXml_Click(object sender, EventArgs e)
        {
            try
            {
                Serializadora.GuardarReciboDeCompra(recibo);
                Vm.VentanaMensaje("Exito", "Recibo guardado");
            }
            catch (Exception)
            {
                Vm.VentanaMensajeError("No se pudo\nguardar el recibo");
            }
            this.Close();
        }
    }
}
