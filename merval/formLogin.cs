using System.Security.Cryptography.X509Certificates;

namespace merval
{
    public partial class formLogin : Form
    {
        public static Dictionary<string, string> dictUsuarioPassword = new Dictionary<string, string>();

        public static void agregarUsuario(string nombre, string password)
        {
            dictUsuarioPassword.Add(nombre, password );
        }

        public formLogin()
        {
            InitializeComponent();
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
                    VentanaEmergente ve = new VentanaEmergente("log in exitoso", $"Bienvenido, {usuario}");
                    
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
    }
}