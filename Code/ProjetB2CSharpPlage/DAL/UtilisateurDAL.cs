using MySql.Data.MySqlClient;
using System.Collections.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetB2CSharpPlage.DAL;
using ProjetB2CSharpPlage.DAO;

namespace ProjetB2CSharpPlage.DAL
{
    class UtilisateurDAL
    {
        private static MySqlConnection connection;
        public UtilisateurDAL()
        {
            ConnexionBaseDAL.OpenConnection(); //  si la connexion est déjà ouverte, il ne la refera pas (voir code dans DALConnection)
            connection = ConnexionBaseDAL.connection;
        }
        public static ObservableCollection<UtilisateurDAO> selectUtilisateurs()
        {
            ObservableCollection<UtilisateurDAO> l = new ObservableCollection<UtilisateurDAO>();
            string query = "SELECT * FROM utilisateur;";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.ExecuteNonQuery();

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                UtilisateurDAO p = new UtilisateurDAO(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetBoolean(3));
                l.Add(p);
            }
            reader.Close();
            return l;
        }
        public static UtilisateurDAO getUtilisateur(int idUtilisateur)
        {
            string query = "SELECT * FROM utilisateur WHERE id=" + idUtilisateur + ";";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            UtilisateurDAO user = new UtilisateurDAO(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetBoolean(3));
            reader.Close();
            return user;
        }
        public static void updateUtilisateur(UtilisateurDAO u)
        {
            string query = "UPDATE utilisateur set nom=\"" + u.nomUtilisateurDAO + "\", prenom=\"" + u.prenomUtilisateurDAO + "\", isAdmin=\"" + u.roleUtilisateurDAO + "\" where idUtilisateur=" + u.idUtilisateurDAO + ";";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
        public static void insertUtilisateur(UtilisateurDAO u)
        {
            int id = getMaxIdUtilisateur() + 1;
            string query = "INSERT INTO utilisateur VALUES (\"" + id + "\",\"" + u.nomUtilisateurDAO + "\",\"" + u.prenomUtilisateurDAO + "\",\"" + u.roleUtilisateurDAO + "\");";
            MySqlCommand cmd2 = new MySqlCommand(query, connection);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd2);
            cmd2.ExecuteNonQuery();
        }
        public static int getMaxIdUtilisateur()
        {
            string query = "SELECT MAX(idUtilisateur) FROM utilisateur;";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.ExecuteNonQuery();

            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            int maxIdUtilisateur = reader.GetInt32(0);
            reader.Close();
            return maxIdUtilisateur;
        }
        public static void supprimerUtilisateur(int id)
        {
            string query = "DELETE FROM Utilisateur WHERE idUtilisateur = \"" + id + "\";";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
    }
}
