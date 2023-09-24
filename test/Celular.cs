using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace celular_clases
{
    internal class Celular
    {
        #region atributos y constuctor
        private string titular;
        private string numero;
        private Emarca marca;
        private string modelo;
        private int ram;
        private double almacenamiento;
        private double almacenamientoActual;
        private bool encendido; 
        private List<Contacto> agenda;//lista contactos
        private List<Aplicaciones> listaAplicaciones;//Lista Apps
        private Stack<Contacto> listaDeLlamadas;//lista de llamadas
        private Dictionary<string, DateTime> dictContactos;

        public Celular(string titular,string numero, Emarca marca, string modelo, int ram, double almacenamiento, bool encendido)
        {
            this.titular = titular;
            this.numero = numero;
            this.marca = marca;
            this.modelo = modelo;
            this.ram = ram;
            this.almacenamiento = almacenamiento;
            this.almacenamientoActual = 0;
            this.encendido = encendido;
            this.agenda = new List<Contacto>();
            this.listaAplicaciones = new List<Aplicaciones>();
            this.listaDeLlamadas = new Stack<Contacto> ();
            this.dictContactos = new Dictionary<string, DateTime>();
        }
        #endregion

        #region seters y guetters
        public Emarca Marca { get => marca; set => marca = value; }
        public string Modelo { get => modelo; set => modelo = value; }
        public int Ram { get => ram; set => ram = value; }
        public double Almacenamiento { get => almacenamiento; set => almacenamiento = value; }
        public double AlmacenamientoActual { get => almacenamientoActual; set => almacenamientoActual = value; }
        public bool Encendido { get => encendido; set => encendido = value; }
        #endregion

        public void MostrarCelular()
        {
            Console.WriteLine("***celular***");
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Titular                    " + this.titular);
            sb.AppendLine("Numero                     " + this.numero);
            sb.AppendLine("Marca                      " + this.Marca);
            sb.AppendLine("Modelo                     " + this.Modelo);
            sb.AppendLine("Memoria                    " + this.Ram.ToString() + "MB");
            sb.AppendLine("Capacidad Almacenamiento : " + this.Almacenamiento.ToString() + "GB");
            string estado = "Apagado";
            if (this.Encendido == true)
            {
                estado = "Encendido";
            }
            sb.AppendLine("Estado :                   " + estado+ "\n");
            sb.AppendLine("contactos cargados:");
            foreach (Contacto contacto in agenda)
            {
                sb.AppendLine($"nombre: {contacto.nombre} - numero: {contacto.numero}");
            }
            sb.AppendLine("\nAplicaciones cargadas:");
            foreach (var aplicacion in this.listaAplicaciones)
            {
                sb.AppendLine($"Nombre peso: {aplicacion.Nombre} peso: {aplicacion.Peso}");
            }
            sb.ToString();

            Console.WriteLine(sb);
        }
        
        public string CambiarEstado()
        {
            this.Encendido = !this.encendido;
            return this.Encendido ? "Encendiendo..." : "Apagando...";
        }
        
        public void AgregarContacto(Contacto contacto)
        {
            agenda.Add(contacto);
            dictContactos[contacto.nombre] = DateTime.Now;
        }
        
        public void mostrarListaContactos()
        {   
            if (agenda.Count == 0)
            {
                Console.WriteLine("no hay contactos para mostrar");
            }
            Console.WriteLine("agenda");
            foreach (Contacto i in agenda)
            {
                Console.WriteLine($" Nombre: { i.nombre} Numero: {i.numero}");
            }
            Console.WriteLine("dicc contacos");
            foreach (var i in dictContactos)
            {
                string nombre = i.Key;
                DateTime fecha = i.Value;
                Console.WriteLine($" Nombre: {nombre} Fecha de ingreso: {fecha}");
            }
        }

        public void mostrarlistaDeLlamadas()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("-** llamadas realizadas **-");
            foreach (var llamada in listaDeLlamadas)
            {
                sb.Append($"nombre: {llamada.nombre} ,numero: {llamada.numero}\n");
            }
            Console.WriteLine(sb.ToString());
            
            if (listaDeLlamadas.Count == 0)
            {
                Console.WriteLine("aun no se han realizado llamadas");
            }

        }

        public void InstalarAplicaciones(Aplicaciones nuevaAplicacion)
        {
            string respuesta = "Celular apagado, fallo instalacion";
            ///string nombre = nuevaAplicacion.Nombre;
            ///string peso = nuevaAplicacion.Peso.ToString();
            if (Encendido)
            {
                respuesta = "instalacion fallida **sin espacio de almacenamiento**";
                if ((almacenamiento - (almacenamientoActual + nuevaAplicacion.Peso))  > 0)
                {
                    listaAplicaciones.Add(nuevaAplicacion);
                    almacenamientoActual += nuevaAplicacion.Peso;
                    respuesta = "Exito al instalar aplicacion";
                }
            }
            Console.WriteLine(respuesta);
        }
        
        public void mostrarListaAplicaciones()
        {
            if (listaAplicaciones.Count == 0)
            {
                Console.WriteLine("no hay aplicaciones instaladas");
            }
            foreach (Aplicaciones aplicacion in listaAplicaciones)
            {
                Console.WriteLine($"{aplicacion.Nombre} {aplicacion.Peso}");
            }
            Console.WriteLine($"espacio disponible para aplicaciones {almacenamiento-almacenamientoActual}");
        }
        
        public void RealizarLlamada(string contactoAlLamar)
        {         
            string mensaje = "no es posible realizar la llamada";
            if (Encendido)
            {
                foreach (Contacto contacto in agenda)
                {
                    if (contactoAlLamar == contacto.nombre || contactoAlLamar == contacto.numero)
                    {
                        mensaje = $"llamando a ...{contacto.nombre} {contacto.numero}";
                        listaDeLlamadas.Push(contacto);
                        break;
                    }
                }
            }
            Console.WriteLine(mensaje);
        }
         



    }
}
