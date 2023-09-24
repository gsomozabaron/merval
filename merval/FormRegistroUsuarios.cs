using Microsoft.Win32;
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
    public partial class FormRegistroUsuarios : Form
    {
        public FormRegistroUsuarios()
        {
            InitializeComponent();

        }

        private void FormRegistroUsuarios_Load(object sender, EventArgs e)
        {

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            string nombre = this.txtNombre.Text;
            string apellido = this.txtApellido.Text;
            string nombreUsuario = this.txtNombreUsuario.Text;
            string password = this.txtPassword.Text;
            bool esComisionista = this.checkBox1.Checked;
            string passCheck = this.txtPasswordCheck.Text;

            if (password != passCheck)
            {
                MessageBox.Show("Las contraseñas no coinciden. Por favor, vuelva a ingresarlas.");
                return;
            }

            if (formLogin.dictUsuarioPassword.ContainsKey(nombreUsuario))
            {
                MessageBox.Show("El nombre de usuario ya existe. Por favor, elija otro.");
                return;
            }

            formLogin.dictUsuarioPassword.Add(nombreUsuario, password);

            string titulo = "Registro exitoso.";
            string mensaje = "Ahora puede iniciar sesión.";

            VentanaEmergente ve = new VentanaEmergente(titulo, mensaje);
            ve.ShowDialog();

            this.Close();

            formLogin loginForm = new formLogin();
            loginForm.Show();








        }
    }
}
