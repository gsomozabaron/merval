using Microsoft.VisualBasic.ApplicationServices;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace merval.DAO
{
    public interface IUsuarioDao
    { 
        void AgregarUsuario(Usuario usuario);
        
        void ModificarUsuarios(Usuario usuario);

        void BajaUsuario(Usuario usuario);
    }
}
