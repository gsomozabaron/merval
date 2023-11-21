using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using merval.Serializadores;
using merval.DB;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using merval.entidades;
using merval.DAO;

namespace merval
{
    public partial class FormModificarUsuario : Form
    {
        private List<UsuarioSQL> listaUsuarios; // Cambiado para ser un campo de la clase
        //private Usuario usuario; // Agregado para ser un campo de la clase


        public FormModificarUsuario()
        {
            InitializeComponent();
        }


        private void btn_Salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private async void FormModificarUsuario_Load(object sender, EventArgs e)
        {
            
            listaUsuarios = await UsuarioSQL.CrearListaDeUsuarios();
            CargarDatos();
        }

        private void CargarDatos()
        {
            dataGridView1.DataSource = listaUsuarios;
            dataGridView1.Columns["pass"].Visible = false;
            dataGridView1.Columns["saldo"].Visible = false;
        }


        private void btn_Buscar_Click(object sender, EventArgs e)
        {
            bool encontro = false;
            txt_Nombre.Text = "nombre";
            txt_Apellido.Text = "apellido";
            txt_DNI.Text = "DNI";
            txt_NombreUsuario.Text = "nombre usuario";
            string buscar = txt_clave.Text.ToLower();

            foreach (UsuarioSQL u in listaUsuarios)
            {
                try
                {
                    if (u.Nombre.ToLower().Contains(buscar) ||
                        u.NombreUsuario.ToLower().Contains(buscar) ||
                        u.Apellido.ToLower().Contains(buscar) ||
                        u.Dni.Contains(buscar)
                    )
                    {
                        if (Vm.VentanaMensajeConfirmar($"{u.Nombre}, {u.Apellido}", $"{u.NombreUsuario} es el usuario?") == DialogResult.OK)
                        {
                            txt_Nombre.Text = u.Nombre.ToString();
                            txt_Apellido.Text = u.Apellido.ToString();
                            txt_DNI.Text = u.Dni.ToString();
                            txt_NombreUsuario.Text = u.NombreUsuario.ToString();
                            encontro = true;
                            break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Vm.VentanaMensajeError($"Error: {ex.Message}");
                    LimpiarCampos();
                }
            }
            if (!encontro)
            {
                Vm.VentanaMensajeError("Usuario no encontrado");
                LimpiarCampos();
            }
        }


        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            if (dataGridView1.SelectedRows.Count > 0)
            {
                UsuarioSQL usuarioSeleccionado = (UsuarioSQL)dataGridView1.SelectedRows[0].DataBoundItem;
                ///llena las celdas con los datos del usuario seleccionado con doble click
                txt_Apellido.Text = usuarioSeleccionado.Apellido;
                txt_DNI.Text = usuarioSeleccionado.Dni;
                txt_Nombre.Text = usuarioSeleccionado.Nombre;
                txt_NombreUsuario.Text = usuarioSeleccionado.NombreUsuario;

            }

        }


        private async void btn_actualizar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_Nombre.Text) || string.IsNullOrEmpty(txt_Apellido.Text) || string.IsNullOrEmpty(txt_DNI.Text))
            {
                Vm.VentanaMensajeError("Todos los campos deben estar llenos.");
                return;
            }

            UsuarioSQL usuarioSeleccionado = (UsuarioSQL)dataGridView1.SelectedRows[0].DataBoundItem;
            int id = usuarioSeleccionado.Id;
            usuarioSeleccionado.Apellido = txt_Apellido.Text;
            usuarioSeleccionado.Dni = txt_DNI.Text;
            usuarioSeleccionado.Nombre = txt_Nombre.Text;
            usuarioSeleccionado.NombreUsuario = txt_NombreUsuario.Text;

            if (Vm.VentanaMensajeConfirmar("ATENCION", "¿Está seguro?\nSe sobrescribirá el archivo.") == DialogResult.OK)
            {
                await usuarioSeleccionado.ModificarUsuarios();

                List<UsuarioSQL> listaUsuarios =await UsuarioSQL.CrearListaDeUsuarios();
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = listaUsuarios;
                LimpiarCampos();
            }
            else
            {
                dataGridView1.DataSource = listaUsuarios;
                LimpiarCampos();
            }
        }


        private async void btn_EliminarUsuario_Click(object sender, EventArgs e)
        {
            UsuarioSQL usuarioSeleccionado = (UsuarioSQL)dataGridView1.SelectedRows[0].DataBoundItem;

            if (Vm.VentanaMensajeConfirmar("ATENCION", "SE ELIMINARA\n PERMANENTEMENTE EL USUARIO") == DialogResult.OK)
            {
                await usuarioSeleccionado.BajaUsuario();
                
                Vm.VentanaMensaje("USUARIO", "ELIMINADO");
                listaUsuarios = await UsuarioSQL.CrearListaDeUsuarios();
                dataGridView1.DataSource = listaUsuarios;
              
                LimpiarCampos();
            }
            else
            {
                Vm.VentanaMensaje("OPERACION", "CANCELADA");
                LimpiarCampos();
            }
        }

        private void LimpiarCampos()
        {
            txt_Apellido.Text = string.Empty;
            txt_DNI.Text = string.Empty;
            txt_Nombre.Text = string.Empty;
            txt_NombreUsuario.Text = string.Empty;
        }

    }
}
