using ProjetB2CSharpPlage.VM;
using ProjetB2CSharpPlage.DAO;
using System.Collections.ObjectModel;

namespace ProjetB2CSharpPlage.ORM
{
    public class CommuneORM
    {

        public static CommuneViewModel getCommune(int idCommune)
        {
            CommuneDAO pDAO = CommuneDAO.getCommune(idCommune);
            int idDepartement = pDAO.idDepartementCommuneDAO;
            DepartementViewModel m = DepartementORM.getDepartement(idDepartement);
            CommuneViewModel p = new CommuneViewModel(pDAO.idCommuneDAO, pDAO.nomCommuneDAO, m);
            return p;
        }

        public static ObservableCollection<CommuneViewModel> listeCommunes()
        {
            ObservableCollection<CommuneDAO> lDAO = CommuneDAO.listeCommunes();
            ObservableCollection<CommuneViewModel> l = new ObservableCollection<CommuneViewModel>();
            foreach (CommuneDAO element in lDAO)
            {
                int idDepartement = element.idDepartementCommuneDAO;

                DepartementViewModel m = DepartementORM.getDepartement(idDepartement); // Plus propre que d'aller chercher le métier dans la DAO.
                CommuneViewModel p = new CommuneViewModel(element.idCommuneDAO, element.nomCommuneDAO, m);
                l.Add(p);
            }
            return l;
        }
        public static void updateCommune(CommuneViewModel p)
        {
            CommuneDAO.updateCommune(new CommuneDAO(p.idCommuneProperty, p.nomCommuneProperty, p.departementCommune.idDepartementProperty));
        }

        public static void supprimerCommune(int id)
        {
            CommuneDAO.supprimerCommune(id);
        }

        public static void insertCommune(CommuneViewModel p)
        {
            CommuneDAO.insertCommune(new CommuneDAO(p.idCommuneProperty, p.nomCommuneProperty, p.departementCommune.idDepartementProperty));
        }
    }
}
