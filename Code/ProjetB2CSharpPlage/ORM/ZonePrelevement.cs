using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using ProjetB2CSharpPlage.Ctrl;
using ProjetB2CSharpPlage.DAO;

namespace ProjetB2CSharpPlage.ORM
{
    class ZonePrelevementORM
    {
        public static ZonePrelevementViewModel getZonePrelevement(int idZonePrelevement)
        {
            ZonePrelevementDAO pDAO = ZonePrelevementDAO.getZonePrelevements(idZonePrelevement);
            ZonePrelevementViewModel p = new ZonePrelevementViewModel(pDAO.idZonePrelevementDAO, pDAO.nomZonePrelevementDAO, pDAO.lat1DAO, pDAO.lat2DAO, pDAO.lat3DAO, pDAO.lat4DAO, pDAO.long1DAO, pDAO.long2DAO, pDAO.long3DAO, pDAO.long4DAO);
            return p;
        }

        public static ObservableCollection<ZonePrelevementViewModel> listeZonePrelevements()
        {
            ObservableCollection<ZonePrelevementDAO> lDAO = ZonePrelevementDAO.listeZonePrelevements();
            ObservableCollection<ZonePrelevementViewModel> l = new ObservableCollection<ZonePrelevementViewModel>();
            foreach (ZonePrelevementDAO element in lDAO)
            {
                ZonePrelevementViewModel p = new ZonePrelevementViewModel(element.idZonePrelevementDAO, element.nomZonePrelevementDAO, element.lat1DAO, element.lat2DAO, element.lat3DAO, element.lat4DAO, element.long1DAO, element.long2DAO, element.long3DAO, element.long4DAO);
                l.Add(p);
            }
            return l;
        }
    }
}
