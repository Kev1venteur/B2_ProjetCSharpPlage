using ProjetB2CSharpPlage.DAL;
using System.Collections.ObjectModel;

namespace ProjetB2CSharpPlage.DAO
{
    public class EspeceDAO
    {
        public int idEspeceDAO;
        public string nomEspeceDAO;
        public EspeceDAO(int idEspeceDAO, string nomEspeceDAO)
        {
            this.idEspeceDAO = idEspeceDAO;
            this.nomEspeceDAO = nomEspeceDAO;
        }
        public static ObservableCollection<EspeceDAO> listeEspeces()
        {
            ObservableCollection<EspeceDAO> l = EspeceDAL.selectEspeces();
            return l;
        }

        public static EspeceDAO getEspeces(int idEspece)
        {
            EspeceDAO p = EspeceDAL.getEspece(idEspece);
            return p;
        }

        public static void updateEspece(EspeceDAO esp)
        {
            EspeceDAL.updateEspece(esp);
        }

        public static void supprimerEspece(int idEspece)
        {
            EspeceDAL.supprimerEspece(idEspece);
        }

        public static void insertEspece(EspeceDAO esp)
        {
            EspeceDAL.insertEspece(esp);
        }
    }
}
