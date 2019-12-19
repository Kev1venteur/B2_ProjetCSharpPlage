using ProjetB2CSharpPlage.DAO;
using ProjetB2CSharpPlage.VM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetB2CSharpPlage.ORM
{
    class UtilisateurHasEquipeORM
    {
        //public static UtilisateurHasEquipeViewModel getUtilisateurHasEquipeByEquipe(int idEquipe)
        //{
        //    UtilisateurHasEquipeDAO uDAO = UtilisateurHasEquipeDAO.getUtilisateurHasEquipeByEquipe(idEquipe);
        //    UtilisateurHasEquipeViewModel u = new UtilisateurHasEquipeViewModel(uDAO.Utilisateur_idUtilisateurDAO, uDAO.Equipe_idEquipeDAO);
        //    return u;
        //}
        public static UtilisateurHasEquipeViewModel getUtilisateurHasEquipe(int idUtilisateur, int idEquipe)
        {
            UtilisateurHasEquipeDAO uDAO = UtilisateurHasEquipeDAO.getUtilisateurHasEquipe(idUtilisateur, idEquipe);

            int Utilisateur_idUtilisateur = uDAO.Utilisateur_idUtilisateurDAO;
            UtilisateurViewModel u = UtilisateurORM.getUtilisateur(Utilisateur_idUtilisateur);

            int Equipe_idEquipe = uDAO.Equipe_idEquipeDAO;
            EquipeViewModel e = EquipeORM.getEquipe(Equipe_idEquipe);

            UtilisateurHasEquipeViewModel ue = new UtilisateurHasEquipeViewModel(u, e);
            return ue;
        }

        public static ObservableCollection<UtilisateurHasEquipeViewModel> listeUtilisateurHasEquipes()
        {
            ObservableCollection<UtilisateurHasEquipeDAO> lDAO = UtilisateurHasEquipeDAO.listeUtilisateurHasEquipes();
            ObservableCollection<UtilisateurHasEquipeViewModel> l = new ObservableCollection<UtilisateurHasEquipeViewModel>();
            foreach (UtilisateurHasEquipeDAO element in lDAO)
            {

                int Utilisateur_idUtilisateur = element.Utilisateur_idUtilisateurDAO;
                UtilisateurViewModel u = UtilisateurORM.getUtilisateur(Utilisateur_idUtilisateur);

                int Equipe_idEquipe = element.Equipe_idEquipeDAO;
                EquipeViewModel e = EquipeORM.getEquipe(Equipe_idEquipe);

                UtilisateurHasEquipeViewModel ue = new UtilisateurHasEquipeViewModel(u, e);
                l.Add(ue);
            }
            return l;
        }
        //public static void updateUtilisateurHasEquipe(UtilisateurHasEquipeViewModel ue)
        //{
        //    UtilisateurHasEquipeDAO.updateUtilisateurHasEquipe(new UtilisateurHasEquipeDAO(ue.Utilisateur_UtilisateurHasEquipeProperty, ue.Equipe_UtilisateurHasEquipeProperty));
        //}

        public static void supprimerUtilisateurHasEquipe(int idUtilisateur, int idEquipe)
        {
            UtilisateurHasEquipeDAO.supprimerUtilisateurHasEquipe(idUtilisateur, idEquipe);
        }
        public static void insertUtilisateurHasEquipe(UtilisateurHasEquipeViewModel ue)
        {
            UtilisateurHasEquipeDAO.insertUtilisateurHasEquipe(new UtilisateurHasEquipeDAO(ue.Utilisateur_UtilisateurHasEquipeProperty.idUtilisateurProperty, ue.Equipe_UtilisateurHasEquipeProperty.idEquipeProperty));
        }
    }
}
