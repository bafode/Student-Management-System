using System;
using MySql.Data.MySqlClient;
using System.Data;

namespace teklogin
{
    class User:IPerson
    {
        Database db = new Database();//get connected to the database

        // Alanlar (Fields)
        private int _id;
        private string _first_name;
        private string _last_name;
        private string _username;
        private string _address;
        private string _password;
        private string _cpassword;
        private string _email;

        // Özellikler (Properties)
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public string First_name
        {
            get { return _first_name; }
            set { _first_name = value; }
        }
       
        public string Last_name
        {
            get { return _last_name; }
            set { _last_name = value; }
        }
        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }
        public String Username
        {
            get { return _username; }
            set { _username = value; }
        }
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }
        public string CPassword
        {
            get { return _cpassword; }
            set { _cpassword = value; }
        }
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }


        //Kurucular (Constructor)
        public User()
        {

        }

        
         public User(int id, string firstname, string lastname, string username, string address, string password, string email)
         {
             this._id = id;
             this._first_name = firstname;
             this._last_name = lastname;
             this._username = username;
             this._address = address;
             this._password = password;
             this._email = email;
         }

       //---------------------Metodlar(Methods)----------------------------
        //create a function to add a new user
        public bool Insert()
        {
            
            MySqlCommand command = new MySqlCommand("insert into users(first_name,last_name,username,email,password) values( @fn, @ln, @usn, @email, @pass)", db.getConnexion());
            command.Parameters.Add("@fn", MySqlDbType.VarChar).Value = this.First_name;
            command.Parameters.Add("@ln", MySqlDbType.VarChar).Value = this.Last_name;
            command.Parameters.Add("@email", MySqlDbType.VarChar).Value = this.Email;
            command.Parameters.Add("@usn", MySqlDbType.VarChar).Value = this.Username;
            command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = this.Password;
            db.OpenConnexion();
            if (command.ExecuteNonQuery() == 1)
            {
                db.CloseConnexion();
                return true;
            }
            else
            {
                db.CloseConnexion();
                return false;
            }
        }

        //Create a function to Chech if the username already exist in the database
        public Boolean checkUsername()
        {
            Database db = new Database();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("select *from users where username=@usn", db.getConnexion());
            command.Parameters.Add("@usn", MySqlDbType.VarChar).Value = this.Username;


            adapter.SelectCommand = command;
            adapter.Fill(table);
            if (table.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        //Create a function to login
        public bool Login()
        {
            DataTable table = new DataTable();

           
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("select *from users where username=@user1 and password=@pass", db.getConnexion());
            command.Parameters.Add("@user1", MySqlDbType.VarChar).Value =this.Username;
            command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = this.Password;
            adapter.SelectCommand = command;
            adapter.Fill(table);
            if (table.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        //function to update student informations

        public bool Update()
        {

            MySqlCommand command = new MySqlCommand("update users set first_name=@fn,last_name= @ln,username= @us,address=@ad,email= @em where user_id=@id", db.getConnexion());
            command.Parameters.Add("@id", MySqlDbType.Int32).Value = this.Id;
            command.Parameters.Add("@fn", MySqlDbType.VarChar).Value = this.First_name;
            command.Parameters.Add("@ln", MySqlDbType.VarChar).Value = this.Last_name;
            command.Parameters.Add("@us", MySqlDbType.VarChar).Value = this.Username;
            command.Parameters.Add("@ad", MySqlDbType.VarChar).Value = this.Address;
            command.Parameters.Add("@em", MySqlDbType.VarChar).Value = this.Email;

            db.OpenConnexion();

            if (command.ExecuteNonQuery() == 1)
            {
                db.CloseConnexion();
                return true;
            }
            else
            {
                db.CloseConnexion();
                return false;
            }
        }

        //create a function to delete the student from the database
        public bool Delete()
        {


            MySqlCommand command = new MySqlCommand("delete from users where user_id=@id", db.getConnexion());
            command.Parameters.Add("@id", MySqlDbType.Int32).Value = this.Id;


            db.OpenConnexion();

            if (command.ExecuteNonQuery() == 1)
            {
                db.CloseConnexion();
                return true;
            }
            else
            {
                db.CloseConnexion();
                return false;
            }
        }


        //Create a function to get all users
        public DataTable GetAll()
        {
            MySqlCommand command = new MySqlCommand("select *from users", db.getConnexion());
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);

            return table;
        }

        //Create a function to research user 
        public DataTable Search( string s)
        {
           
            MySqlCommand command = new MySqlCommand("select  *from users where concat(first_name,'',last_name,'',username) like '%" + s + "%'",db.getConnexion());
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            adapter.Fill(table);

            return table;
            
        }


    }
}
