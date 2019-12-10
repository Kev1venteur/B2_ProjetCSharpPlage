using ProjetB2CSharpPlage.Ctrl;
using ProjetB2CSharpPlage.DAO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetB2CSharpPlage.ORM
{
    class DepartementORM
    {
        public static DepartementViewModel getDepartement(int idDepartement)
        {
            DepartementDAO pDAO = DepartementDAO.getDepartements(idDepartement);
            DepartementViewModel p = new DepartementViewModel(pDAO.idDepartementDAO, pDAO.nomDepartementDAO, pDAO.numeroDepartementDAO);
            return p;
        }

        public static ObservableCollection<DepartementViewModel> listeDepartements()
        {
            ObservableCollection<DepartementDAO> lDAO = DepartementDAO.listeDepartements();
            ObservableCollection<DepartementViewModel> l = new ObservableCollection<DepartementViewModel>();
            foreach (DepartementDAO element in lDAO)
            {
                DepartementViewModel p = new DepartementViewModel(element.idDepartementDAO, element.nomDepartementDAO, element.numeroDepartementDAO);
                l.Add(p);
            }
            return l;
        }
    }
}
