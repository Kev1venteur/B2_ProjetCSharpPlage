using MySql.Data.MySqlClient;
using System.Collections.ObjectModel;
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
            string query = "SELECT * FROM departement;";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.ExecuteNonQuery();

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                DepartementDAO p = new DepartementDAO(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2));
                l.Add(p);
            }
            reader.Close();
            return l;
        }
        public static DepartementDAO getDepartement(int idDepartement)
        {
            string query = "SELECT * FROM departement WHERE idDepartement=" + idDepartement + ";";
            MySqlCommand cmd = new MySqlCommand(query, ConnexionBaseDAL.connection);
            cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            DepartementDAO departement;
            if (reader.HasRows)
            {
                departement = new DepartementDAO(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2));
            }
            else
            {
                departement = new DepartementDAO(1, "MauvaisNumeroDepartement", 0);
            }
            reader.Close();
            return departement;
        }
        public static void updateDepartement(DepartementDAO u)
        {
            string query = "UPDATE departement set nom=\"" + u.nomDepartementDAO + "\", numero=\"" + u.nomDepartementDAO + ";";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
        public static void insertDepartement(DepartementDAO u)
        {
            int id = getMaxIdDepartement() + 1;
            string query = "INSERT INTO departement VALUES (\"" + id + "\",\"" + u.nomDepartementDAO + "\",\"" + u.numeroDepartementDAO + "\");";
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
