using MySql.Data.MySqlClient;
using System.Collections.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetB2CSharpPlage.DAL;
using ProjetB2CSharpPlage.DAO;
using System.Threading;
using System.Globalization;

namespace ProjetB2CSharpPlage.DAL
{
    class ZonePrelevementDAL
    {
        private static MySqlConnection connection;
        public ZonePrelevementDAL()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");
            ConnexionBaseDAL.OpenConnection(); //  si la connexion est déjà ouverte, il ne la refera pas (voir code dans DALConnection)
            connection = ConnexionBaseDAL.connection;
        }
        public static ObservableCollection<ZonePrelevementDAO> selectZonePrelevements()
        {
            ObservableCollection<ZonePrelevementDAO> l = new ObservableCollection<ZonePrelevementDAO>();
            string query = "SELECT * FROM zoneprelevement;";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.ExecuteNonQuery();

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                ZonePrelevementDAO p = new ZonePrelevementDAO(reader.GetInt32(0), reader.GetString(1), reader.GetDecimal(2), reader.GetDecimal(3), reader.GetDecimal(4), reader.GetDecimal(5), reader.GetDecimal(6), reader.GetDecimal(7), reader.GetDecimal(8), reader.GetDecimal(9));
                l.Add(p);
            }
            reader.Close();
            return l;
        }
        public static ZonePrelevementDAO getZonePrelevement(int idZonePrelevement)
        {
            string query = "SELECT * FROM zoneprelevement WHERE idZonePrelevement=" + idZonePrelevement + ";";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            ZonePrelevementDAO user = new ZonePrelevementDAO(reader.GetInt32(0), reader.GetString(1), reader.GetDecimal(2), reader.GetDecimal(3), reader.GetDecimal(4), reader.GetDecimal(5), reader.GetDecimal(6), reader.GetDecimal(7), reader.GetDecimal(8), reader.GetDecimal(9));
            reader.Close();
            return user;
        }
        public static void updateZonePrelevement(ZonePrelevementDAO u)
        {
            string query = "UPDATE zoneprelevement set nom=\"" + u.nomZonePrelevementDAO + "\", lat1=\"" + u.lat1DAO + "\", lat2=\"" + u.lat2DAO + "\", lat3=\"" + u.lat3DAO + "\", lat4=\"" + u.lat4DAO + "\", long1=\"" + u.long1DAO + "\", long2=\"" + u.long2DAO + "\", long3=\"" + u.long3DAO + "\", long4=\"" + u.long4DAO + "\" where idZonePrelevement=" + u.idZonePrelevementDAO + ";";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
        public static void insertZonePrelevement(ZonePrelevementDAO u)
        {
            int id = getMaxIdZonePrelevement() + 1;
            string query = "INSERT INTO zoneprelevement VALUES (\"" + id + "\",\"" + u.nomZonePrelevementDAO + "\",\"" + u.lat1DAO + "\",\"" + u.lat2DAO + "\",\"" + u.lat3DAO + "\",\"" + u.lat4DAO + "\",\"" + u.long1DAO + "\",\"" + u.long2DAO + "\",\"" + u.long3DAO + "\",\"" + u.long4DAO + "\");";
            MySqlCommand cmd2 = new MySqlCommand(query, connection);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd2);
            cmd2.ExecuteNonQuery();
        }
        public static int getMaxIdZonePrelevement()
        {
            string query = "SELECT IFNULL(MAX(idZonePrelevement),0) FROM zoneprelevement;";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.ExecuteNonQuery();

            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            int maxIdZonePrelevement = reader.GetInt32(0);
            reader.Close();
            return maxIdZonePrelevement;
        }
        public static void supprimerZonePrelevement(int id)
        {
            string query = "DELETE FROM zoneprelevement WHERE idZonePrelevement = \"" + id + "\";";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
    }
}
