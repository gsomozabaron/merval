using merval.DB;
using merval.entidades;
using merval.Serializadores;
using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;


namespace merval
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

        public Usuario(string nombre, string dni, string nombreUsuario, string pass,
            Tipo tipoDeUsuario, decimal saldo, string apellido)
            : base(nombreUsuario, pass)
        {
            this._nombre = nombre;
            this._dni = dni;
            this._tipoDeUsuario = tipoDeUsuario;
            this._saldo = saldo;
            this._apellido = apellido;
        }

        public Usuario(int id, string nombre, string dni, string nombreUsuario, string pass,
            Tipo tipoDeUsuario, decimal saldo, string apellido)
            : base(nombreUsuario, pass)
        {
            this._id = id;
            this._nombre = nombre;
            this._dni = dni;
            this._tipoDeUsuario = tipoDeUsuario;
            this._saldo = saldo;
            this._apellido = apellido;
        }

        public Usuario(int id, List<Activos> listadoDeActivosPropios) : this()
        {
            this._id = id;
            this._listadoDeActivosPropios = listadoDeActivosPropios;
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
            Usuario nuevoUsuario = new (nombre, dni, nombreUsuario, pass, tipoDeUsuario, saldo, apellido);
            return nuevoUsuario;
        }
       

        // añade acciones a la lista de acciones de un usuario
        public static void ComprarActivo (Usuario usuarioActual, string titulo, int cantidad, decimal totalCompra, string tipo)
        {
            HacerValidaciones(usuarioActual, titulo, cantidad, totalCompra);
           
            usuarioActual.Saldo -= totalCompra;
            
            if (usuarioActual.ListadoDeActivosPropios == null) 
            { 
                usuarioActual.ListadoDeActivosPropios = new List<Activos>();
            }

            if (tipo == "Acciones")
            {
                ComprarAcciones(usuarioActual, titulo, cantidad);
            }
            else if (tipo == "Monedas")
            {
                ComprarMoneda(usuarioActual, titulo, cantidad);
            }
        }

        private static void HacerValidaciones(Usuario usuarioActual, string titulo, int cantidad, decimal totalCompra)
        {
            if (titulo == "")   //validar que haya algun titulo seleccionado
            {
                Vm.VentanaMensajeError("Selecciona un accion");
                return;
            }
             
            if (cantidad <= 0)  //validar cantidad mayor a cero
            {
                Vm.VentanaMensajeError("La cantidad debe ser mayor que 0.");
                return;
            }

            if (usuarioActual.Saldo < totalCompra)  //validar que saldo sea mayor a compra
            {
                Vm.VentanaMensajeError("Saldo insuficiente.");
                return;
            }

            //cancelar compra
            if (Vm.VentanaMensajeConfirmar("Confirmar compra?", "") != DialogResult.OK)
            {
                Vm.VentanaMensaje("Compra", "Cancelada");
                return;
            }
        }

        private static void ComprarAcciones(Usuario usuarioActual, string titulo, int cantidad)
        {
            Acciones nuevaAccion = new Acciones();
            nuevaAccion.Nombre = titulo;
            nuevaAccion.Cantidad = cantidad;

            bool estaEnLista = EstaEnLista(usuarioActual, nuevaAccion);
            if (!estaEnLista)
            {
                usuarioActual.ListadoDeActivosPropios.Add(nuevaAccion);
            }
            List<Usuario> listaUsuarios = DatabaseSQL.GetUsuarios();
            Serializadora.ActualizarUsuario(usuarioActual, listaUsuarios);
            Vm.VentanaMensaje("Transaccion exitosa", $"Adquirido {cantidad}\nde\n{nuevaAccion.Nombre}");


        }
        
        private static void ComprarMoneda(Usuario usuarioActual, string titulo, int cantidad)
        {
            Monedas nuevaAccion = new Monedas();
            nuevaAccion.Nombre = titulo;
            nuevaAccion.Cantidad = cantidad;
            bool estaEnLista = EstaEnLista(usuarioActual, nuevaAccion);
            if (!estaEnLista)
            {
                usuarioActual.ListadoDeActivosPropios.Add(nuevaAccion);
            }
            List<Usuario> listaUsuarios = DatabaseSQL.GetUsuarios();
            Serializadora.ActualizarUsuario(usuarioActual, listaUsuarios);
            Vm.VentanaMensaje("Transaccion exitosa", $"Adquirido {cantidad}\nde\n{nuevaAccion.Nombre}");
        }

        private static bool EstaEnLista(Usuario usuarioActual, Activos nuevaAccion)
        {
            bool estaEnLista = false;
            foreach (Activos a in usuarioActual.ListadoDeActivosPropios)
            {
                if (a.Nombre == nuevaAccion.Nombre)
                {
                    a.Cantidad += nuevaAccion.Cantidad;
                    estaEnLista = true;
                    break;
                }
            }
            return estaEnLista;
        }

        

    }
}
