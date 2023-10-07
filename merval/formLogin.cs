using Entidades;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;

namespace merval
{
    public partial class formLogin : Form
    {
        #region inicializadores hardcode
        /// inicio un contador para el auto login
        int Contador = 0;

        /// dicionario de usuarios para el login 
        private static Dictionary<string, string> dictUsuarioPassword = new Dictionary<string, string>();
        private static List<Usuario> listadoDeUsuarios = new List<Usuario>();
        private static Usuario usuarioActual = new Usuario();

        #endregion
        ///////////////////////////////////////////////////////////////
        /// <summary>
        /// para llamar desde cualquier form 
        /// Usuario usuario = formLogin.UsuarioActual;
        /// List<Usuario> listaDeUsuarios = formLogin.ListadoDeUsuarios;
        /// </summary>
        public static Usuario UsuarioActual
        {
            get => usuarioActual;
        }
        public static List<Usuario> ListadoDeUsuarios
        {
            get => listadoDeUsuarios;
        }
        public static Dictionary<string, string> DictUsuarioPassword
        {
            get => dictUsuarioPassword;
        }
        //////////////////////////////////////////////////////////////       


        public formLogin()
        {
            InitializeComponent();
            if (dictUsuarioPassword.Count == 0)
            {
                Hardcodeo.cargarListayDicc(dictUsuarioPassword, listadoDeUsuarios);
            }
        }
        #region boton salir
        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion

        #region Boton aceptar login
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            string usuario = this.txtUsuario.Text;
            string password = this.txtPassword.Text;

            if (dictUsuarioPassword.ContainsKey(usuario))
            {
                string passEnDict = dictUsuarioPassword[usuario];

                if (password == passEnDict)
                {
                    /////////////obtener el usuario aca///////////////////////////

                    foreach (Usuario usuariologin in listadoDeUsuarios)
                    {
                        if (usuariologin.NombreUsuario == usuario)
                        {
                            usuarioActual = usuariologin;
                            break;
                        }
                    }
                    VentanaEmergente ve = new VentanaEmergente("login exitoso", $"Bienvenido, {usuarioActual.Nombre}");
                    ve.ShowDialog();

                    if (ve.DialogResult == DialogResult.OK)
                    {
                        if (usuarioActual.TipoDeUsuario == Tipo.Admin)
                        {
                            FormAdmin formadmin = new FormAdmin(usuarioActual);
                            this.Hide();
                            formadmin.Show();
                        }
                        else
                        {
                            FormPrincipal MenuPrincipal = new FormPrincipal();
                            MenuPrincipal.Show();
                            this.Hide();
                        }
                    }
                }
                else
                {
                    this.txtUsuario.Text = string.Empty;
                    this.txtPassword.Text = string.Empty; // Limpia los campos
                    VentanaEmergente ve = new VentanaEmergente("Error", "Contraseña incorrecta");
                    ve.ShowDialog();
                }
            }
            else
            {
                this.txtUsuario.Text = string.Empty;
                this.txtPassword.Text = string.Empty; // Limpia los campos
                VentanaEmergente ve = new VentanaEmergente("Error", "Usuario no encontrado");
                ve.ShowDialog();
            }
        }
        #endregion


        private void formPrincipal_Load(object sender, EventArgs e)
        {
        }
        
        private void btnRegistrarse_Click(object sender, EventArgs e)
        {
            FormRegistroUsuarios altaUsuarios = new FormRegistroUsuarios();
            altaUsuarios.Show();
            Hide();
        }
        #region autocompletar menu login
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
                default:
                    Contador = 0;
                    this.txtUsuario.Text = "fmario";
                    this.txtPassword.Text = "mariopass";
                    break;
            }
        }
        #endregion
    }
}