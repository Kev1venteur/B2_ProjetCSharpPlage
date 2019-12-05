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
    class EquipeORM
    {
        public static EquipeViewModel getEquipe(int idEquipe)
        {
            EquipeDAO pDAO = EquipeDAO.getEquipes(idEquipe);
            EquipeViewModel p = new EquipeViewModel(pDAO.idEquipeDAO, pDAO.nomEquipeDAO, pDAO.nombreMembresEquipeDAO);
            return p;
        }

        public static ObservableCollection<EquipeViewModel> listeEquipes()
        {
            ObservableCollection<EquipeDAO> lDAO = EquipeDAO.listeEquipes();
            ObservableCollection<EquipeViewModel> l = new ObservableCollection<EquipeViewModel>();
            foreach (EquipeDAO element in lDAO)
            {
                EquipeViewModel p = new EquipeViewModel(element.idEquipeDAO, element.nomEquipeDAO, element.nombreMembresEquipeDAO);
                l.Add(p);
            }
            return l;
        }
    }
}
