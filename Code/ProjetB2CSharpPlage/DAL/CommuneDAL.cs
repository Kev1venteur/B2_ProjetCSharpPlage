using MySql.Data.MySqlClient;
using ProjetB2CSharpPlage.DAO;
using System.Collections.ObjectModel;

namespace ProjetB2CSharpPlage.DAL
{
    public class CommuneDAL
    {
        public static ObservableCollection<CommuneDAO> selectCommunes()
        {
            ObservableCollection<CommuneDAO> l = new ObservableCollection<CommuneDAO>();
            string query = "SELECT * FROM commune;";
            MySqlCommand cmd = new MySqlCommand(query, ConnexionBaseDAL.connection);
            cmd.ExecuteNonQuery();

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                CommuneDAO p = new CommuneDAO(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2));
                l.Add(p);
            }
            reader.Close();
            return l;
        }

        public static void updateCommune(CommuneDAO p)
        {
            if(p.idCommuneDAO != 1)
            {
                string query = "UPDATE commune set nom=\"" + p.nomCommuneDAO + "\", idDepartement=\"" + p.idDepartementCommuneDAO + "\" where idCommune=" + p.idCommuneDAO + ";";
                MySqlCommand cmd = new MySqlCommand(query, ConnexionBaseDAL.connection);
                MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
                cmd.ExecuteNonQuery();
            }
        }
        public static void insertCommune(CommuneDAO p)
        {
            int id = getMaxIdCommune() + 1;
            string query = "INSERT INTO commune VALUES (\"" + id + "\",\"" + p.nomCommuneDAO + "\",\"" + p.idDepartementCommuneDAO + "\");";
            MySqlCommand cmd2 = new MySqlCommand(query, ConnexionBaseDAL.connection);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd2);
            cmd2.ExecuteNonQuery();
        }
        public static void supprimerCommune(int id)
        {
            if (id != 1)
            {
                string query = "DELETE FROM commune WHERE idCommune = \"" + id + "\";";
                MySqlCommand cmd = new MySqlCommand(query, ConnexionBaseDAL.connection);
                MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
                cmd.ExecuteNonQuery();
            }
        }
        public static int getMaxIdCommune()
        {   /*IFNULL permet de retourner une valeur par défaut si la ligne n'éxiste pas dans la base*/
            string query = "SELECT IFNULL(MAX(idCommune),0) FROM commune;";
            MySqlCommand cmd = new MySqlCommand(query, ConnexionBaseDAL.connection);
            cmd.ExecuteNonQuery();

            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            int maxIdCommune = reader.GetInt32(0);
            reader.Close();
            return maxIdCommune;
        }

        public static CommuneDAO getCommune(int idCommune)
        {
            string query = "SELECT * FROM commune WHERE idCommune=" + idCommune + ";";
            MySqlCommand cmd = new MySqlCommand(query, ConnexionBaseDAL.connection);
            cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            CommuneDAO com;
            if (reader.HasRows)
            {
                com = new CommuneDAO(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2));
            }
            else
            {
                com = new CommuneDAO(1, "Mauvais Num Commune", 1);
            }
            reader.Close();
            return com;
        }
    }
}
