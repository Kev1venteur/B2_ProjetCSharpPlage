using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetB2CSharpPlage.Ctrl
{
    class ConnexionBaseModele
    {
        private string username;
        private string password;

        public ConnexionBaseModele() { }

        public ConnexionBaseModele(string nomUtilisateur, string motDePasse)
        {
            this.username = nomUtilisateur;
            this.password = motDePasse;
        }
    }
}
