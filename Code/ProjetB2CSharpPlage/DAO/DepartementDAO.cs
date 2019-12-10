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

        public static void updateDepartement(DepartementViewModel u)
        {
            DepartementDAL.updateDepartement(new DepartementDAO(u.idDepartementProperty, u.nomDepartementProperty, u.numeroDepartementProperty));
        }

        public static void supprimerDepartement(int idDepartement)
        {
            DepartementDAL.supprimerDepartement(idDepartement);
        }

        public static void insertDepartement(DepartementViewModel u)
        {
            DepartementDAL.insertDepartement(new DepartementDAO(u.idDepartementProperty, u.nomDepartementProperty, u.numeroDepartementProperty));
        }
    }
}
