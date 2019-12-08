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
    class EspeceORM
    {
        public static EspeceViewModel getEspece(int idEspece)
        {
            EspeceDAO pDAO = EspeceDAO.getEspeces(idEspece);
            EspeceViewModel p = new EspeceViewModel(pDAO.idEspeceDAO, pDAO.nomEspeceDAO);
            return p;
        }

        public static ObservableCollection<EspeceViewModel> listeEspeces()
        {
            ObservableCollection<EspeceDAO> lDAO = EspeceDAO.listeEspeces();
            ObservableCollection<EspeceViewModel> l = new ObservableCollection<EspeceViewModel>();
            foreach (EspeceDAO element in lDAO)
            {
                EspeceViewModel p = new EspeceViewModel(element.idEspeceDAO, element.nomEspeceDAO);
                l.Add(p);
            }
            return l;
        }
    }
}
