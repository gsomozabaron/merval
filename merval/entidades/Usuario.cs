using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace merval
{
    [Serializable]
    public class Usuario : Persona
    {
        #region atributos
        private string _nombre;
        private string _apellido;
        private string _dni;
        private Tipo _tipoDeUsuario;
        private List<Acciones> _listadoDeAccionesPropias;
        private float _saldo;
        #endregion

        #region constructores
        public Usuario():base(string.Empty, string.Empty)
        {
        }
       
        public Usuario(string nombre, string dni, string nombreUsuario, string pass, 
            Tipo tipoDeUsuario, List<Acciones> listadoDeAccionesPropias, float saldo, string apellido) 
            : base(nombreUsuario,pass)
        {
            this._nombre = nombre;
            this._dni = dni;
            this._tipoDeUsuario = tipoDeUsuario;
            this._listadoDeAccionesPropias = listadoDeAccionesPropias;
            this._saldo = saldo;
            this._apellido = apellido;  
        }
        #endregion

        #region propiedades
        public string Nombre { get => _nombre; set => _nombre = value; }
        public string Apellido { get => _apellido; set => _apellido = value; }
        public string Dni { get => _dni; set => _dni = value; }
        public Tipo TipoDeUsuario { get => _tipoDeUsuario; set => _tipoDeUsuario = value; }
        public List<Acciones> ListadoDeAccionesPropias { get => _listadoDeAccionesPropias; set => _listadoDeAccionesPropias = value; }
        public float Saldo { get => _saldo; set => _saldo = value; }
        #endregion


        public static Usuario CrearUsuario(string nombre, string dni, string nombreUsuario, 
            string pass, Tipo tipoDeUsuario, List<Acciones> listadoDeAccionesPropias, float saldo, string apellido)
        {
            Usuario nuevoUsuario = new (nombre, dni, nombreUsuario, pass, tipoDeUsuario, listadoDeAccionesPropias, saldo, apellido);
            return nuevoUsuario;
        }
    }
}
