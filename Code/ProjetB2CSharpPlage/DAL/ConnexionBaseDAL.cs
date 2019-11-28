using System;
using MySql.Data.MySqlClient;

namespace ProjetB2CSharpPlage.DAL
{
    class ConnexionBaseDAL
    {
        private static string server;
        private static string database;
        private static string uid;
        private static string password;
        public static MySqlConnection connection;

        public static Boolean OpenConnection()
        {
            if (connection == null) //  si la connexion est déjà ouverte, il ne la refera pas 
            {

                server = "localhost";
                database = "projetb2csharp";
                uid = "projetb2csharp";
                password = "projetb2csharp";
                string connectionString;
                connectionString = "SERVER=" + server + ";" + "DATABASE=" +
                database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
                connection = new MySqlConnection(connectionString);
                connection.Open();
            }
            return true;
        }
    }
}
