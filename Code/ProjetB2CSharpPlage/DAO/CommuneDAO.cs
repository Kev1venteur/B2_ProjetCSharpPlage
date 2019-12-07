using ProjetB2CSharpPlage.Ctrl;
using ProjetB2CSharpPlage.DAL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public static void updateCommune(CommuneViewModel p)
        {
            CommuneDAL.updateCommune(new CommuneDAO(p.idCommuneProperty, p.nomCommuneProperty, p.departementCommune.idDepartementProperty));
        }

        public static void supprimerCommune(int id)
        {
            CommuneDAL.supprimerCommune(id);
        }

        public static void insertCommune(CommuneViewModel p)
        {
            CommuneDAL.insertCommune(new CommuneDAO(p.idCommuneProperty, p.nomCommuneProperty, p.departementCommune.idDepartementProperty));
        }
    }
}
