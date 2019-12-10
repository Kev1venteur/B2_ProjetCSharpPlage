using ProjetB2CSharpPlage.DAL;
using System.Collections.ObjectModel;

namespace ProjetB2CSharpPlage.DAO
{
    public class CommuneDAO
    {
        public int idCommuneDAO;
        public string nomCommuneDAO;
        public int idDepartementCommuneDAO;

        public CommuneDAO(int idCommuneDAO, string nomCommuneDAO, int idDepartementCommuneDAO)
        {
            this.idCommuneDAO = idCommuneDAO;
            this.nomCommuneDAO = nomCommuneDAO;
            this.idDepartementCommuneDAO = idDepartementCommuneDAO;
        }

        public static ObservableCollection<CommuneDAO> listeCommunes()
        {
            ObservableCollection<CommuneDAO> l = CommuneDAL.selectCommunes();
            return l;
        }

        public static CommuneDAO getCommune(int idCommune)
        {
            CommuneDAO p = CommuneDAL.getCommune(idCommune);
            return p;
        }

        public static void updateCommune(CommuneDAO c)
        {
            CommuneDAL.updateCommune(c);
        }

        public static void supprimerCommune(int id)
        {
            CommuneDAL.supprimerCommune(id);
        }

        public static void insertCommune(CommuneDAO c)
        {
            CommuneDAL.insertCommune(c);
        }
    }
}
