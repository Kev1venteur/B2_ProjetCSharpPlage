using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ProjetB2CSharpPlage.DAL
{
    class ConnexionUtilisateurDAL
    {
        private static MySqlConnection connection;
        public ConnexionUtilisateurDAL()
        {
            DALConnection.OpenConnection(); //  si la connexion est déjà ouverte, il ne la refera pas (voir code dans DALConnection)
            connection = DALConnection.connection;
        }
    }
}
