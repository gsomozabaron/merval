
using System.Runtime.CompilerServices;
using System.Text;

namespace merval
{
    [Serializable]
    public class Clientes
    {
        public static ulong Contador_ID { get; set; }
        public string Nombre { get; set; }
        public ulong Numero_Id { get; set; }
        public List<Acciones> ListaDeAcciones { get; set; }

        
        static Clientes()
            {
                Contador_ID = 0;
            }

        public Clientes(string nombre)
        {
            this.Nombre = nombre;
            this.ListaDeAcciones = new List<Acciones>(); 
            Contador_ID++;
            this.Numero_Id = Contador_ID;
        }

        public static Clientes CrearClienteNuevo(string nombre)
        {
            Clientes nuevoCliente = new (nombre);

            return nuevoCliente;
        }

        public static string MostrarCliente(Clientes nuevoCliente)
        {
            StringBuilder sb = new ();
            sb.AppendLine(nuevoCliente.Nombre);
            sb.AppendLine(nuevoCliente.Numero_Id.ToString());
            try
            {
                foreach (Acciones accion in nuevoCliente.ListaDeAcciones)
                {
                    ///sb.AppendLine(accion.Nombre + " " + accion.ValorCompra,accion.ValorVenta);
                }
                return sb.ToString();
            }
            catch (Exception)
            {
                return "sin acciones";
            } 
        }
    }
}

