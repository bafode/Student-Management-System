using System;
using MySql.Data.MySqlClient;

namespace teklogin
{
    class Database
    {
        private MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;user=root;password=Gonz@lo224;database=enregistement");
        
        //Create a function to open Connection
        public void OpenConnexion()
        {
            if(connection.State==System.Data.ConnectionState.Closed)
            {
                 connection.Open();
            }
        }
        //Create a function to Close Connexion
        public void CloseConnexion()
        {
            if (connection.State==System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }
        //create a function to get connexion
        public MySqlConnection getConnexion()
        {
            return connection;
        }
    }
}
