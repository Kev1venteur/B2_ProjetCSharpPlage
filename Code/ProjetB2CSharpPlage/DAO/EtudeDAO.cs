using ProjetB2CSharpPlage.DAL;
using System;
using System.Collections.ObjectModel;

namespace ProjetB2CSharpPlage.DAO
{
    public class EtudeDAO
    {
        public int idEtudeDAO;
        public string titreEtudeDAO;
        public int idEquipeEtudeDAO;
        public int nbTotalEspeceRencontreeEtudeDAO;
        public DateTime dateEtudeDAO;

        public EtudeDAO(int idEtudeDAO, DateTime dateEtudeDAO, string titreEtudeDAO, int nbTotalEspeceRencontreeEtudeDAO, int idEquipeEtudeDAO)
        {
            this.idEtudeDAO = idEtudeDAO;
            this.titreEtudeDAO = titreEtudeDAO;
            this.idEquipeEtudeDAO = idEquipeEtudeDAO;
            this.nbTotalEspeceRencontreeEtudeDAO = nbTotalEspeceRencontreeEtudeDAO;
            this.dateEtudeDAO = dateEtudeDAO;
        }

        public static ObservableCollection<EtudeDAO> listeEtudes()
        {
            ObservableCollection<EtudeDAO> l = EtudeDAL.selectEtudes();
            return l;
        }

        public static EtudeDAO getEtude(int idEtude)
        {
            EtudeDAO p = EtudeDAL.getEtude(idEtude);
            return p;
        }

        public static void updateEtude(EtudeDAO et)
        {
            EtudeDAL.updateEtude(et);
        }

        public static void supprimerEtude(int id)
        {
            EtudeDAL.supprimerEtude(id);
        }

        public static void insertEtude(EtudeDAO et)
        {
            EtudeDAL.insertEtude(et);
        }
    }
}
