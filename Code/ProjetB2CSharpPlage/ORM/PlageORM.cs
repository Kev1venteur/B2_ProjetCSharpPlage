using ProjetB2CSharpPlage.Ctrl;
using ProjetB2CSharpPlage.DAO;
using System.Collections.ObjectModel;

namespace ProjetB2CSharpPlage.ORM
{
    public class PlageORM
    {

        public static PlageViewModel getPlage(int idPlage)
        {
            PlageDAO pDAO = PlageDAO.getPlage(idPlage);
            int idCommune = pDAO.idCommunePlageDAO;
            CommuneViewModel m = CommuneORM.getCommune(idCommune);
            PlageViewModel p = new PlageViewModel(pDAO.idPlageDAO, pDAO.nomPlageDAO, m, pDAO.nbEspecesDifferentesPlageDAO, pDAO.surfacePlageDAO);
            return p;
        }

        public static ObservableCollection<PlageViewModel> listePlages()
        {
            ObservableCollection<PlageDAO> lDAO = PlageDAO.listePlages();
            ObservableCollection<PlageViewModel> l = new ObservableCollection<PlageViewModel>();
            foreach (PlageDAO element in lDAO)
            {
                int idCommune = element.idCommunePlageDAO;

                CommuneViewModel m = CommuneORM.getCommune(idCommune); // Plus propre que d'aller chercher le métier dans la DAO.
                PlageViewModel p = new PlageViewModel(element.idPlageDAO, element.nomPlageDAO, m, element.nbEspecesDifferentesPlageDAO, element.surfacePlageDAO);
                l.Add(p);
            }
            return l;
        }
        public static void updatePlage(PlageViewModel p)
        {
            PlageDAO.updatePlage(new PlageDAO(p.idPlageProperty, p.nomPlageProperty, p.communePlage.idCommuneProperty, p.nbEspecesDifferentesPlageProperty, p.surfacePlageProperty));
        }

        public static void supprimerPlage(int id)
        {
            PlageDAO.supprimerPlage(id);
        }

        public static void insertPlage(PlageViewModel p)
        {
            PlageDAO.insertPlage(new PlageDAO(p.idPlageProperty, p.nomPlageProperty, p.communePlage.idCommuneProperty, p.nbEspecesDifferentesPlageProperty, p.surfacePlageProperty));
        }
    }
}
