using ProjetB2CSharpPlage.VM;
using ProjetB2CSharpPlage.DAO;
using System.Collections.ObjectModel;

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
        public static void updateEquipe(EquipeViewModel p)
        {
            EquipeDAO.updateEquipe(new EquipeDAO(p.idEquipeProperty, p.nomEquipeProperty, p.nombreMembresEquipeProperty));
        }

        public static void supprimerEquipe(int id)
        {
            EquipeDAO.supprimerEquipe(id);
        }

        public static void insertEquipe(EquipeViewModel p)
        {
            EquipeDAO.insertEquipe(new EquipeDAO(p.idEquipeProperty, p.nomEquipeProperty, p.nombreMembresEquipeProperty));
        }
    }
}
