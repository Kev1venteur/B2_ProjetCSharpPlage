using System;
using System.Collections.ObjectModel;
using ProjetB2CSharpPlage.DAL;

namespace ProjetB2CSharpPlage.DAO
{
    public class UtilisateurDAO
    {
        public int idUtilisateurDAO;
        public string nomUtilisateurDAO;
        public string prenomUtilisateurDAO;
        public Byte roleUtilisateurDAO;
        public string passwordUtilisateurDAO;
        public string loginUtilisateurDAO;
        public UtilisateurDAO(int idUtilisateurDAO, string nomUtilisateurDAO, string prenomUtilisateurDAO, Byte roleUtilisateurDAO, string passwordUtilisateurDAO, string loginUtilisateurDAO)
        {
            this.idUtilisateurDAO = idUtilisateurDAO;
            this.nomUtilisateurDAO = nomUtilisateurDAO;
            this.prenomUtilisateurDAO = prenomUtilisateurDAO;
            this.roleUtilisateurDAO = roleUtilisateurDAO;
            this.passwordUtilisateurDAO = passwordUtilisateurDAO;
            this.loginUtilisateurDAO = loginUtilisateurDAO;
        }
        public static ObservableCollection<UtilisateurDAO> listeUtilisateurs()
        {
            ObservableCollection<UtilisateurDAO> l = UtilisateurDAL.selectUtilisateurs();
            return l;
        }

        public static UtilisateurDAO getUtilisateurs(int idUtilisateur)
        {
            UtilisateurDAO p = UtilisateurDAL.getUtilisateur(idUtilisateur);
            return p;
        }

        public static UtilisateurDAO getUtilisateurs(string loginUtilisateur)
        {
            UtilisateurDAO p = UtilisateurDAL.getUtilisateur(loginUtilisateur);
            return p;
        }

        public static void updateUtilisateur(UtilisateurDAO u)
        {
            UtilisateurDAL.updateUtilisateur(u);
        }

        public static void supprimerUtilisateur(int id)
        {
            UtilisateurDAL.supprimerUtilisateur(id);
        }

        public static void insertUtilisateur(UtilisateurDAO u)
        {
            UtilisateurDAL.insertUtilisateur(u);
        }
    }
}
