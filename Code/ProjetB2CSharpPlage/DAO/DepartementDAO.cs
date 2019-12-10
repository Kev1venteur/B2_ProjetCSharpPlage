using ProjetB2CSharpPlage.DAL;
using System.Collections.ObjectModel;

namespace ProjetB2CSharpPlage.DAO
{
    public class DepartementDAO
    {
        public int idDepartementDAO;
        public string nomDepartementDAO;
        public int numeroDepartementDAO;
        public DepartementDAO(int idDepartementDAO, string nomDepartementDAO, int numeroDepartementDAO)
        {
            this.idDepartementDAO = idDepartementDAO;
            this.nomDepartementDAO = nomDepartementDAO;
            this.numeroDepartementDAO = numeroDepartementDAO;
        }
        public static ObservableCollection<DepartementDAO> listeDepartements()
        {
            ObservableCollection<DepartementDAO> l = DepartementDAL.selectDepartements();
            return l;
        }

        public static DepartementDAO getDepartements(int idDepartement)
        {
            DepartementDAO p = DepartementDAL.getDepartement(idDepartement);
            return p;
        }

        public static void updateDepartement(DepartementDAO dp)
        {
            DepartementDAL.updateDepartement(dp);
        }

        public static void supprimerDepartement(int idDepartement)
        {
            DepartementDAL.supprimerDepartement(idDepartement);
        }

        public static void insertDepartement(DepartementDAO dp)
        {
            DepartementDAL.insertDepartement(dp);
        }
    }
}
