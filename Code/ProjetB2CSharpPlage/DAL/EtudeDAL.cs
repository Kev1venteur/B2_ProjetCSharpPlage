using MySql.Data.MySqlClient;
using ProjetB2CSharpPlage.DAO;
using System;
using System.Collections.ObjectModel;

namespace ProjetB2CSharpPlage.DAL
{
    public class EtudeDAL
    {
        private static MySqlConnection connection;
        public EtudeDAL()
        {
            ConnexionBaseDAL.OpenConnection(); //  si la connexion est déjà ouverte, il ne la refera pas (voir code dans DALConnection)
            connection = ConnexionBaseDAL.connection;
        }

        public static ObservableCollection<EtudeDAO> selectEtudes()
        {
            ObservableCollection<EtudeDAO> l = new ObservableCollection<EtudeDAO>();
            string query = "SELECT * FROM etude;";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.ExecuteNonQuery();

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                EtudeDAO p = new EtudeDAO(reader.GetInt32(0), reader.GetDateTime(1), reader.GetString(2), reader.GetInt32(3), reader.GetInt32(4));
                l.Add(p);
            }
            reader.Close();
            return l;
        }

        public static void updateEtude(EtudeDAO p)
        {
            string query = "UPDATE etude set titre=\"" + p.titreEtudeDAO + "\", idEquipe=\"" + p.idEquipeEtudeDAO + "\", nbTotalEspeceRencontree=\"" + p.nbTotalEspeceRencontreeEtudeDAO + "\", date=\"" + p.dateEtudeDAO + "\" where idEtude=" + p.idEtudeDAO + ";";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
        public static void insertEtude(EtudeDAO p)
        {
            int id = getMaxIdEtude() + 1;
            string query = "INSERT INTO etude VALUES (\"" + id + "\",\"" + p.dateEtudeDAO + "\",\"" + p.titreEtudeDAO + "\",\"" + p.nbTotalEspeceRencontreeEtudeDAO + "\",\"" + p.idEquipeEtudeDAO + "\");";
            MySqlCommand cmd2 = new MySqlCommand(query, connection);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd2);
            cmd2.ExecuteNonQuery();
        }
        public static void supprimerEtude(int id)
        {
            string query = "DELETE FROM etude WHERE idEtude = \"" + id + "\";";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
        public static int getMaxIdEtude()
        {
            string query = "SELECT IFNULL(MAX(idEtude),0) FROM etude;"; //Si null retourne 0 et pas 'null'
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            int maxIdEtude = reader.GetInt32(0);
            reader.Close();
            return maxIdEtude;
        }

        public static EtudeDAO getEtude(int idEtude)
        {
            string query = "SELECT * FROM etude WHERE id=" + idEtude + ";";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            EtudeDAO pers;
            if (reader.HasRows)
            {
                pers = new EtudeDAO(reader.GetInt32(0), reader.GetDateTime(1), reader.GetString(2), reader.GetInt32(3), reader.GetInt32(4));
            }
            else
            {
                pers = new EtudeDAO(1, DateTime.Now, "MauvaisNumeroEtude", 0, 1);
            }
            reader.Close();
            return pers;
        }
    }
}
