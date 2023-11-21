using merval.DB;

namespace merval
{
    public partial class FormRegistroUsuarios : Form
    {

        private List<UsuarioSQL> listaUsuarios = new List<UsuarioSQL>(); // Cambiado para ser un campo de la clase
        //private Usuario usuario = new Usuario(); // Agregado para ser un campo de la clase


        private string alta;    //este alta es para dejar ver los botones de usuarios especiales en caso que el usuario sea administrador

        public FormRegistroUsuarios(string alta)
        {
            InitializeComponent();
            this.alta = alta;
        }

        /// <summary>
        /// aca de usa el "alta" para poder reutilizar el menu de "registarse" o modificacion de datos
        /// solo un admin puede registrar otro admin, en caso de ser usuario normal los cheq de "es admin" estan invisibles
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void FormRegistroUsuarios_Load(object sender, EventArgs e)
        {
            listaUsuarios = await UsuarioSQL.CrearListaDeUsuarios();

            if (alta == "admin")
            {
                chk_esAdmin.Visible = true;
                chk_comisionista.Visible = true;
            }
            else
            {
                chk_esAdmin.Visible = false;
                chk_comisionista.Visible = false;
            }
        }

        private async void btnAceptar_Click(object sender, EventArgs e)
        {
            string nombre = this.txt_Nombre.Text;
            string Dni = this.txt_Dni.Text;
            string nombreUsuario = this.txt_NombreUsuario.Text;
            string password = this.txt_Pass.Text;
            bool esAdmin = this.chk_esAdmin.Checked;
            string passCheck = this.txt_PassCheck.Text;
            Tipo tipoDeUsuario;/// = Tipo.normal;
            long saldo = 0;
            string apellido = this.txt_Apellido.Text;

            /// chequeo si se completaron todos los datos
            if (string.IsNullOrEmpty(nombre) ||
                string.IsNullOrEmpty(Dni) ||
                string.IsNullOrEmpty(nombreUsuario) ||
                string.IsNullOrEmpty(password) ||
                string.IsNullOrEmpty(apellido))
            {
                Vm.VentanaMensajeError("Campos incompletos");
                return;
            }

            ///****************************************************************************///
            /// chequeo si el nombre de usuario ya está en uso
            /// validación de número de DNI que sean 7 u 8 numeros 
            /// validacion de coincidencia de password y reigreso de password
            if (ValidarNombreEnUso(nombreUsuario) || ValidarPass(password, passCheck) || !EsDniValido(Dni))
            {
                return;
            }

            if (esAdmin == false)
            {
                tipoDeUsuario = Tipo.normal;
            }
            else
            {
                tipoDeUsuario = Tipo.Admin;
            }

            UsuarioSQL nuevoUsuario = UsuarioSQL.CrearUsuario(nombre, Dni, nombreUsuario, password, tipoDeUsuario, saldo, apellido);

            await nuevoUsuario.AgregarUsuario();

            this.Close();
        }

        private bool EsDniValido(string dni)
        {
            bool dniValido = System.Text.RegularExpressions.Regex.IsMatch(dni, @"^\d{7,8}$");
            if (!dniValido)
            {
                Vm.VentanaMensajeError("Nro de DNI inválido.\nIngrese un número de 6 o 7 dígitos.");
                txt_Dni.Clear(); // limpiamos la casilla
            }
            return dniValido;
        }

        private bool ValidarPass(string password, string passCheck)
        {
            bool noCoinciden = false;
            if (password != passCheck)
            {
                Vm.VentanaMensajeError("Las contraseñas no coinciden.\nPor favor, vuelva a ingresarlas.");
                this.txt_Pass.Clear();
                this.txt_PassCheck.Clear();
                noCoinciden = true;
            }
            return noCoinciden;
        }

        private bool ValidarNombreEnUso(string nombreUsuario)
        {
            bool estaDuplicado = false;
            foreach (UsuarioSQL u in listaUsuarios)
            {
                if (u.NombreUsuario == nombreUsuario)
                {
                    this.txt_NombreUsuario.Clear();
                    Vm.VentanaMensaje("El nombre de usuario ya existe.", "Por favor, elija otro.");
                    estaDuplicado = true;
                    break;
                }
            }
            return estaDuplicado;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
