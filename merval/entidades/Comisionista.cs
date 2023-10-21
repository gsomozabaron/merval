using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace merval
{
    [Serializable]
    public class Comisionista : Usuario
    {

        private List<Clientes> _listaDeClientes;

        #region constructor
        public Comisionista()
        {
        }

        public Comisionista(string nombre, 
                            string dni, 
                            string nombreUsuario, 
                            string pass, 
                            Tipo tipoDeUsuario, 
                            List<Acciones> listadoDeAccionesPropias, 
                            List<Clientes> listaDeClientes, 
                            long saldo, 
                            string apellido)       
            : base(nombre, dni, nombreUsuario, pass, tipoDeUsuario, 
                  listadoDeAccionesPropias, saldo, apellido)
        {
            this._listaDeClientes = new List<Clientes>();
        }
        #endregion

        #region propiedades
        public List<Clientes> ListaDeClientes { get => _listaDeClientes; set => _listaDeClientes = value; }
        #endregion

        #region metodos
        public static Comisionista CrearComisionista(string nombre, string dni, string nombreUsuario, string pass, Tipo tipoDeUsuario, List<Acciones> listadoDeAccionesPropias, List<Clientes> listaDeClientes, long saldo, string apellido)
        {
            Comisionista nuevoComisionista = new Comisionista(nombre, dni, nombreUsuario, pass, tipoDeUsuario, listadoDeAccionesPropias, listaDeClientes, saldo, apellido);
            return nuevoComisionista;
        }
        #endregion

    }
}
