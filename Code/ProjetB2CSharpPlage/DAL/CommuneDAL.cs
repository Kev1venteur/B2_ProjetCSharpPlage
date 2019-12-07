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
    public class CommuneDAL
    {
        private static MySqlConnection connection;
        public CommuneDAL()
        {
            ConnexionBaseDAL.OpenConnection(); //  si la connexion est déjà ouverte, il ne la refera pas (voir code dans DALConnection)
            connection = ConnexionBaseDAL.connection;
        }

        public static ObservableCollection<CommuneDAO> selectCommunes()
        {
            ObservableCollection<CommuneDAO> l = new ObservableCollection<CommuneDAO>();
            string query = "SELECT * FROM Commune;";
            MySqlCommand cmd = new MySqlCommand(query, connection);
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
            string query = "UPDATE commune set nomCommune=\"" + p.nomCommuneDAO + "\", idDepartement=\"" + p.idDepartementCommuneDAO + "\" where idCommune=" + p.idCommuneDAO + ";";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
        public static void insertCommune(CommuneDAO p)
        {
            int id = getMaxIdCommune() + 1;
            string query = "INSERT INTO Commune VALUES (\"" + id + "\",\"" + p.nomCommuneDAO + "\",\"" + p.idDepartementCommuneDAO + "\");";
            MySqlCommand cmd2 = new MySqlCommand(query, connection);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd2);
            cmd2.ExecuteNonQuery();
        }
        public static void supprimerCommune(int id)
        {
            string query = "DELETE FROM commune WHERE idCommune = \"" + id + "\";";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
        public static int getMaxIdCommune()
        {
            string query = "SELECT IFNULL(MAX(idCommune),0) FROM commune;";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.ExecuteNonQuery();

            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            int maxIdCommune = reader.GetInt32(0);
            reader.Close();
            return maxIdCommune;
        }

        public static CommuneDAO getCommune(int idCommune)
        {
            string query = "SELECT * FROM Commune WHERE id=" + idCommune + ";";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            CommuneDAO pers = new CommuneDAO(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2));
            reader.Close();
            return pers;
        }
    }
}
