using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetB2CSharpPlage.DAO
{
    class ConnexionUtilisateurDAO
    {
        public string usernameConnexionUtilisateurDAO;
        public string passwordConnexionUtilisateurDAO;
        public ConnexionUtilisateurDAO(string username, string password)
        {
            this.usernameConnexionUtilisateurDAO = username;
            this.passwordConnexionUtilisateurDAO = password;
        }
    }
}
