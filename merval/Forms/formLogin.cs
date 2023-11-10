using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using System.IO;
using System.Xml.Serialization;
using FastReport.DataVisualization.Charting;
using System.Windows.Forms;
using merval.Serializadores;
using merval.DB;

namespace merval
{
    public partial class formLogin : Form
    {
        #region creacion de las listas 
        /// inicio un contador para el auto login
        int Contador = 0;

        // listado de usuarios
        private static List<Usuario> listadoDeUsuarios = new List<Usuario>();
        private static Usuario usuarioActual = new Usuario();

        #endregion


        public formLogin()
        {
            InitializeComponent();
            //List<Usuario> listadoDeUsuarios = DatabaseSQL.Select("Usuario");
            //listadoDeUsuarios = Serializadora.LeerListadoUsuarios();  //carga datos desde XML"en desuso"
            ///DatabaseSQL.CargaSQL();// por unica vez para cargar de xml a DB
        }

        /// <summary>
        /// trae la lista de usuarios desde la base de datos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void formLogin_Load(object sender, EventArgs e)
        {    
            listadoDeUsuarios = DatabaseSQL.GetUsuarios();
        }


        #region login

        /// <summary>
        /// loguea al usuario y lanza la pantalla de usuario normal o la de administrador
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            string usuario = this.txtUsuario.Text;
            string password = this.txtPassword.Text;
            string mensaje;
            string titulo;
            bool estaRegistrado = false;


            if (listadoDeUsuarios != null)// no rompe si no carga la lista
            {
                foreach (Usuario u in listadoDeUsuarios)///buscamos por nombre de usuario en listado de usuarios
                {
                    ///si encontramos el nombre...
                    if (u.NombreUsuario == usuario)
                    {
                        ///buscamos el pass, si coincide..
                        if (u.Pass == password)
                        {
                            usuarioActual = u;
                            titulo = "Bienvenido";  ///titulo para la ventana emergente 
                            mensaje = $"{u.Nombre}";    ///mensaje de bienvenida con el nombre del usuario
                            estaRegistrado = true;  ///pasamos a verdadero para entrar a la linea 93

                            Vm.VentanaMensaje(titulo, mensaje);//ventana emergente
                            break;
                        }

                        //si coincide nombre usuario pero el pass no...
                        else
                        {
                            mensaje = "password incorrecto";
                            Vm.VentanaMensajeError(mensaje);
                            break;
                        }
                    }
                }
            }
            ///si no encuentra ningun nombre de usuario que coincida
            if (estaRegistrado == false)
            {
                mensaje = "Login Error \nusuario no encontrado";
                Vm.VentanaMensajeError(mensaje);
                LimpiarCampos();    // Limpiamos los campos
            }

            ///coinciden usuario y pass..
            else
            {
                if (usuarioActual.TipoDeUsuario == Tipo.normal) //usuario normal
                {
                    FormPrincipal fp = new FormPrincipal(usuarioActual);//ir al formulario principal
                    fp.Show();
                    this.Hide();
                }

                if (usuarioActual.TipoDeUsuario == Tipo.Admin)
                {
                    FormAdmin fa = new FormAdmin();// ir al formulario de administradores
                    fa.Show();
                    this.Hide();
                }
            }
        }
        #endregion

        /// <summary>
        /// lanza el formulario de registro
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRegistrarse_Click(object sender, EventArgs e)
        {
            string alta = "normal";
            FormRegistroUsuarios altaUsuarios = new FormRegistroUsuarios(alta);
            altaUsuarios.ShowDialog();
        }

        #region autocompletar menu login Hardcode
        private void btn_autocompletar_Click(object sender, EventArgs e)
        {
            switch (Contador)
            {
                case 0:
                    this.txtUsuario.Text = "admin";
                    this.txtPassword.Text = "admin";
                    Contador += 1;
                    break;
                case 1:
                    Contador += 1;
                    this.txtUsuario.Text = "gsomoza";
                    this.txtPassword.Text = "gpass";
                    break;
                case 2:
                    Contador += 1;
                    this.txtUsuario.Text = "gala";
                    this.txtPassword.Text = "perrito";
                    break;
                default:
                    Contador = 0;
                    this.txtUsuario.Text = "ivi";
                    this.txtPassword.Text = "coco";
                    break;
            }
        }
        #endregion


        /// <summary>
        /// limpia los campos de usuario y passs despues de una carga NO exitosa
        /// </summary>
        private void LimpiarCampos()
        {
            txtUsuario.Text = string.Empty;
            txtPassword.Text = string.Empty;
        }

        /// <summary>
        /// abandona el programa
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

