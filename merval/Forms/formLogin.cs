using merval.DB;

namespace merval
{

    public partial class formLogin : Form
    {
        int Contador = 0;   /// inicio un contador para el auto login
        private static UsuarioSQL usuarioActual = new UsuarioSQL();

        Func<string, string, bool> delegado = new Func<string, string, bool>(Coinciden);

        public formLogin()
        {
            InitializeComponent();
        }

        /// <summary>
        /// trae la lista de usuarios desde la base de datos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void formLogin_Load(object sender, EventArgs e)
        {

        }


        /// <summary>
        /// chequea si dos valores son iguales
        /// </summary>
        /// <param name="password"></param>
        /// <param name="passConfirm"></param>
        /// <returns></returns>
        private static bool Coinciden(string password, string passConfirm)
        {
            return (password == passConfirm);
        }


        /// <summary>
        /// loguea al usuario y lanza la pantalla de usuario normal o la de administrador
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnAceptar_Click(object sender, EventArgs e)
        {
            List<UsuarioSQL> listadoDeUsuarios = await UsuarioSQL.CrearListaDeUsuarios();
            string nombreUsuario = this.txtUsuario.Text;
            string password = this.txtPassword.Text;
            string mensaje;
            string titulo;
            bool estaRegistrado = false;


            if (listadoDeUsuarios != null)// no rompe si no carga la lista
            {
                foreach (UsuarioSQL u in listadoDeUsuarios)///buscamos por nombre de usuario en listado de usuarios
                {
                    ///si encontramos el nombre...
                    if (delegado(u.NombreUsuario, nombreUsuario))//(u.NombreUsuario == usuario)
                    {
                        ///buscamos el pass, si coincide..
                        if (delegado(u.Pass, password)) //uso del delegado func asociado a coinciden
                        {
                            usuarioActual = u;
                            titulo = "Bienvenido";  ///titulo para la ventana emergente 
                            mensaje = $"{u.Nombre}";    ///mensaje de bienvenida con el nombre del usuario
                            estaRegistrado = true;  ///pasamos a verdadero para entrar a la linea 93

                            Vm.VentanaMensaje(titulo, mensaje);//ventana emergente
                            break;
                        }

                        //si coincide nombre usuario pero el pass no...
                        else
                        {
                            mensaje = "password incorrecto";
                            Vm.VentanaMensajeError(mensaje);
                            break;
                        }
                    }
                }
            }
            ///si no encuentra ningun nombre de usuario que coincida
            if (estaRegistrado == false)
            {
                mensaje = "Login Error \nusuario no encontrado";
                Vm.VentanaMensajeError(mensaje);
                LimpiarCampos();    // Limpiamos los campos
            }

            ///coinciden usuario y pass..

            else
            {
                IrAlFormulario();
            }
        }


        /// <summary>
        /// lanza el formulario de usuario o el de admin segun el tipo de usuario
        /// </summary>
        private void IrAlFormulario()
        {
            if (usuarioActual.TipoDeUsuario == Tipo.normal) //usuario normal
            {
                FormPrincipal fp = new FormPrincipal(usuarioActual);//ir al formulario principal
                fp.Show();
                this.Hide();
            }

            if (usuarioActual.TipoDeUsuario == Tipo.Admin)
            {
                FormAdmin fa = new FormAdmin();// ir al formulario de administradores
                fa.Show();
                this.Hide();
            }
        }


        /// <summary>
        /// lanza el formulario de registro
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRegistrarse_Click(object sender, EventArgs e)
        {
            string alta = "normal";
            FormRegistroUsuarios altaUsuarios = new FormRegistroUsuarios(alta);
            altaUsuarios.ShowDialog();
        }


        #region autocompletar menu login Hardcode
        private void btn_autocompletar_Click(object sender, EventArgs e)
        {
            switch (Contador)
            {
                case 0:
                    this.txtUsuario.Text = "admin";
                    this.txtPassword.Text = "admin";
                    Contador += 1;
                    break;
                case 1:
                    Contador += 1;
                    this.txtUsuario.Text = "gsomoza";
                    this.txtPassword.Text = "gpass";
                    break;
                case 2:
                    Contador += 1;
                    this.txtUsuario.Text = "gala";
                    this.txtPassword.Text = "perrito";
                    break;
                default:
                    Contador = 0;
                    this.txtUsuario.Text = "ivi";
                    this.txtPassword.Text = "coco";
                    break;
            }
        }
        #endregion


        /// <summary>
        /// limpia los campos de usuario y passs despues de una carga NO exitosa
        /// </summary>
        private void LimpiarCampos()
        {
            txtUsuario.Text = string.Empty;
            txtPassword.Text = string.Empty;
        }


        /// <summary>
        /// abandona el programa
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

