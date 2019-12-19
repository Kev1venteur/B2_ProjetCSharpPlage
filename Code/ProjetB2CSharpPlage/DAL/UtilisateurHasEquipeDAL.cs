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
    class UtilisateurHasEquipeDAL
    {

        public static ObservableCollection<UtilisateurHasEquipeDAO> selectUtilisateurHasEquipes()
        {
            ObservableCollection<UtilisateurHasEquipeDAO> l = new ObservableCollection<UtilisateurHasEquipeDAO>();
            string query = "SELECT * FROM utilisateur_has_equipe;";
            MySqlCommand cmd = new MySqlCommand(query, ConnexionBaseDAL.connection);
            cmd.ExecuteNonQuery();

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                UtilisateurHasEquipeDAO u = new UtilisateurHasEquipeDAO(reader.GetInt32(0), reader.GetInt32(1));
                l.Add(u);
            }
            reader.Close();
            return l;
        }

        //Select général -> pas de select de tout les user avec tel equipe

        //public static UtilisateurHasEquipeDAO getUtilisateurHasEquipeByUtilisateur(int idUtilisateur)
        //{
        //    string query = "SELECT * FROM utilisateur_has_equipe WHERE idUtilisateur=" + idUtilisateur + ";";
        //    MySqlCommand cmd = new MySqlCommand(query, DALConnection.connection);
        //    cmd.ExecuteNonQuery();
        //    MySqlDataReader reader = cmd.ExecuteReader();
        //    reader.Read();
        //    UtilisateurHasEquipeDAO user = new UtilisateurHasEquipeDAO(reader.GetInt32(0), reader.GetInt32(1));
        //    reader.Close();
        //    return user;
        //}
        public static UtilisateurHasEquipeDAO getUtilisateurHasEquipe(int idUtilisateur, int idEquipe)
        {
            string query = "SELECT * FROM utilisateur_has_equipe WHERE utilisateur_idUtilisateur=" + idUtilisateur + " and equipe_idEquipe=" + idEquipe + ";";
            MySqlCommand cmd = new MySqlCommand(query, ConnexionBaseDAL.connection);
            cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            UtilisateurHasEquipeDAO user;
            if (reader.HasRows)
            {
                user = new UtilisateurHasEquipeDAO(reader.GetInt32(0), reader.GetInt32(1));
            }
            else
            {
                user = new UtilisateurHasEquipeDAO(1, 1);
            }
            reader.Close();
            return user;
        }

        //pas de update de clé primaire 

        //public static void updateUtilisateurHasEquipe(UtilisateurHasEquipeDAO u)
        //{            
        //    string query = "UPDATE utilisateur_has_equipe SET Utilisateur_idUtilisateur =" + u.Utilisateur_idUtilisateurDAO + ", Equipe_idEquipe=" + u.Utilisateur_idUtilisateurDAO + " WHERE Utilisateur_idUtilisateur =" + u.Utilisateur_idUtilisateurDAO + " AND Equipe_idEquipe =" + u.Equipe_idEquipeDAO + ";";
        //    ///////////???
        //    MySqlCommand cmd = new MySqlCommand(query, DALConnection.connection);
        //    MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
        //    cmd.ExecuteNonQuery();
        //}
        public static void insertUtilisateurHasEquipe(UtilisateurHasEquipeDAO u)
        {
            string query = "INSERT INTO utilisateur_has_equipe VALUES (\"" + u.Utilisateur_idUtilisateurDAO + "\",\"" + u.Equipe_idEquipeDAO + "\");";
            MySqlCommand cmd2 = new MySqlCommand(query, ConnexionBaseDAL.connection);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd2);
            cmd2.ExecuteNonQuery();
        }

        //pas de max id avec plusieurs clés primaires

        //public static int getMaxIdUtilisateurHasEquipe()
        //{
        //    string query = "SELECT IFNULL(MAX(idUtilisateurHasEquipe),0) FROM UtilisateurHasEquipe;";
        //    MySqlCommand cmd = new MySqlCommand(query, DALConnection.connection);
        //    cmd.ExecuteNonQuery();

        //    MySqlDataReader reader = cmd.ExecuteReader();
        //    reader.Read();
        //    int maxIdUtilisateurHasEquipe = reader.GetInt32(0);
        //    reader.Close();
        //    return maxIdUtilisateurHasEquipe;
        //}
        public static void supprimerUtilisateurHasEquipe(int idUtilisateur, int idEquipe)
        {
            string query = "DELETE FROM utilisateur_has_equipe WHERE Utilisateur_idUtilisateur =" + idUtilisateur + " AND Equipe_idEquipe =" + idEquipe + ";";
            MySqlCommand cmd = new MySqlCommand(query, ConnexionBaseDAL.connection);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }

    }
}
