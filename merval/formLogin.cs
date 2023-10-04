using Entidades;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;

namespace merval
{
    public partial class formLogin : Form
    {
        
        /// inicio un contador para el auto login
        int Contador = 0;

        /// dicionario de usuarios para el login 
        public static Dictionary<string, string> dictUsuarioPassword = new Dictionary<string, string>();
        public static List<Usuario> listadoDeUsuarios = new List<Usuario>();
        public static Usuario usuarioActual = new Usuario();


public formLogin()
        {
            InitializeComponent();
            Hardcodeo.cargarListayDicc(dictUsuarioPassword, listadoDeUsuarios);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }



        private void btnAceptar_Click(object sender, EventArgs e)
        {
            string usuario = this.txtUsuario.Text;
            string password = this.txtPassword.Text;

            if (dictUsuarioPassword.ContainsKey(usuario))
            {
                string passEnDict = dictUsuarioPassword[usuario];

                if (password == passEnDict)
                {
                    // Inicio de sesión exitoso
                    ////////////////////obtener el usuario aca///////////////////////////
                    ///cambiar "Bienvenido, {usuario} a "Bienvenido, {usuarioActual.nombre}
                    foreach (Usuario usuariologin in listadoDeUsuarios)
                    {
                        if (usuariologin.NombreUsuario == usuario)
                        {
                            usuarioActual = usuariologin;
                            break;
                        }
                    }

                    VentanaEmergente ve = new VentanaEmergente
                        ("login exitoso", $"Bienvenido, {usuarioActual.Nombre}");

                    ve.ShowDialog();

                    if (ve.DialogResult == DialogResult.OK)
                    {
                        FormPrincipal MenuPrincipal = new FormPrincipal();
                        MenuPrincipal.Show();
                        this.Hide();
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

        private void formPrincipal_Load(object sender, EventArgs e)
        {
        }

        private void btnRegistrarse_Click(object sender, EventArgs e)
        {
            FormRegistroUsuarios altaUsuarios = new FormRegistroUsuarios();
            altaUsuarios.Show();
            Hide();
        }

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
    }
}