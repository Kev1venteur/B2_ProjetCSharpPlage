using MySql.Data.MySqlClient;
using ProjetB2CSharpPlage.DAO;
using System.Collections.ObjectModel;

namespace ProjetB2CSharpPlage.DAL
{
    class EquipeDAL
    {
        public static ObservableCollection<EquipeDAO> selectEquipes()
        {
            ObservableCollection<EquipeDAO> l = new ObservableCollection<EquipeDAO>();
            string query = "SELECT * FROM equipe;";
            MySqlCommand cmd = new MySqlCommand(query, ConnexionBaseDAL.connection);
            cmd.ExecuteNonQuery();

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                EquipeDAO p = new EquipeDAO(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2));
                l.Add(p);
            }
            reader.Close();
            return l;
        }
        public static EquipeDAO getEquipe(int idEquipe)
        {
            string query = "SELECT * FROM equipe WHERE idEquipe=" + idEquipe + ";";
            MySqlCommand cmd = new MySqlCommand(query, ConnexionBaseDAL.connection);
            cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            EquipeDAO equip;
            if (reader.HasRows)
            {
                equip = new EquipeDAO(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2));
            }
            else
            {
                equip = new EquipeDAO(1, "MauvaisNumeroEquipe", 0);
            }
            reader.Close();
            return equip;
        }
        public static void updateEquipe(EquipeDAO u)
        {
            string query = "UPDATE equipe set nom=\"" + u.nomEquipeDAO + "\", nombreMembres=\"" + u.nombreMembresEquipeDAO + "\" where idEquipe=" + u.idEquipeDAO + ";";
            MySqlCommand cmd = new MySqlCommand(query, ConnexionBaseDAL.connection);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
        public static void insertEquipe(EquipeDAO u)
        {
            int id = getMaxIdEquipe() + 1;
            string query = "INSERT INTO equipe VALUES (\"" + id + "\",\"" + u.nomEquipeDAO + "\",\"" + u.nombreMembresEquipeDAO + "\");";
            MySqlCommand cmd2 = new MySqlCommand(query, ConnexionBaseDAL.connection);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd2);
            cmd2.ExecuteNonQuery();
        }
        public static int getMaxIdEquipe()
        {
            string query = "SELECT IFNULL(MAX(idEquipe),0) FROM equipe;";
            MySqlCommand cmd = new MySqlCommand(query, ConnexionBaseDAL.connection);
            cmd.ExecuteNonQuery();

            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            int maxIdEquipe = reader.GetInt32(0);
            reader.Close();
            return maxIdEquipe;
        }
        public static void supprimerEquipe(int id)
        {
            string query = "DELETE FROM equipe WHERE idEquipe = \"" + id + "\";";
            MySqlCommand cmd = new MySqlCommand(query, ConnexionBaseDAL.connection);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
    }
}
