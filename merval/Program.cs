using Entidades;

namespace merval
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new formLogin());
            //Dictionary<string, string> dictUsuarioPassword = new Dictionary<string, string>();
            //List<Usuario> listadoDeUsuarios = new List<Usuario>();
            //Usuario usuarioActual = new Usuario();
            //Hardcodeo.cargarListayDicc(dictUsuarioPassword, listadoDeUsuarios);
        }
    }
}