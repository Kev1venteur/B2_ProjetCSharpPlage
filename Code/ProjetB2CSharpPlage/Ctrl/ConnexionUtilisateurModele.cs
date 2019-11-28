using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetB2CSharpPlage.Ctrl
{
    class ConnexionUtilisateurModele
    {
        private string username;
        private string password;

        public ConnexionUtilisateurModele() { }

        public ConnexionUtilisateurModele(string nomUtilisateur, string motDePasse)
        {
            this.username = nomUtilisateur;
            this.password = motDePasse;
        }
    }
}
