namespace merval.DAO
{
    public interface IUsuarioSQL
    {
        Task AgregarUsuario();

        Task ModificarUsuarios();

        Task BajaUsuario();
    }
}
