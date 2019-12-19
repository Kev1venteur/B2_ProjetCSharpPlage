using System.Collections.ObjectModel;
using ProjetB2CSharpPlage.VM;
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
        public static void updateZonePrelevement(ZonePrelevementViewModel zp)
        {
            ZonePrelevementDAO.updateZonePrelevement(new ZonePrelevementDAO(zp.idZonePrelevementProperty, zp.nomZonePrelevementProperty, zp.lat1Property, zp.lat2Property, zp.lat3Property, zp.lat4Property, zp.long1Property, zp.long2Property, zp.long3Property,zp.long4Property));
        }

        public static void supprimerZonePrelevement(int id)
        {
            ZonePrelevementDAO.supprimerZonePrelevement(id);
        }

        public static void insertZonePrelevement(ZonePrelevementViewModel zp)
        {
            ZonePrelevementDAO.insertZonePrelevement(new ZonePrelevementDAO(zp.idZonePrelevementProperty, zp.nomZonePrelevementProperty, zp.lat1Property, zp.lat2Property, zp.lat3Property, zp.lat4Property, zp.long1Property, zp.long2Property, zp.long3Property, zp.long4Property));
        }
    }
}
