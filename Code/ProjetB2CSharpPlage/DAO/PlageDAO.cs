using ProjetB2CSharpPlage.DAL;
using System.Collections.ObjectModel;

namespace ProjetB2CSharpPlage.DAO
{
    public class PlageDAO
    {
        public int idPlageDAO;
        public string nomPlageDAO;
        public int idCommunePlageDAO;
        public int nbEspecesDifferentesPlageDAO;
        public float surfacePlageDAO;

        public PlageDAO(int idPlageDAO, string nomPlageDAO, int idCommunePlageDAO, int nbEspecesDifferentesPlageDAO, float surfacePlageDAO)
        {
            this.idPlageDAO = idPlageDAO;
            this.nomPlageDAO = nomPlageDAO;
            this.idCommunePlageDAO = idCommunePlageDAO;
            this.nbEspecesDifferentesPlageDAO = nbEspecesDifferentesPlageDAO;
            this.surfacePlageDAO = surfacePlageDAO;
        }

        public static ObservableCollection<PlageDAO> listePlages()
        {
            ObservableCollection<PlageDAO> l = PlageDAL.selectPlages();
            return l;
        }

        public static PlageDAO getPlage(int idPlage)
        {
            PlageDAO p = PlageDAL.getPlage(idPlage);
            return p;
        }

        public static void updatePlage(PlageDAO p)
        {
            PlageDAL.updatePlage(p);
        }

        public static void supprimerPlage(int id)
        {
            PlageDAL.supprimerPlage(id);
        }

        public static void insertPlage(PlageDAO p)
        {
            PlageDAL.insertPlage(p);
        }
    }
}
