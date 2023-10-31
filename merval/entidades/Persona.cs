using System.Runtime.CompilerServices;
using System.Text;

namespace merval
{
    [Serializable]
    public abstract class Persona
    {
        private string _nombreUsuario;
        private string _pass;

        public Persona(string nombreUsuario, string pass)
        {
            this._nombreUsuario = nombreUsuario;
            this._pass = pass;
        }

        public string NombreUsuario { get => _nombreUsuario; set => _nombreUsuario = value; }
        public string Pass { get => _pass; set => _pass = value; }

    }
}