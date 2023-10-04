using Entidades;
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
        #region formulario alta de usuarios
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            string nombre = this.txt_Nombre.Text;
            string Dni = this.txt_Dni.Text;
            string nombreUsuario = this.txt_NombreUsuario.Text;
            string password = this.txt_Pass.Text;
            bool esComisionista = this.chk_comisionista.Checked;
            string passCheck = this.txt_PassCheck.Text;
            
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
            
            if (esComisionista)
            {
                formLogin.listadoDeUsuarios.Add(Comisionista.CrearComisionista
                    (nombre, Dni, nombreUsuario, password));
            }
            else
            {
                formLogin.listadoDeUsuarios.Add(Usuario.CrearUsuario
                    (nombre, Dni, nombreUsuario, password));
            }
            

            string titulo = "Registro exitoso.";
            string mensaje = "Ahora puede iniciar sesión.";
            VentanaEmergente ve = new VentanaEmergente(titulo, mensaje);
            ve.ShowDialog();
            this.Close();
            #endregion

        formLogin loginForm = new formLogin();
        loginForm.Show();
        }
    }
}
