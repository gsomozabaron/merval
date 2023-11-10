using merval.DB;
using merval.entidades;
using merval.Serializadores;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace merval
{
    public partial class FormRegistroUsuarios : Form
    {
        List<Usuario> listaDeUsuarios = DatabaseSQL.GetUsuarios();

        private string alta;

        public FormRegistroUsuarios(string alta)
        {
            InitializeComponent();
            this.alta = alta;
        }

        private void FormRegistroUsuarios_Load(object sender, EventArgs e)
        {
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
       
        private void btnAceptar_Click(object sender, EventArgs e)
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

            Usuario nuevoUsuario = Usuario.CrearUsuario(nombre, Dni, nombreUsuario, password, tipoDeUsuario, saldo, apellido);

            DatabaseSQL.InsertarUsuario(nuevoUsuario);
                        
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
            foreach (Usuario u in listaDeUsuarios)
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
