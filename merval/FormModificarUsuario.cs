using Entidades;
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

namespace merval
{
    public partial class FormModificarUsuario : Form
    {
        private List<Usuario> listadoUsuarios = Serializadora.LeerListadoUsuarios();


        public FormModificarUsuario()
        {
            InitializeComponent();
        }


        private void btn_Salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void FormModificarUsuario_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void CargarDatos()
        {
            dataGridView1.DataSource = listadoUsuarios;
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

            foreach (Usuario u in listadoUsuarios)
            {
                try
                {
                    if (u.Nombre.ToLower().Contains(buscar) ||
                        u.NombreUsuario.ToLower().Contains(buscar) ||
                        u.Apellido.ToLower().Contains(buscar) ||
                        u.Dni.Contains(buscar)
                    )
                    {
                        if (FormMetodos.VentanaMensajeConfirmar($"{u.Nombre}, {u.Apellido}", $"{u.NombreUsuario} es el usuario?") == DialogResult.OK)
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
                    FormMetodos.VentanaMensajeError($"Error: {ex.Message}");
                }
            }
            if (!encontro)
            {
                FormMetodos.VentanaMensajeError("Usuario no encontrado");
            }
        }


        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            if (dataGridView1.SelectedRows.Count > 0)
            {
                Usuario usuarioSeleccionado = (Usuario)dataGridView1.SelectedRows[0].DataBoundItem;
                ///llena las celdas con los datos del usuario seleccionado con doble click
                txt_Apellido.Text = usuarioSeleccionado.Apellido;
                txt_DNI.Text = usuarioSeleccionado.Dni;
                txt_Nombre.Text = usuarioSeleccionado.Nombre;
                txt_NombreUsuario.Text = usuarioSeleccionado.NombreUsuario;

            }

        }


        private void btn_actualizar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_Nombre.Text) || string.IsNullOrWhiteSpace(txt_Apellido.Text) || string.IsNullOrWhiteSpace(txt_DNI.Text) || string.IsNullOrWhiteSpace(txt_NombreUsuario.Text))
            {
                FormMetodos.VentanaMensajeError("Todos los campos deben estar llenos.");
                return;
            }

            Usuario usuarioSeleccionado = (Usuario)dataGridView1.SelectedRows[0].DataBoundItem;
            usuarioSeleccionado.Apellido = txt_Apellido.Text;
            usuarioSeleccionado.Dni = txt_DNI.Text;
            usuarioSeleccionado.Nombre = txt_Nombre.Text;
            usuarioSeleccionado.NombreUsuario = txt_NombreUsuario.Text;

            if (FormMetodos.VentanaMensajeConfirmar("ATENCION", "¿Está seguro?\nSe sobrescribirá el archivo.") == DialogResult.OK)
            {
                // Guardar usuario modificado y actualizar el DataGridView
                Serializadora.GuardarListadoUsuarios(listadoUsuarios);
                dataGridView1.DataSource = Serializadora.LeerListadoUsuarios();
            }
            else
            {
                dataGridView1.DataSource = listadoUsuarios;
            }
        }


        private void btn_EliminarUsuario_Click(object sender, EventArgs e)
        {
            Usuario usuarioSeleccionado = (Usuario)dataGridView1.SelectedRows[0].DataBoundItem;

            if (FormMetodos.VentanaMensajeConfirmar("ATENCION", "SE ELIMINARA\n PERMANENTEMENTE EL USUARIO") == DialogResult.OK)
            {
                listadoUsuarios.Remove(usuarioSeleccionado);///sacar usuario de la lista y grabar
                Serializadora.GuardarListadoUsuarios(listadoUsuarios);
                FormMetodos.VentanaMensaje("USUARIO", "ELIMINADO");
                dataGridView1.DataSource = Serializadora.LeerListadoUsuarios();
            }
            else
            {
                FormMetodos.VentanaMensaje("OPERACION", "CANCELADA");
            }
        }


    }
}
