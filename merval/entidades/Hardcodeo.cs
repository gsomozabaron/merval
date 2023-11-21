using merval.DB;


namespace merval
{
    public class Hardcodeo
    {


        public static void cargarListayDicc(Dictionary<string, string> dictUsuarioPassword, List<UsuarioSQL> listadoDeUsuarios, List<Acciones> listaDeAccionesGral)
        {
            List<Acciones> listaDeAcciones = new List<Acciones>();


            Acciones YPF = new Acciones("YPF", 150, 140, 0);
            Acciones Acindar = new Acciones("Acindar", 250, 240, 0);
            Acciones tesla = new Acciones("Tesla Motors", 350, 340, 0);

            listaDeAccionesGral.Add(YPF);
            listaDeAccionesGral.Add(Acindar);
            listaDeAccionesGral.Add(tesla);

            //Comisionista nuevoUsuario = new Comisionista("mario", "55000000", "fmario", "mariopass", Tipo.Comisionista, listaDeAcciones, listaDeClientes);
            //listadoDeUsuarios.Add(nuevoUsuario);

            //Usuario nuevoUsuario2 = new Usuario("admin gustavo", "25646638", "admin", "admin", Tipo.Admin, listaDeAcciones, 0, "admin");
            //listadoDeUsuarios.Add(nuevoUsuario2);

            //Usuario nuevoUsuario3 = new Usuario("gustavo", "26985458", "gsomoza", "gpass", Tipo.normal, listaDeAcciones, 0, "somoza");
            //listadoDeUsuarios.Add(nuevoUsuario3);

            //if (!dictUsuarioPassword.ContainsKey("admin"))
            //{
            //    dictUsuarioPassword.Add("admin", "admin");
            //}

            //if (!dictUsuarioPassword.ContainsKey("fmario"))
            //{
            //    dictUsuarioPassword.Add("fmario", "mariopass");
            //}

            //if (!dictUsuarioPassword.ContainsKey("gsomoza"))
            //{
            //    dictUsuarioPassword.Add("gsomoza", "gpass");
            //}
        }

    }
}
