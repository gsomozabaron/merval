using merval.DB;
using merval.entidades;
using merval.Serializadores;
using System;
using System.Collections.Generic;
using System.DirectoryServices;
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
            if (HacerValidaciones(usuarioActual, titulo, cantidad, totalCompra))
            {
                usuarioActual.Saldo -= totalCompra;
            
                if (usuarioActual.ListadoDeActivosPropios == null) 
                { 
                    usuarioActual.ListadoDeActivosPropios = new List<Activos>();
                }
                DatabaseSQL.ModificarSaldo(usuarioActual);
                ActualizarActivos(usuarioActual, titulo, cantidad);   
            }
        }

        //public static void VenderActivo(Usuario usuarioActual, string titulo, int cantidad, decimal totalVenta)
        //{
        //    if (HacerValidaciones(usuarioActual, titulo, cantidad, totalVenta))
        //    {
        //        usuarioActual.Saldo += totalVenta;

        //        ActualizarActivos(usuarioActual, titulo, cantidad * -1);
        //    }

        //}

        private static bool HacerValidaciones(Usuario usuarioActual, string titulo, int cantidad, decimal totalCompra)
        {
            bool todook = true;

            if (titulo == "")   //validar que haya algun titulo seleccionado
            {
                Vm.VentanaMensajeError("Selecciona un accion");
                todook = false;
            }
             
            if (cantidad <= 0)  //validar cantidad mayor a cero
            {
                Vm.VentanaMensajeError("La cantidad debe ser mayor que 0.");
                todook = false;
            }

            if (usuarioActual.Saldo < totalCompra)  //validar que saldo sea mayor a compra
            {
                Vm.VentanaMensajeError("Saldo insuficiente.");
                todook = false;
            }

            //cancelar compra
            if (todook)
            {
                if (Vm.VentanaMensajeConfirmar("Confirmar compra?", "") != DialogResult.OK)
                {
                    Vm.VentanaMensaje("Compra", "Cancelada");
                    todook = false;
                }
            }
            return todook;
        }

        private static void ActualizarActivos(Usuario usuarioActual, string titulo, int cantidad)
        {
            Activos nuevoActivo = new Activos();
            nuevoActivo.Nombre = titulo;
            nuevoActivo.Cantidad = cantidad;
            bool encontrada = false;

            foreach (Activos a in usuarioActual.ListadoDeActivosPropios)
            {
                if (a.Nombre == nuevoActivo.Nombre)
                {
                    nuevoActivo.Cantidad += a.Cantidad;
                    DatabaseSQL.modificarCartera(usuarioActual, nuevoActivo);
                    encontrada = true;
                    break;
                }
            }
            if (!encontrada)
            {
                DatabaseSQL.comprarActivo(usuarioActual, nuevoActivo);
            }
            Vm.VentanaMensaje("Transaccion exitosa", $"Adquirido {cantidad}\nde\n{nuevoActivo.Nombre}");
        }

        public static void ActivosUsuario(Usuario usuario, string tipo)
        {
            if (usuario.ListadoDeActivosPropios == null)
            {
                usuario.ListadoDeActivosPropios = new List<Activos>();  
            }

            List<Activos> lista = DatabaseSQL.CarteraUsuario(usuario, tipo);
            foreach (Activos a in lista)
            {
                usuario.ListadoDeActivosPropios.Add(a); 
            }
        }
        
        public static void BajaDeActivosEnCartera(Usuario usuario, Activos activos)
        {
            DatabaseSQL.BajasEnCartera(usuario, activos);
        }

    }
}
