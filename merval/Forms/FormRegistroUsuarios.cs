﻿using merval.DB;
using merval.entidades;
using merval.Serializadores;
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

        private bool EsDniValido(string dni)
        {
            // Verificar si el DNI tiene 7 u 8 dígitos numéricos
            return System.Text.RegularExpressions.Regex.IsMatch(dni, @"^\d{7,8}$");
        }

        #region formulario alta de usuarios
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

            ///List<Activos> ListadoDeActivosPropios = new List<Activos>();
            
            #region validar DNI
            ///****************************************************************************///
            /// validación de número de DNI
            if (!EsDniValido(Dni))
            {
                Vm.VentanaMensajeError("Nro de DNI inválido.\nIngrese un número de 6 o 7 dígitos.");
                txt_Dni.Clear(); // limpiamos la casilla
                return;
            }
            #endregion

            #region validar contraseña
            ///****************************************************************************///
            /// chequeo de coincidencia de contraseña de las dos casillas
            if (password != passCheck)
            {
                Vm.VentanaMensajeError("Las contraseñas no coinciden.\nPor favor, vuelva a ingresarlas.");
                this.txt_Pass.Clear();
                this.txt_Pass.Clear();
                return;
            }
            #endregion

            #region validar nombre de usuario en uso
            ///****************************************************************************///
            /// chequeo si el nombre de usuario ya está en uso
            foreach (Usuario u in listaDeUsuarios)
            {
                if (u.NombreUsuario == nombreUsuario)
                {
                    this.txt_NombreUsuario.Clear();
                    Vm.VentanaMensaje("El nombre de usuario ya existe.", "Por favor, elija otro.");
                    return;
                }
            }
            #endregion

            #region crear usuarios
            ///****************************************************************************///
            /// crear usuarios
            
            if (esAdmin == false)
            {
                tipoDeUsuario = Tipo.normal;
            }
            else
            {
                tipoDeUsuario = Tipo.Admin;
            }

            Usuario nuevoUsuario = Usuario.CrearUsuario(nombre, Dni, nombreUsuario, password, tipoDeUsuario, saldo, apellido);

            /////////////codigo viejo XML//////////////////////////////////////////
            //listaDeUsuarios.Add(nuevoUsuario);
            //Serializadora.GuardarListadoUsuarios(listaDeUsuarios);
            ///////////////////////////////////////////////////////////////////////////
            
            DatabaseSQL.InsertarUsuario(nuevoUsuario);
            
            Vm.VentanaMensaje("Registro exitoso.", "Usuario dado de alta");
            
            this.Close();
        }
        #endregion
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}