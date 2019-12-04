using ProjetB2CSharpPlage.Ctrl;
using ProjetB2CSharpPlage.DAL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProjetB2CSharpPlage.DAO
{
    class ZonePrelevementDAO
    {
        public int idZonePrelevementDAO;
        public string nomZonePrelevementDAO;
        public Decimal lat1DAO;
        public Decimal lat2DAO;
        public Decimal lat3DAO;
        public Decimal lat4DAO;
        public Decimal long1DAO;
        public Decimal long2DAO;
        public Decimal long3DAO;
        public Decimal long4DAO;
        public ZonePrelevementDAO(int idZonePrelevementDAO, string nomZonePrelevementDAO, Decimal lat1DAO, Decimal lat2DAO, Decimal lat3DAO, Decimal lat4DAO, Decimal long1DAO, Decimal long2DAO, Decimal long3DAO, Decimal long4DAO)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");
            this.idZonePrelevementDAO = idZonePrelevementDAO;
            this.nomZonePrelevementDAO = nomZonePrelevementDAO;
            this.lat1DAO = lat1DAO;
            this.lat2DAO = lat2DAO;
            this.lat3DAO = lat3DAO;
            this.lat4DAO = lat4DAO;
            this.long1DAO = long1DAO;
            this.long2DAO = long2DAO;
            this.long3DAO = long3DAO;
            this.long4DAO = long4DAO;
        }
        public static ObservableCollection<ZonePrelevementDAO> listeZonePrelevements()
        {
            ObservableCollection<ZonePrelevementDAO> l = ZonePrelevementDAL.selectZonePrelevements();
            return l;
        }

        public static ZonePrelevementDAO getZonePrelevements(int idZonePrelevement)
        {
            ZonePrelevementDAO p = ZonePrelevementDAL.getZonePrelevement(idZonePrelevement);
            return p;
        }

        public static void updateZonePrelevement(ZonePrelevementViewModel u)
        {
            ZonePrelevementDAL.updateZonePrelevement(new ZonePrelevementDAO(u.idZonePrelevementProperty, u.nomZonePrelevementProperty, u.lat1Property, u.lat2Property, u.lat3Property, u.lat4Property, u.long1Property, u.long2Property, u.long3Property, u.long4Property));
        }

        public static void supprimerZonePrelevement(int id)
        {
            ZonePrelevementDAL.supprimerZonePrelevement(id);
        }

        public static void insertZonePrelevement(ZonePrelevementViewModel u)
        {
            ZonePrelevementDAL.insertZonePrelevement(new ZonePrelevementDAO(u.idZonePrelevementProperty, u.nomZonePrelevementProperty, u.lat1Property, u.lat2Property, u.lat3Property, u.lat4Property, u.long1Property, u.long2Property, u.long3Property, u.long4Property));
        }
    }
}
