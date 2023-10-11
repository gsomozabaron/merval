using Entidades;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using System.IO;
using System.Xml.Serialization;

namespace merval
{
    public partial class formLogin : Form
    {
        #region creacion de las listas 
        /// inicio un contador para el auto login
        int Contador = 0;

        /// <summary>
        /// dicionario de usuarios para el login 
        /// </summary>
        private static Dictionary<string, string> dictUsuarioPassword = new Dictionary<string, string>();
        
        /// <summary>
        /// listado de usuarios
        /// </summary>
        private static List<Usuario> listadoDeUsuarios = new List<Usuario>();

        /// <summary>
        /// listado general de acciones
        /// </summary>
        private static List<Acciones> listaDeAccionesGral = new List<Acciones>();

        private static Usuario usuarioActual = new Usuario();

        #endregion

        #region seters y getters listas
        public static Usuario UsuarioActual
        {
            get => usuarioActual; set => usuarioActual = value;
        }

        public static List<Usuario> ListadoDeUsuarios
        {
            get => listadoDeUsuarios; set => listadoDeUsuarios = value;
        }
        
        public static Dictionary<string, string> DictUsuarioPassword
        {
            get => dictUsuarioPassword; set => dictUsuarioPassword = value;
        }
        
        public static List<Acciones> ListadeAccionesGral
        {
            get => listaDeAccionesGral; set => listaDeAccionesGral = value;
        }
        #endregion

        /// <summary>
        /// asignamos a las listas los valores guardados en los archivos
        /// </summary>
        public formLogin()
        {
            InitializeComponent();
            dictUsuarioPassword = Serializadora.LeerDictLogin();
            listadoDeUsuarios = Serializadora.LeerListadoUsuarios();
            listaDeAccionesGral = Serializadora.LeerListaAcciones();

            #region harcodeo ya no hace falta, lo todo de los archivos
            /// ya no hace falta el hard /// levanto del archivo
            //if (dictUsuarioPassword.Count == 0)
            //{
            //    Hardcodeo.cargarListayDicc(dictUsuarioPassword, listadoDeUsuarios, listaDeAccionesGral);
            //}
            #endregion
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

            //chequear que nombre de usuario este en el dicc de login
            if (dictUsuarioPassword.ContainsKey(usuario))
            {
                string passEnDict = dictUsuarioPassword[usuario];
                //si el nombre de usuario coincide chequear el pass
                if (password == passEnDict)
                {
                    foreach (Usuario usuariologin in listadoDeUsuarios)
                    {
                        if (usuariologin.NombreUsuario == usuario)
                        {
                            usuarioActual = usuariologin;
                            break;
                        }
                    }
                    VentanaEmergente ve = new VentanaEmergente("login exitoso", $"Bienvenido, {usuarioActual.Nombre}");
                    ve.ShowDialog();

                    if (ve.DialogResult == DialogResult.OK)
                    {
                        //si es del tipo admin...
                        if (usuarioActual.TipoDeUsuario == Tipo.Admin)
                        {
                            FormAdmin formadmin = new FormAdmin();
                            this.Hide();
                            formadmin.Show();//ir al menu principal de administrador
                        }
                        else //si no es del tipo admin..es usuario normal..ir al menu de usuario normal
                        {
                            FormPrincipal MenuPrincipal = new FormPrincipal();
                            MenuPrincipal.Show();
                            this.Hide();
                        }
                    }
                }
                else //si el pass no coincide con lo almacenado en dicc login
                {
                    this.txtUsuario.Text = string.Empty;  // Limpiamos los campos
                    this.txtPassword.Text = string.Empty; // Limpiamos los campos
                    VentanaEmergente ve = new VentanaEmergente("Error", "Contraseña incorrecta");
                    ve.ShowDialog();
                }
            }
            else // si el nomber de usuario no figura en el dicc...
            {
                this.txtUsuario.Text = string.Empty;  // Limpiamos los campos
                this.txtPassword.Text = string.Empty; // Limpiamos los campos
                VentanaEmergente ve = new VentanaEmergente("Error", "Usuario no encontrado");
                ve.ShowDialog();
            }
        }
        #endregion
        
        private void btnRegistrarse_Click(object sender, EventArgs e)
        {
            FormRegistroUsuarios altaUsuarios = new FormRegistroUsuarios();
            altaUsuarios.ShowDialog();
        }

        #region autocompletar menu login
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
    }
}