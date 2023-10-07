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
        Dictionary<string, string> dictUsuarioPassword = formLogin.DictUsuarioPassword;
        List<Usuario> listaDeUsuarios = formLogin.ListadoDeUsuarios;

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
            Tipo tipoDeUsuario = Tipo.normal;
            List<Acciones> listadoDeAccionesPropias = new List<Acciones>();
            List<Clientes> listaDeClientes = new List<Clientes>();


            if (password != passCheck)
            {
                MessageBox.Show("Las contraseñas no coinciden. Por favor, vuelva a ingresarlas.");
                return;
            }
            
            if (dictUsuarioPassword.ContainsKey(nombreUsuario))
            {
                MessageBox.Show("El nombre de usuario ya existe. Por favor, elija otro.");
                return;
            }

            dictUsuarioPassword.Add(nombreUsuario, password);

            if (esComisionista)
            {
                tipoDeUsuario = Tipo.Comisionista;
                Comisionista nuevoUsuario = new Comisionista();
                nuevoUsuario.CrearComisionista(nombre, Dni, nombreUsuario, password, tipoDeUsuario, listadoDeAccionesPropias, listaDeClientes);
                listaDeUsuarios.Add(nuevoUsuario);
            }
            else
            {
                Usuario nuevoUsuario = new Usuario();
                nuevoUsuario.CrearUsuario(nombre, Dni, nombreUsuario, password, tipoDeUsuario, listadoDeAccionesPropias);
                listaDeUsuarios.Add(nuevoUsuario);
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
