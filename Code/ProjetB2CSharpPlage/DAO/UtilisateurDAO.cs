using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetB2CSharpPlage.DAO;
using ProjetB2CSharpPlage.DAL;
using ProjetB2CSharpPlage.Ctrl;

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

        public static void updateUtilisateur(UtilisateurViewModel u)
        {
            UtilisateurDAL.updateUtilisateur(new UtilisateurDAO(u.idUtilisateurProperty, u.nomUtilisateurProperty, u.prenomUtilisateurProperty, u.roleUtilisateurProperty, u.passwordUtilisateurProperty, u.loginUtilisateurProperty));
        }

        public static void supprimerUtilisateur(int id)
        {
            UtilisateurDAL.supprimerUtilisateur(id);
        }

        public static void insertUtilisateur(UtilisateurViewModel u)
        {
            UtilisateurDAL.insertUtilisateur(new UtilisateurDAO(u.idUtilisateurProperty, u.nomUtilisateurProperty, u.prenomUtilisateurProperty, u.roleUtilisateurProperty, u.passwordUtilisateurProperty, u.loginUtilisateurProperty));
        }
    }
}
