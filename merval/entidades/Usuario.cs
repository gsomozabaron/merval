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
        private decimal _saldo;
        #endregion

        #region constructores
        public Usuario():base(string.Empty, string.Empty)
        {
        }
       
        public Usuario(string nombre, string dni, string nombreUsuario, string pass, 
            Tipo tipoDeUsuario, List<Acciones> listadoDeAccionesPropias, decimal saldo, string apellido) 
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
        public decimal Saldo { get => _saldo; set => _saldo = value; }
        #endregion

        /// <summary>
        /// crear nuevo usuario
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="dni"></param>
        /// <param name="nombreUsuario"></param>
        /// <param name="pass"></param>
        /// <param name="tipoDeUsuario"></param>
        /// <param name="listadoDeAccionesPropias"></param>
        /// <param name="saldo"></param>
        /// <param name="apellido"></param>
        /// <returns></returns>
        public static Usuario CrearUsuario(string nombre, string dni, string nombreUsuario, 
            string pass, Tipo tipoDeUsuario, List<Acciones> listadoDeAccionesPropias, decimal saldo, string apellido)
        {
            Usuario nuevoUsuario = new (nombre, dni, nombreUsuario, pass, tipoDeUsuario, listadoDeAccionesPropias, saldo, apellido);
            return nuevoUsuario;
        }

        /// <summary>
        /// añade acciones a la lista de acciones de un usuario
        /// </summary>
        /// <param name="usuarioActual"></param>
        /// <param name="titulo"></param>
        /// <param name="cantidad"></param>
        /// <param name="totalCompra"></param>
        public static void ComprarAccion(Usuario usuarioActual, string titulo, int cantidad, decimal totalCompra)
        {

            if (titulo == "")
            {
                Vm.VentanaMensajeError("Selecciona un accion");
                return;
            }
            try
            {
                //validar cantidad mayor a cero
                if (cantidad <= 0)
                {
                    Vm.VentanaMensajeError("La cantidad debe ser mayor que 0.");
                    return;
                }

                //validar que saldo sea mayor a compra
                if (usuarioActual.Saldo < totalCompra)
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

                //si llego hasta aca, hacer la compra
                Acciones nuevaAccion = new Acciones();
                nuevaAccion.Nombre = titulo;
                nuevaAccion.Cantidad = cantidad;

                usuarioActual.Saldo -= totalCompra;
                usuarioActual.ListadoDeAccionesPropias = usuarioActual.ListadoDeAccionesPropias ?? new List<Acciones>();
                //??: Este operador se llama "operador de fusión nula" y se utiliza para
                //proporcionar un valor predeterminado en caso de que el
                //operando izquierdo sea nulo. En ese caso crea una nueva lista.

                bool estaEnLista = false;
                foreach (Acciones a in usuarioActual.ListadoDeAccionesPropias)
                {
                    if (a.Nombre == nuevaAccion.Nombre)
                    {
                        a.Cantidad += nuevaAccion.Cantidad;
                        estaEnLista = true;
                        break;
                    }
                }

                if (!estaEnLista)
                {
                    usuarioActual.ListadoDeAccionesPropias.Add(nuevaAccion);
                }
                List<Usuario> listaUsuarios = Serializadora.LeerListadoUsuarios();
                Serializadora.ActualizarUsuario(usuarioActual, listaUsuarios);
                Vm.VentanaMensaje("Transaccion exitosa", $"Adquirido {cantidad}\nde\n{nuevaAccion.Nombre}");
            }
            catch (FormatException)
            {
                Vm.VentanaMensajeError("Ingresa una cantidad valida.");
            }
            catch (Exception ex)
            {
                Vm.VentanaMensajeError($"Error: {ex.Message}");
            }
        }
    }
}
