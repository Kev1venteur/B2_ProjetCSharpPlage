using MySql.Data.MySqlClient;
using ProjetB2CSharpPlage.DAO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetB2CSharpPlage.DAL
{
    class EspeceDAL
    {
        private static MySqlConnection connection;
        public EspeceDAL()
        {
            ConnexionBaseDAL.OpenConnection(); //  si la connexion est déjà ouverte, il ne la refera pas (voir code dans DALConnection)
            connection = ConnexionBaseDAL.connection;
        }
        public static ObservableCollection<EspeceDAO> selectEspeces()
        {
            ObservableCollection<EspeceDAO> l = new ObservableCollection<EspeceDAO>();
            string query = "SELECT * FROM espece;";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.ExecuteNonQuery();

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                EspeceDAO p = new EspeceDAO(reader.GetInt32(0), reader.GetString(1));
                l.Add(p);
            }
            reader.Close();
            return l;
        }
        public static EspeceDAO getEspece(int idEspece)
        {
            string query = "SELECT * FROM espece WHERE idEspece=" + idEspece + ";";
            MySqlCommand cmd = new MySqlCommand(query, ConnexionBaseDAL.connection);
            cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            EspeceDAO espece = new EspeceDAO(reader.GetInt32(0), reader.GetString(1));
            reader.Close();
            return espece;
        }
        public static void updateEspece(EspeceDAO u)
        {
            string query = "UPDATE espece set nom=\"" + u.nomEspeceDAO + ";";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
        public static void insertEspece(EspeceDAO u)
        {
            int id = getMaxIdEspece() + 1;
            string query = "INSERT INTO espece VALUES (\"" + id + "\",\"" + u.nomEspeceDAO + "\");";
            MySqlCommand cmd2 = new MySqlCommand(query, connection);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd2);
            cmd2.ExecuteNonQuery();
        }
        public static int getMaxIdEspece()
        {
            string query = "SELECT IFNULL(MAX(idEspece),0) FROM espece;";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.ExecuteNonQuery();

            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            int maxIdEspece = reader.GetInt32(0);
            reader.Close();
            return maxIdEspece;
        }
        public static void supprimerEspece(int id)
        {
            string query = "DELETE FROM espece WHERE idEspece = \"" + id + "\";";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
    }
}
