using MySql.Data.MySqlClient;
using ProjetB2CSharpPlage.DAO;
using System.Collections.ObjectModel;

namespace ProjetB2CSharpPlage.DAL
{
    public class PlageDAL
    {
        private static MySqlConnection connection;
        public PlageDAL()
        {
            ConnexionBaseDAL.OpenConnection(); //  si la connexion est déjà ouverte, il ne la refera pas (voir code dans DALConnection)
            connection = ConnexionBaseDAL.connection;
        }

        public static ObservableCollection<PlageDAO> selectPlages()
        {
            ObservableCollection<PlageDAO> l = new ObservableCollection<PlageDAO>();
            string query = "SELECT * FROM plage;";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.ExecuteNonQuery();

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                PlageDAO p = new PlageDAO(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2), reader.GetInt32(3), reader.GetFloat(4));
                l.Add(p);
            }
            reader.Close();
            return l;
        }

        public static void updatePlage(PlageDAO p)
        {
            string query = "UPDATE plage set nom=\"" + p.nomPlageDAO + "\", idCommune=\"" + p.idCommunePlageDAO + "\", nbEspecesDifferentes=\"" + p.nbEspecesDifferentesPlageDAO + "\", surface=\"" + p.surfacePlageDAO + "\" where idPlage=" + p.idPlageDAO + ";";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
        public static void insertPlage(PlageDAO p)
        {
            int id = getMaxIdPlage() + 1;
            string query = "INSERT INTO Plage VALUES (\"" + id + "\",\"" + p.nomPlageDAO + "\",\"" + p.idCommunePlageDAO + "\",\"" + p.nbEspecesDifferentesPlageDAO + "\",\"" + p.surfacePlageDAO + "\");";
            MySqlCommand cmd2 = new MySqlCommand(query, connection);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd2);
            cmd2.ExecuteNonQuery();
        }
        public static void supprimerPlage(int id)
        {
            string query = "DELETE FROM plage WHERE idPlage = \"" + id + "\";";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
        public static int getMaxIdPlage()
        {
            string query = "SELECT IFNULL(MAX(idPlage),0) FROM plage;";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.ExecuteNonQuery();

            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            int maxIdPlage = reader.GetInt32(0);
            reader.Close();
            return maxIdPlage;
        }

        public static PlageDAO getPlage(int idPlage)
        {
            string query = "SELECT * FROM Plage WHERE id=" + idPlage + ";";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            PlageDAO pers;
            if (reader.HasRows)
            {
                pers = new PlageDAO(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2), reader.GetInt32(3), reader.GetFloat(4));
            }
            else
            {
                pers = new PlageDAO(1, "MauvaisNumeroPlage", 1, 0, 0);
            }
            reader.Close();
            return pers;
        }
    }
}
