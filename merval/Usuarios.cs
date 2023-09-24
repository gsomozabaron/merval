using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace merval
{
    internal class Usuarios
    {
        private string nombre;
        private string apellido;
        private bool esComisionista;
        private string nombreUsuario;
        private string password;

        public Usuarios(string nombre, string apellido, bool esComisionista, string nombreUsuario, string password)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.esComisionista = esComisionista;
            this.nombreUsuario = nombreUsuario;
            this.password = password;
        }

        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public bool EsComisionista { get => esComisionista; set => esComisionista = value; }
        public string NombreUsuario { get => nombreUsuario; set => nombreUsuario = value; }
        public string Password { get => password; set => password = value; }


        public Usuarios CrearUsuario(string nombre, string apellido, bool esComisionista, string nombreUsuario, string password)
        {
            Usuarios usuario = new Usuarios(nombre,apellido,esComisionista,nombreUsuario,password);
            return usuario;
        }
        public void agregarUsuario(string nombre, string password)
        {
            formLogin.dictUsuarioPassword.Add(nombre, password);
        }





    }
}
