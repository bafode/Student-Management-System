using MySql.Data.MySqlClient;
using System.Data;


namespace teklogin
{
    class Course:SuperClass
    {
        // Alanlar (Fields)
        private int _id;
        private string _label;
        private int _hour_number;

        // Özellikler (Properties)
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public string Label
        {
            get { return _label; }
            set { _label = value; }
        }
        public int Hour_number
        {
            get { return _hour_number; }
            set { _hour_number = value; }
        }
       
        Database db = new Database();

        //---------------------Metodlar(Methods)----------------------------


        //create a function to add course in the database

        public override  bool Insert()
        {
          
            MySqlCommand command = new MySqlCommand(" INSERT INTO course (label,hours_number,description) VALUES(@lb,@hrs,@dsc)", db.getConnexion());
            command.Parameters.Add("@lb", MySqlDbType.VarChar).Value =this.Label;
            command.Parameters.Add("@hrs", MySqlDbType.Int32).Value = this.Hour_number;
            command.Parameters.Add("@dsc", MySqlDbType.Text).Value = this.Description;


            db.OpenConnexion();
            if (command.ExecuteNonQuery()==1)
            {
                return true;
            }
            else
            {
                return false;
                
            }

        }

        //create a function to check if the course name already exist in the database
        //when we edit the course we need to exclude the current course from the name verification
        //using the course id
        //by default we will set the course id to 0

        public override bool Check()
        {

            MySqlCommand command = new MySqlCommand("select *from course where label=@lb and id<>@id", db.getConnexion());
            command.Parameters.Add("lb", MySqlDbType.VarChar).Value = this.Label;
            command.Parameters.Add("id", MySqlDbType.Int32).Value = this.Id;
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            adapter.SelectCommand = command;
            DataTable table = new DataTable();
            adapter.Fill(table);

            if (table.Rows.Count>0)
            {
                return false;//already existe
            }
            else
            {
                return true;
            }

        }

        //funciton to remove course by id
        public override bool Delete()
        {
            MySqlCommand command = new MySqlCommand("delete from course where id=@id", db.getConnexion());
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

        //create a function to get all cours
        public override DataTable GetAll()
        {
            MySqlCommand command = new MySqlCommand("select *from course", db.getConnexion());

            MySqlDataAdapter adapter = new MySqlDataAdapter(command);

            DataTable table = new DataTable();

            adapter.Fill(table);

            return table;

        }
        //create a function to get a cours by id
        public DataTable getACourseById(int courseId)
        {
            MySqlCommand command = new MySqlCommand("select *from course where id=@id", db.getConnexion());
            command.Parameters.Add("@id", MySqlDbType.Int32).Value = courseId;
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
           
            adapter.Fill(table);

            return table;

        }

        //create the function to edit the selected course

        public bool UpdateCourse()
        {

            MySqlCommand command = new MySqlCommand("update course set label=@lb,hours_number=@hrs,description=@dsc where id=@id", db.getConnexion());
            command.Parameters.Add("@id", MySqlDbType.Int32).Value = this.Id;
            command.Parameters.Add("@lb", MySqlDbType.VarChar).Value = this.Label;
            command.Parameters.Add("@hrs", MySqlDbType.Int32).Value = this.Hour_number;
            command.Parameters.Add("@dsc", MySqlDbType.Text).Value = this.Description;


            db.OpenConnexion();
            if (command.ExecuteNonQuery() == 1)
            {
                return true;
            }
            else
            {
                return false;
                db.CloseConnexion();
            }

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
        //get the total of courses
        public string totalCourses()
        {
            return ExeCount("select count(*)from course");
        }
      
        //create a function to get CourseAverage
        public string Average()
        {
            return ExeCount("select round(avg(score.score),2) from score inner join course on course.id = score.course_id where  score.course_id=" + this.Id);
        }

    }
}
