using ProjetB2CSharpPlage.DAL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetB2CSharpPlage.DAO
{
    public class UtilisateurHasEquipeDAO
    {
        public int Utilisateur_idUtilisateurDAO;
        public int Equipe_idEquipeDAO;
        //public int UtilisateurUpdate_idUtilisateurDAO;       
        //public int EquipeUpdate_idEquipeDAO;

        public UtilisateurHasEquipeDAO(int idUtilisateur, int idEquipe)
        {
            this.Utilisateur_idUtilisateurDAO = idUtilisateur;
            this.Equipe_idEquipeDAO = idEquipe;
        }

        //public UtilisateurHasEquipeDAO(int idUtilisateur, int idEquipe, int idUtilisateurUpdate, int idEquipeUpdate)
        //{
        //    this.Utilisateur_idUtilisateurDAO = idUtilisateur;
        //    this.Equipe_idEquipeDAO = idEquipe;
        //    this.UtilisateurUpdate_idUtilisateurDAO = idUtilisateurUpdate;
        //    this.EquipeUpdate_idEquipeDAO = idEquipeUpdate;
        //}

        //////?
        public static ObservableCollection<UtilisateurHasEquipeDAO> listeUtilisateurHasEquipes()
        {
            ObservableCollection<UtilisateurHasEquipeDAO> l = UtilisateurHasEquipeDAL.selectUtilisateurHasEquipes();
            return l;
        }
        //////
        //public static UtilisateurHasEquipeDAO getUtilisateurHasEquipeByEquipe(int idEquipe)
        //{
        //    UtilisateurHasEquipeDAO u = UtilisateurHasEquipeDAL.getUtilisateurHasEquipeByEquipe(idEquipe);
        //    return u;
        //}
        public static UtilisateurHasEquipeDAO getUtilisateurHasEquipe(int idUtilisateur, int idEquipe)
        {
            UtilisateurHasEquipeDAO u = UtilisateurHasEquipeDAL.getUtilisateurHasEquipe(idUtilisateur, idEquipe);
            return u;
        }

        //pas de update clés primaires

        //public static void updateUtilisateur(UtilisateurHasEquipeDAO u)
        //{
        //    UtilisateurDAL.updateUtilisateur(u);
        //}

        public static void supprimerUtilisateurHasEquipe(int idUtilisateur, int idEquipe)
        {
            UtilisateurHasEquipeDAL.supprimerUtilisateurHasEquipe(idUtilisateur, idEquipe);
        }

        public static void insertUtilisateurHasEquipe(UtilisateurHasEquipeDAO u)
        {
            UtilisateurHasEquipeDAL.insertUtilisateurHasEquipe(u);
        }
    }
}
