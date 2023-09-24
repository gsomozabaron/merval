using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace celular_clases
{
    internal class Compania
    {
        private string razonSocial;
        private DateTime fechaApertura;
        private Stack<Celular> pilaCelulares;


        public Compania(string razonSocial, DateTime fechaApertura)
        {
            this.razonSocial = razonSocial;
            this.fechaApertura = fechaApertura;
            this.pilaCelulares = new Stack<Celular>();
        }

        public string RazonSocial { get => razonSocial; set => razonSocial = value; }
        public DateTime FechaApertura { get => fechaApertura; set => fechaApertura = value; }
        
        public static Compania CrearCompania(Celular nuevoCelular1, Celular nuevoCelular2,Celular nuevoCelular3)
        {
            Compania movistar = new Compania("Movistar", DateTime.Now);
            
            ///Celular nuevoCelular1 = new Celular("casimiro unapeli", "1154286736", Emarca.Motorola, "G7", 1024, 500, false);
            ///Celular nuevoCelular2 = new Celular("sukulito sacallama", "1154286737", Emarca.Huawei, "C7", 1024, 200, false);
            ///Celular nuevoCelular3 = new Celular("Solomeo paredes", "1154286737", Emarca.Xiaomi, "D7", 1024, 600, false);
            
            movistar.AgregarCelular(nuevoCelular1);
            movistar.AgregarCelular(nuevoCelular2);
            movistar.AgregarCelular(nuevoCelular3);

            return movistar;
        }
        public void AgregarCelular(Celular celular)
        {
            pilaCelulares.Push(celular);
        }

        public static void MostrarCompania(Compania compania)
        {

            Console.WriteLine("Razón Social: " + compania.RazonSocial);
            Console.WriteLine("Fecha de Apertura: " + compania.FechaApertura.ToString());

            foreach (var celular in compania.pilaCelulares)
            {
                Console.WriteLine("------- Celular -------");
                celular.MostrarCelular();
            }
        }
    
    
    
    }
}

/*
 Nota: Modificar los métodos necesarios para que funcionen con estas especificaciones.

Crear la clase Compañía que contenga como atributos:
razón social,
fecha de apertura (se inicializa la primera vez que se usa la clase)
pila de celulares
Crear los constructores y propiedades necesarias.
Crear un método mostrarCompañia en donde se listen todos los atributos de la compañía, incluyendo la pila de celulares con sus atributos más importantes, junto a la cola de llamadas efectuadas.
En el Main:
La compañía Movistar con fecha de apertura (fecha actual).
Una pila de celulares de 3 celulares con sus contactos y apps instaladas.
Que cada celular efectúe las llamadas necesarias (algunas que se puedan realizar y otras que no por número inexistente).
Mostrar la compañía con sus celulares.

*/