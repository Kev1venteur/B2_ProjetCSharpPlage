using ProjetB2CSharpEtude.Ctrl;
using ProjetB2CSharpEtude.DAL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetB2CSharpEtude.DAO
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

        public static void updateEtude(EtudeViewModel p)
        {
            EtudeDAL.updateEtude(new EtudeDAO(p.idEtudeProperty, p.dateEtudeProperty, p.titreEtudeProperty, p.nbTotalEspeceRencontreeEtudeProperty, p.equipeEtude.idEquipeProperty));
        }

        public static void supprimerEtude(int id)
        {
            EtudeDAL.supprimerEtude(id);
        }

        public static void insertEtude(EtudeViewModel p)
        {
            EtudeDAL.insertEtude(new EtudeDAO(p.idEtudeProperty, p.dateEtudeProperty, p.titreEtudeProperty, p.nbTotalEspeceRencontreeEtudeProperty, p.equipeEtude.idEquipeProperty));
        }
    }
}
