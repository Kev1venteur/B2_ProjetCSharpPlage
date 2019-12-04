using MySql.Data.MySqlClient;
using System.Collections.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetB2CSharpPlage.DAL;
using ProjetB2CSharpPlage.DAO;
using System.Security.Cryptography;

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
                UtilisateurDAO p = new UtilisateurDAO(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetByte(3), reader.GetString(4), reader.GetString(5));
                l.Add(p);
            }
            reader.Close();
            return l;
        }
        public static UtilisateurDAO getUtilisateur(int idUtilisateur)
        {
            string query = "SELECT * FROM utilisateur WHERE idUtilisateur=" + idUtilisateur + ";";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            UtilisateurDAO user = new UtilisateurDAO(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetByte(3), reader.GetString(4), reader.GetString(5));
            reader.Close();
            return user;
        }
        public static void updateUtilisateur(UtilisateurDAO u)
        {
            u.passwordUtilisateurDAO = hash(u.passwordUtilisateurDAO);
            string query = "UPDATE utilisateur set nom=\"" + u.nomUtilisateurDAO + "\", prenom=\"" + u.prenomUtilisateurDAO + "\", isAdmin=\"" + u.roleUtilisateurDAO + "\", password=\"" + u.passwordUtilisateurDAO + "\", login=\"" + u.loginUtilisateurDAO + "\" where idUtilisateur=" + u.idUtilisateurDAO + ";";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
        public static void insertUtilisateur(UtilisateurDAO u)
        {
            u.passwordUtilisateurDAO = hash(u.passwordUtilisateurDAO);
            int id = getMaxIdUtilisateur() + 1;
            string query = "INSERT INTO utilisateur VALUES (\"" + id + "\",\"" + u.nomUtilisateurDAO + "\",\"" + u.prenomUtilisateurDAO + "\",\"" + u.roleUtilisateurDAO + "\",\"" + u.passwordUtilisateurDAO + "\",\"" + u.loginUtilisateurDAO + "\");";
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
            string query = "DELETE FROM utilisateur WHERE idUtilisateur = \"" + id + "\";";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
        public static string hash(string text)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));
            byte[] result = md5.Hash;
            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                strBuilder.Append(result[i].ToString("x2"));
            }
            return strBuilder.ToString();
        }
    }
}
