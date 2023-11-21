using System.Xml.Serialization;

namespace merval.DB
{
    [Serializable]
    [XmlInclude(typeof(Activos))]
    [XmlInclude(typeof(Acciones))]
    [XmlInclude(typeof(Monedas))]

    public class Usuario : Persona
    {
        #region atributos
        [XmlArray("ListadoDeActivosPropios")]
        [XmlArrayItem("Activos", typeof(Activos))]

        private int _id;
        private string _nombre;
        private string _apellido;
        private string _dni;
        private Tipo _tipoDeUsuario;
        private List<Activos> _listadoDeActivosPropios;
        private decimal _saldo;

        #endregion

        #region constructores
        public Usuario() : base(string.Empty, string.Empty)
        {
        }
        public Usuario(int id) : this()
        {
            _id = id;
            ListadoDeActivosPropios = new List<Activos>();
        }

        public Usuario(string nombre, string dni, string nombreUsuario, string pass,
            Tipo tipoDeUsuario, decimal saldo, string apellido)
            : base(nombreUsuario, pass)
        {
            _nombre = nombre;
            _dni = dni;
            _tipoDeUsuario = tipoDeUsuario;
            _saldo = saldo;
            _apellido = apellido;
        }


        public Usuario(int id, string nombre, string dni, string nombreUsuario, string pass,
            Tipo tipoDeUsuario, decimal saldo, string apellido)
            : base(nombreUsuario, pass)
        {
            _id = id;
            _nombre = nombre;
            _dni = dni;
            _tipoDeUsuario = tipoDeUsuario;
            _saldo = saldo;
            _apellido = apellido;
            ListadoDeActivosPropios = new List<Activos>();
        }





        #endregion

        #region propiedades
        public int Id { get => _id; set => _id = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }
        public string Apellido { get => _apellido; set => _apellido = value; }
        public string Dni { get => _dni; set => _dni = value; }
        public Tipo TipoDeUsuario { get => _tipoDeUsuario; set => _tipoDeUsuario = value; }
        public List<Activos> ListadoDeActivosPropios { get => _listadoDeActivosPropios; set => _listadoDeActivosPropios = value; }
        public decimal Saldo { get => _saldo; set => _saldo = value; }


        #endregion


        /// crear nuevo usuario
        public static Usuario CrearUsuario(string nombre, string dni, string nombreUsuario, string pass, Tipo tipoDeUsuario, decimal saldo, string apellido)
        {
            Usuario nuevoUsuario = new(nombre, dni, nombreUsuario, pass, tipoDeUsuario, saldo, apellido);
            return nuevoUsuario;
        }







    }
}
