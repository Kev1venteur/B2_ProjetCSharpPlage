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

        public static void updateEspece(EspeceViewModel u)
        {
            EspeceDAL.updateEspece(new EspeceDAO(u.idEspeceProperty, u.nomEspeceProperty));
        }

        public static void supprimerEspece(int idEspece)
        {
            EspeceDAL.supprimerEspece(idEspece);
        }

        public static void insertEspece(EspeceViewModel u)
        {
            EspeceDAL.insertEspece(new EspeceDAO(u.idEspeceProperty, u.nomEspeceProperty));
        }
    }
}
