using System.Data.Common;
using System.Text;

namespace celular_clases
{
    internal class Program
    {
        static void Main(string[] args)
        {
            

            
            Celular nuevoCelular1 = new Celular("casimiro unapeli", "1154286736", Emarca.Motorola, "G7", 1024, 500, false);
            Celular nuevoCelular2 = new Celular("sukulito sacallama", "1154286737", Emarca.Huawei , "C7", 1024, 200, false);
            Celular nuevoCelular3 = new Celular("Solomeo paredes", "1154286737", Emarca.Xiaomi, "D7", 1024, 600, false);
                        
            /// ***  crear contactos   *** ///
            Contacto Contacto1 = new Contacto("mariano", "1554282222");
            Contacto Contacto2 = new Contacto("hector", "1554283333");
            Contacto Contacto3 = new Contacto("jose", "1554284444");

            Aplicaciones Aplicacion1 = new Aplicaciones("Tinder", 40);
            Aplicaciones Aplicacion2 = new Aplicaciones("Whatsapp", 70);
            Aplicaciones Aplicacion3 = new Aplicaciones("Instagram", 60);
            Aplicaciones Aplicacion4 = new Aplicaciones("starwars the force unleashed", 60000);


            //************* prender y apagar *****************//
            Console.WriteLine(nuevoCelular1.CambiarEstado());
            Console.WriteLine(nuevoCelular2.CambiarEstado());
            Console.WriteLine(nuevoCelular3.CambiarEstado());

            //// *** agregar contactos a la agenda *** ///
            nuevoCelular1.AgregarContacto(Contacto1);
            nuevoCelular1.AgregarContacto(Contacto2);
            nuevoCelular1.AgregarContacto(Contacto3);
            nuevoCelular2.AgregarContacto(Contacto1);
            nuevoCelular2.AgregarContacto(Contacto2);
            nuevoCelular2.AgregarContacto(Contacto3);
            nuevoCelular3.AgregarContacto(Contacto1);
            nuevoCelular3.AgregarContacto(Contacto2);
            nuevoCelular3.AgregarContacto(Contacto3);




            /// instalar aplicaciones
            nuevoCelular1.InstalarAplicaciones(Aplicacion1);
            nuevoCelular1.InstalarAplicaciones(Aplicacion2);
            nuevoCelular1.InstalarAplicaciones(Aplicacion3);
            nuevoCelular2.InstalarAplicaciones(Aplicacion1);
            nuevoCelular2.InstalarAplicaciones(Aplicacion2);
            nuevoCelular3.InstalarAplicaciones(Aplicacion1);


            //************* prender y apagar *****************//
            Console.WriteLine(nuevoCelular1.CambiarEstado());
            Console.WriteLine(nuevoCelular1.CambiarEstado());

            //**intentar instalar una app demasiado pesada para el celular**
            nuevoCelular1.InstalarAplicaciones(Aplicacion4);


            //*********** mostrar agenda *********************//
            nuevoCelular1.mostrarListaContactos();

            //************** mostrar celular *****************//
            nuevoCelular1.MostrarCelular();

            //************** mostrar aplicaciones ************//
            nuevoCelular1.mostrarListaAplicaciones();

            //************ hacer una llamada *****************//

            nuevoCelular1.RealizarLlamada("1554282222");
            //************ llamara un numero sin agendar******//
            nuevoCelular1.RealizarLlamada("jose");
            nuevoCelular1.RealizarLlamada("marta");
            nuevoCelular1.RealizarLlamada("jos");

            nuevoCelular1.mostrarlistaDeLlamadas();

            Compania movistar = Compania.CrearCompania(nuevoCelular1, nuevoCelular2, nuevoCelular3);
            
            Compania.MostrarCompania(movistar);










        }
    }
}