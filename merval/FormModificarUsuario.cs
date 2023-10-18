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
            dataGridView1.DataSource = listadoUsuarios;
        }

        private void btn_Buscar_Click(object sender, EventArgs e)
        {
            bool encontro = false;
            txt_Nombre.Text = "nombre";
            txt_Apellido.Text = "apellido";
            txt_DNI.Text = "DNI";
            txt_NombreUsuario.Text = "nombre usuario";
            string buscar = txt_clave.Text;

            for (int rowIndex = 0; rowIndex < dataGridView1.Rows.Count; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < dataGridView1.Columns.Count; columnIndex++)
                {
                    // Acceder al valor de la celda en la fila rowIndex y columna columnIndex
                    object cellValue = dataGridView1.Rows[rowIndex].Cells[columnIndex].Value;

                    // Comprobar si el valor de la celda contiene el texto de búsqueda (ignorando mayúsculas y minúsculas)
                    if (cellValue != null && cellValue.ToString().IndexOf(buscar, StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        encontro = true;
                        ///llena las celdas con los datos del usuario encontrado
                        txt_Nombre.Text = dataGridView1.Rows[rowIndex].Cells["Nombre"].Value.ToString();
                        txt_Apellido.Text = dataGridView1.Rows[rowIndex].Cells["Apellido"].Value.ToString();
                        txt_DNI.Text = dataGridView1.Rows[rowIndex].Cells["DNI"].Value.ToString();
                        txt_NombreUsuario.Text = dataGridView1.Rows[rowIndex].Cells["NombreUsuario"].Value.ToString();
                        break;
                    }
                }

                if (encontro)
                {
                    break;
                }
            }

            if (!encontro)
            {
                Ventana_error ve = new Ventana_error("Usuario no encontrado");
                ve.ShowDialog();
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
            Usuario usuarioSeleccionado = (Usuario)dataGridView1.SelectedRows[0].DataBoundItem;
            usuarioSeleccionado.Apellido = txt_Apellido.Text;
            usuarioSeleccionado.Dni = txt_DNI.Text;
            usuarioSeleccionado.Nombre = txt_Nombre.Text;
            usuarioSeleccionado.NombreUsuario = txt_NombreUsuario.Text;
            VentanaConfirmar vc = new VentanaConfirmar("ATENCION", "esta seguro?\nSe sobreescribira el archivo ");
            
            if (vc.ShowDialog() == DialogResult.OK)
            {
                ///guardar usuario modificado y actualizar el datagrid
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
            VentanaConfirmar ve = new VentanaConfirmar("ATENCION", "SE ELIMINARA\n PERMANENTEMENTE EL USUARIO");
            if (ve.ShowDialog() == DialogResult.OK)
            {
                listadoUsuarios.Remove(usuarioSeleccionado);///sacar usuario de la lista y grabar
                Serializadora.GuardarListadoUsuarios(listadoUsuarios);
                VentanaEmergente ve2 = new VentanaEmergente("USUARIO", "ELIMINADO");
                ve2.ShowDialog();
                dataGridView1.DataSource = Serializadora.LeerListadoUsuarios();
            }
            else
            {
                VentanaEmergente ve2 = new VentanaEmergente("OPERACION", "CANCELADA");
                ve2.ShowDialog();
            }
        }
    }
}
