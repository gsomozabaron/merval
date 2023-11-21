namespace merval
{
    /// <summary>
    /// ventana con fondo amarillo para pedir confirmaciones, recibe 2 strings, titulo y mensaje
    /// </summary>
    public partial class VentanaConfirmar : Form
    {
        string titulo;
        string mensaje;

        public VentanaConfirmar(string titulo, string mensaje)
        {
            InitializeComponent();
            this.lbl_Titulo.Text = titulo;
            this.lbl_Mensaje.Text = mensaje;
        }

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void VentanaConfirmar_Load(object sender, EventArgs e)
        {
        }

        private void btn_Aceptar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }


    }
}
