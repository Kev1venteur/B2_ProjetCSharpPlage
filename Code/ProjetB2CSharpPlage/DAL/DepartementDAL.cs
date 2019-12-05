using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetB2CSharpPlage.DAO;

namespace ProjetB2CSharpPlage.DAL
{
    class DepartementDAL
    {
        private static MySqlConnection connection;
        public DepartementDAL()
        {
            ConnexionBaseDAL.OpenConnection(); //  si la connexion est déjà ouverte, il ne la refera pas (voir code dans DALConnection)
            connection = ConnexionBaseDAL.connection;
        }
        public static ObservableCollection<DepartementDAO> selectDepartements()
        {
            ObservableCollection<DepartementDAO> l = new ObservableCollection<DepartementDAO>();
            string query = "SELECT * FROM Departement;";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.ExecuteNonQuery();

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                DepartementDAO p = new DepartementDAO(reader.GetInt32(0), reader.GetString(1));
                l.Add(p);
            }
            reader.Close();
            return l;
        }
        public static DepartementDAO getDepartement(int idDepartement)
        {
            string query = "SELECT * FROM departement WHERE idDepartement=" + idDepartement + ";";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            DepartementDAO user = new DepartementDAO(reader.GetInt32(0), reader.GetString(1));
            reader.Close();
            return user;
        }
        public static void updateDepartement(DepartementDAO u)
        {
            string query = "UPDATE departement set nom=\"" + u.nomDepartementDAO + ";";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
        public static void insertDepartement(DepartementDAO u)
        {
            int id = getMaxIdDepartement() + 1;
            string query = "INSERT INTO departement VALUES (\"" + id + "\",\"" + u.nomDepartementDAO + "\");";
            MySqlCommand cmd2 = new MySqlCommand(query, connection);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd2);
            cmd2.ExecuteNonQuery();
        }
        public static int getMaxIdDepartement()
        {
            string query = "SELECT IFNULL(MAX(idDepartement),0) FROM departement;";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.ExecuteNonQuery();

            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            int maxIdDepartement = reader.GetInt32(0);
            reader.Close();
            return maxIdDepartement;
        }
        public static void supprimerDepartement(int id)
        {
            string query = "DELETE FROM departement WHERE idDepartement = \"" + id + "\";";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
    }
}
