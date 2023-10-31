using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using System.IO;
using System.Xml.Serialization;
using FastReport.DataVisualization.Charting;
using System.Windows.Forms;

namespace merval
{
    public partial class formLogin : Form
    {
        #region creacion de las listas 
        /// inicio un contador para el auto login
        int Contador = 0;

        // listado de usuarios
        private static List<Usuario> listadoDeUsuarios = new List<Usuario>();
        /// listado general de acciones
        //private static List<Acciones> listaDeAccionesGral = new List<Acciones>();

        private static Usuario usuarioActual = new Usuario();
        #endregion

        //#region seters y getters listas
        //public static Usuario UsuarioActual
        //{
        //    get => usuarioActual; set => usuarioActual = value;
        //}

        //public static List<Usuario> ListadoDeUsuarios
        //{
        //    get => listadoDeUsuarios; set => listadoDeUsuarios = value;
        //}

        //public static List<Acciones> ListadeAccionesGral
        //{
        //    get => listaDeAccionesGral; set => listaDeAccionesGral = value;
        //}
        //#endregion

        public formLogin()
        {
            InitializeComponent();
            listadoDeUsuarios = Serializadora.LeerListadoUsuarios();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #region login
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            string usuario = this.txtUsuario.Text;
            string password = this.txtPassword.Text;
            string mensaje;
            string titulo;
            bool estaRegistrado = false;

            if (listadoDeUsuarios != null)// no rompe si los archivos xml no estan
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
                default:
                    Contador = 0;
                    this.txtUsuario.Text = "fmario";
                    this.txtPassword.Text = "mariopass";
                    break;
            }
        }
        #endregion

        private void LimpiarCampos()
        {
            txtUsuario.Text = string.Empty;
            txtPassword.Text = string.Empty;
        }
    }
}

