using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace merval
{
    public partial class FormBajaUsuarios : Form
    {
        
        List<Usuario> listUsuarios = Serializadora.LeerListadoUsuarios();
        Usuario usuarioAeliminar;
        Dictionary<string, string> dictLogin = Serializadora.LeerDictLogin(); 

        public FormBajaUsuarios()
        {
            InitializeComponent();


        }


        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            List<Usuario> eliminarUsuarios = new List<Usuario>();
            ///Usuario usuarioAeliminar = new Usuario();
            string dato = txt_dato.Text;

            foreach (Usuario usuario in listUsuarios)
            {
                if (rBtn_Dni.Checked)
                {
                    if (dato == usuario.Dni)
                    {
                        eliminarUsuarios.Add(usuario);
                        usuarioAeliminar = usuario;
                        break;
                    }
                }
                if (rBtn_nombre.Checked)
                {
                    if (dato == usuario.Nombre)
                    {
                        eliminarUsuarios.Add(usuario);
                        usuarioAeliminar = usuario;
                        break;
                    }
                }
                if (rBtn_nombreUsuario.Checked)
                {
                    if (dato == usuario.NombreUsuario)
                    {
                        eliminarUsuarios.Add(usuario);
                        usuarioAeliminar = usuario;
                        break;
                    }
                }
            }
            DTG_datagrid.DataSource = eliminarUsuarios;
        }

        private void btn_confirm_Click(object sender, EventArgs e)
        {
            if (usuarioAeliminar != null)
            {
                string nombreUsuario = usuarioAeliminar.NombreUsuario;
                dictLogin.Remove(nombreUsuario);

                listUsuarios.Remove(usuarioAeliminar);
                Serializadora.GuardarListadoUsuarios2(listUsuarios);
                VentanaEmergente ve = new VentanaEmergente("exito", "usuario eliminado");
                ve.ShowDialog();
                Serializadora.Grabar_dict_login2(dictLogin);
            }
            else
            {
                Ventana_error v = new Ventana_error("No hay un usuario para eliminar.");
                v.ShowDialog();
            }
        }
    }
}
