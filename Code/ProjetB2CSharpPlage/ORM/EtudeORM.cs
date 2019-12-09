using ProjetB2CSharpEtude.Ctrl;
using ProjetB2CSharpEtude.DAO;
using ProjetB2CSharpPlage.Ctrl;
using ProjetB2CSharpPlage.ORM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetB2CSharpEtude.ORM
{
    public class EtudeORM
    {

        public static EtudeViewModel getEtude(int idEtude)
        {
            EtudeDAO pDAO = EtudeDAO.getEtude(idEtude);
            int idEquipe = pDAO.idEquipeEtudeDAO;
            EquipeViewModel m = EquipeORM.getEquipe(idEquipe);
            EtudeViewModel p = new EtudeViewModel(pDAO.idEtudeDAO, pDAO.dateEtudeDAO, pDAO.titreEtudeDAO, pDAO.nbTotalEspeceRencontreeEtudeDAO, m);
            return p;
        }

        public static ObservableCollection<EtudeViewModel> listeEtudes()
        {
            ObservableCollection<EtudeDAO> lDAO = EtudeDAO.listeEtudes();
            ObservableCollection<EtudeViewModel> l = new ObservableCollection<EtudeViewModel>();
            foreach (EtudeDAO element in lDAO)
            {
                int idEquipe = element.idEquipeEtudeDAO;

                EquipeViewModel m = EquipeORM.getEquipe(idEquipe); // Plus propre que d'aller chercher le métier dans la DAO.
                EtudeViewModel p = new EtudeViewModel(element.idEtudeDAO, element.dateEtudeDAO, element.titreEtudeDAO, element.nbTotalEspeceRencontreeEtudeDAO, m);
                l.Add(p);
            }
            return l;
        }
    }
}
