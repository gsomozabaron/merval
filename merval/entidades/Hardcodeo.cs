﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace merval
{
    public class Hardcodeo
    {
        

        public static void cargarListayDicc(Dictionary<string, string> dictUsuarioPassword, List<Usuario> listadoDeUsuarios, List<Acciones> listaDeAccionesGral)      
        {
            List<Acciones> listaDeAcciones = new List<Acciones>();
            List<Clientes> listaDeClientes = new List<Clientes>();

            Acciones YPF = new Acciones("YPF", 150, 140);
            Acciones Acindar = new Acciones("Acindar", 250,240);
            Acciones tesla = new Acciones("Tesla Motors", 350, 340  );

            listaDeAccionesGral.Add(YPF);
            listaDeAccionesGral.Add(Acindar);
            listaDeAccionesGral.Add(tesla);

            //Comisionista nuevoUsuario = new Comisionista("mario", "55000000", "fmario", "mariopass", Tipo.Comisionista, listaDeAcciones, listaDeClientes);
            //listadoDeUsuarios.Add(nuevoUsuario);

            Usuario nuevoUsuario2 = new Usuario("admin gustavo", "25646638", "admin", "admin", Tipo.Admin, listaDeAcciones, 0, "admin");
            listadoDeUsuarios.Add(nuevoUsuario2);

            Usuario nuevoUsuario3 = new Usuario("gustavo", "26985458", "gsomoza", "gpass", Tipo.normal, listaDeAcciones, 0, "somoza");
            listadoDeUsuarios.Add(nuevoUsuario3);

            if (!dictUsuarioPassword.ContainsKey("admin"))
            {
                dictUsuarioPassword.Add("admin", "admin");
            }

            if (!dictUsuarioPassword.ContainsKey("fmario"))
            {
                dictUsuarioPassword.Add("fmario", "mariopass");
            }

            if (!dictUsuarioPassword.ContainsKey("gsomoza"))
            {
                dictUsuarioPassword.Add("gsomoza", "gpass");
            }
        }
        
    }
}
