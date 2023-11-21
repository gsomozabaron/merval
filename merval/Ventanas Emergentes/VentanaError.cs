namespace merval
{
    /// <summary>
    /// ventana emergente con fondo rojo y titulo ERROR, recibe 1 string
    /// </summary>
    public partial class VentanaError : Form
    {
        string mensaje;

        public VentanaError(string mensaje)
        {
            InitializeComponent();
            this.lbl_MensajeError.Text = mensaje;
        }

        private void Btn_Aceptar_Click_1(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
