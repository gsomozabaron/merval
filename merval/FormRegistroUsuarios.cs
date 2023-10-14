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
        List<Usuario> listaDeUsuarios = Serializadora.LeerListadoUsuarios();

        public FormRegistroUsuarios()
        {
            InitializeComponent();
        }

        private void FormRegistroUsuarios_Load(object sender, EventArgs e)
        {
            chk_comisionista.Visible = false;
            btn_agregarUsuario.Visible = false;

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
            long saldo = 0;
            string apellido = this.txt_Apellido.Text;
            List<Acciones> listadoDeAccionesPropias = new List<Acciones>();
            List<Clientes> listaDeClientes = new List<Clientes>();


            string titulo = "Registro exitoso.";
            string mensaje = "Usuario dado de alta";
            VentanaEmergente ve = new VentanaEmergente(titulo, mensaje);

            if (password != passCheck)
            {
                MessageBox.Show("Las contraseñas no coinciden. Por favor, vuelva a ingresarlas.");
                this.txt_Pass.Clear();
                this.txt_Pass.Clear();
                return;
            }

            foreach (Usuario u in listaDeUsuarios)
            {
                if (u.NombreUsuario == nombreUsuario)
                {
                    this.txt_NombreUsuario.Clear();
                    VentanaEmergente v = new VentanaEmergente("El nombre de usuario ya existe.", "Por favor, elija otro.");
                    v.ShowDialog();
                    return;
                }
            }

            if (esComisionista == true)
            {
                //tipoDeUsuario = Tipo.Comisionista;
                //Comisionista nuevoUsuario = Comisionista.CrearComisionista(nombre, Dni, nombreUsuario, password, tipoDeUsuario, listadoDeAccionesPropias, listaDeClientes);
                //listaDeUsuarios.Add(nuevoUsuario);

                //Serializadora.GuardarListadoUsuarios(listaDeUsuarios) ;
                //ve.ShowDialog();
            }
            else
            {
                tipoDeUsuario = Tipo.normal;
                Usuario nuevoUsuario = Usuario.CrearUsuario(nombre, Dni, nombreUsuario, password, tipoDeUsuario, listadoDeAccionesPropias, saldo, apellido);
                listaDeUsuarios.Add(nuevoUsuario);

                Serializadora.GuardarListadoUsuarios(listaDeUsuarios);
                ve.ShowDialog();
            }
            this.Close();
            #endregion
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
