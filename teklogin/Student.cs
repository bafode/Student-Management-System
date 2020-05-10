using System;
using System.IO;
using MySql.Data.MySqlClient;
using System.Data;


namespace teklogin
{
    class Student:IPerson
    {
        // Alanlar (Fields)
        private int _id;
        private string _first_name;
        private string _last_name;
        private string _address;
        private string _phone;
        private string _gender;
        private DateTime _birthdate;
        private MemoryStream _picture;

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
        public string Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }
        public string Gender
        {
            get { return _gender; }
            set { _gender = value; }
        }
        public DateTime BirthDate
        {
            get { return _birthdate; }
            set { _birthdate = value; }
        }
        public MemoryStream Picture
        {
            get { return _picture; }
            set { _picture = value; }
        }


        //---------------------Metodlar(Methods)----------------------------

        //create a fonction to add student in the database
        Database db = new Database();
       public Boolean Insert()
        {
            MySqlCommand command = new MySqlCommand("insert into student(first_name,last_name,phone,address,gender,birthday,picture)values(@fn, @ln, @ph, @ad, @gen, @bir, @pic)", db.getConnexion());
           
            command.Parameters.Add("@fn", MySqlDbType.VarChar).Value = this.First_name;
            command.Parameters.Add("@ln", MySqlDbType.VarChar).Value = this.Last_name;
            command.Parameters.Add("@ph", MySqlDbType.VarChar).Value = this.Phone;
            command.Parameters.Add("@ad", MySqlDbType.VarChar).Value = this.Address;
            command.Parameters.Add("@gen", MySqlDbType.VarChar).Value = this.Gender;
            command.Parameters.Add("@bir", MySqlDbType.Date).Value = this.BirthDate;
            command.Parameters.Add("@pic", MySqlDbType.Blob).Value= this.Picture.ToArray();

            db.OpenConnexion();

            if(command.ExecuteNonQuery()==1)
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

        //create a function to return the table of student
        public DataTable getStudent(MySqlCommand command)
        {
            command.Connection = db.getConnexion();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            adapter.SelectCommand = command;
            DataTable table = new DataTable();
            adapter.Fill(table);


            return table;

        }

        //function to update student informations

        public bool Update()
        {

            MySqlCommand command = new MySqlCommand("update student set first_name=@fn,last_name= @ln,phone= @ph,address=@ad,gender= @gen,birthday=@bir,picture=@pic where student_id=@id", db.getConnexion());
            command.Parameters.Add("@id", MySqlDbType.Int32).Value = this.Id;
            command.Parameters.Add("@fn", MySqlDbType.VarChar).Value = this.First_name;
            command.Parameters.Add("@ln", MySqlDbType.VarChar).Value = this.Last_name;
            command.Parameters.Add("@ph", MySqlDbType.VarChar).Value = this.Phone;
            command.Parameters.Add("@ad", MySqlDbType.VarChar).Value = this.Address;
            command.Parameters.Add("@gen", MySqlDbType.VarChar).Value = this.Gender;
            command.Parameters.Add("@bir", MySqlDbType.Date).Value = this.BirthDate;
            command.Parameters.Add("@pic", MySqlDbType.Blob).Value = this.Picture.ToArray();

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


            MySqlCommand command = new MySqlCommand("delete from student where student_id=@id", db.getConnexion());
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

        //Create a function to research student
        public DataTable Search(string s)
        {
            MySqlCommand command = new MySqlCommand("select  *from student where concat(first_name,'',last_name,'',address) like '%" +s+ "%'", db.getConnexion());
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            adapter.Fill(table);

            return table;

        }

        //create a function to execute the count queries
        public string ExeCount(string query)
        {
            MySqlCommand command = new MySqlCommand(query, db.getConnexion());
            db.OpenConnexion();
            string count = command.ExecuteScalar().ToString();
            db.CloseConnexion();


            return count;
        }

        //get the total student
        public string totalStudent()
        {
            return ExeCount("select count(*)from student");
        }
        //get the total of male student
        public string totalMale()
        {
            return ExeCount("select count(*) from student where gender='Male'");
        }
        //get the total of female student
        public string totalFemale()
        {
            return ExeCount("select count(*) from student where gender='Femele'");
        }
        //Create a function to get student average
        public string Average()
        {
           
           return ExeCount("select round(avg(score.score),2) from student inner join score on student.student_id = score.student_id inner join course on course.id = score.course_id where  score.student_id="+this.Id);
         
        }
    }
}
