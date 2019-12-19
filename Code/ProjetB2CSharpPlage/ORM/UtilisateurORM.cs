using System.Collections.ObjectModel;
using ProjetB2CSharpPlage.VM;
using ProjetB2CSharpPlage.DAO;

namespace ProjetB2CSharpPlage.ORM
{
    class UtilisateurORM
    {
        public static UtilisateurViewModel getUtilisateur(int idUtilisateur)
        {
            UtilisateurDAO pDAO = UtilisateurDAO.getUtilisateurs(idUtilisateur);
            UtilisateurViewModel p = new UtilisateurViewModel(pDAO.idUtilisateurDAO, pDAO.nomUtilisateurDAO, pDAO.prenomUtilisateurDAO, pDAO.roleUtilisateurDAO, pDAO.passwordUtilisateurDAO, pDAO.loginUtilisateurDAO);
            return p;
        }

        public static UtilisateurViewModel getUtilisateur(string loginUtilisateur)
        {
            UtilisateurDAO pDAO = UtilisateurDAO.getUtilisateurs(loginUtilisateur);
            UtilisateurViewModel p = new UtilisateurViewModel(pDAO.idUtilisateurDAO, pDAO.nomUtilisateurDAO, pDAO.prenomUtilisateurDAO, pDAO.roleUtilisateurDAO, pDAO.passwordUtilisateurDAO, pDAO.loginUtilisateurDAO);
            return p;
        }

        public static ObservableCollection<UtilisateurViewModel> listeUtilisateurs()
        {
            ObservableCollection<UtilisateurDAO> lDAO = UtilisateurDAO.listeUtilisateurs();
            ObservableCollection<UtilisateurViewModel> l = new ObservableCollection<UtilisateurViewModel>();
            foreach (UtilisateurDAO element in lDAO)
            {
                UtilisateurViewModel p = new UtilisateurViewModel(element.idUtilisateurDAO, element.nomUtilisateurDAO, element.prenomUtilisateurDAO, element.roleUtilisateurDAO, element.passwordUtilisateurDAO, element.loginUtilisateurDAO);
                l.Add(p);
            }
            return l;
        }
        public static void updateUtilisateur(UtilisateurViewModel p)
        {
            UtilisateurDAO.updateUtilisateur(new UtilisateurDAO(p.idUtilisateurProperty, p.nomUtilisateurProperty, p.prenomUtilisateurProperty, p.roleUtilisateurProperty, p.passwordUtilisateurProperty, p.loginUtilisateurProperty));
        }

        public static void supprimerUtilisateur(int id)
        {
            UtilisateurDAO.supprimerUtilisateur(id);
        }

        public static void insertUtilisateur(UtilisateurViewModel p)
        {
            UtilisateurDAO.insertUtilisateur(new UtilisateurDAO(p.idUtilisateurProperty, p.nomUtilisateurProperty, p.prenomUtilisateurProperty, p.roleUtilisateurProperty, p.passwordUtilisateurProperty, p.loginUtilisateurProperty));
        }
    }
}
