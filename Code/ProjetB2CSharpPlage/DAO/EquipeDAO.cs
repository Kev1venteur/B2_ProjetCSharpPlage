using ProjetB2CSharpPlage.DAL;
using System.Collections.ObjectModel;

namespace ProjetB2CSharpPlage.DAO
{
    public class EquipeDAO
    {
        public int idEquipeDAO;
        public string nomEquipeDAO;
        public int nombreMembresEquipeDAO;
        public EquipeDAO(int idEquipeDAO, string nomEquipeDAO, int nombreMembresEquipeDAO)
        {
            this.idEquipeDAO = idEquipeDAO;
            this.nomEquipeDAO = nomEquipeDAO;
            this.nombreMembresEquipeDAO = nombreMembresEquipeDAO;
        }
        public static ObservableCollection<EquipeDAO> listeEquipes()
        {
            ObservableCollection<EquipeDAO> l = EquipeDAL.selectEquipes();
            return l;
        }

        public static EquipeDAO getEquipes(int idEquipe)
        {
            EquipeDAO p = EquipeDAL.getEquipe(idEquipe);
            return p;
        }

        public static void updateEquipe(EquipeDAO eq)
        {
            EquipeDAL.updateEquipe(eq);
        }

        public static void supprimerEquipe(int idEquipe)
        {
            EquipeDAL.supprimerEquipe(idEquipe);
        }

        public static void insertEquipe(EquipeDAO eq)
        {
            EquipeDAL.insertEquipe(eq);
        }
    }
}
