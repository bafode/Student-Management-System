using MySql.Data.MySqlClient;
using System.Data;

namespace teklogin
{
    class Score:SuperClass
    {
        // Alanlar (Fields)
        private int _studentId;
        private double _scoreValue;
        private int _courseId;

        // Özellikler (Properties)
        public int StudentId
        {
            get { return _studentId; }
            set { _studentId = value; }
        }
        public double ScoreValue
        {
            get { return _scoreValue; }
            set { _scoreValue = value; }
        }
        public int CourseId
        {
            get { return _courseId; }
            set { _courseId = value; }
        }

        //---------------------Metodlar(Methods)----------------------------


        //create a function to insert a new score
        Database db = new Database();

        public override bool Insert()
        {
            MySqlCommand command = new MySqlCommand("insert into score(student_id,course_id,score,inscription) values(@sid,@cid,@scr,@desc)", db.getConnexion());
            command.Parameters.Add("@sid", MySqlDbType.Int32).Value = this.StudentId;
            command.Parameters.Add("@cid", MySqlDbType.Int32).Value = this.CourseId;
            command.Parameters.Add("@scr", MySqlDbType.Double).Value = this.ScoreValue;
            command.Parameters.Add("@desc", MySqlDbType.Text).Value = this.Description;

            db.OpenConnexion();
            if (command.ExecuteNonQuery()==1)
            {
                db.OpenConnexion();
                return true;
            }
            else
            {
                db.CloseConnexion();
                return false;
            }
        }

        //create a fuction to chech if the score already assigned to this student in this course

        public override bool Check()
        {
            MySqlCommand command = new MySqlCommand("select *from score where student_id=@sid and course_id=@cid", db.getConnexion());
            command.Parameters.Add("@sid", MySqlDbType.Int32).Value = this.StudentId;
            command.Parameters.Add("@cid", MySqlDbType.Int32).Value = this.CourseId;
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);

            if (table.Rows.Count>1)
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

        //create a function to get student score
        public DataTable getStudentScore()
        {
            MySqlCommand command = new MySqlCommand();
            command.Connection = db.getConnexion();
            command.CommandText = " select student.student_id,student.first_name,student.last_name,score.course_id,course.label,score.score from student inner join score on student.student_id = score.student_id inner join course on course.id = score.course_id";
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);

            return table;
            
        }

        //funciton to remove score by student id and course id
        public  bool Delete( int Si,int Ci)
        {
            MySqlCommand command = new MySqlCommand("delete from score where student_id=@sid and course_id=@cid", db.getConnexion());
            command.Parameters.Add("@sid", MySqlDbType.Int32).Value = Si;
            command.Parameters.Add("@cid", MySqlDbType.Int32).Value =Ci;
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

        //Create a function to get average by course
        public DataTable getAvgByScore()
        {
            MySqlCommand command = new MySqlCommand();
            command.Connection = db.getConnexion();
            command.CommandText = "select course.label,round(avg(score.score),2) as 'AVG Score' from course,score where score.course_id=course.id group by course.label";
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);

            return table;

        }
        //Create a function to get course score by course
        public DataTable getCourseScore(int courseId)
        {
            MySqlCommand command = new MySqlCommand();
            command.Connection = db.getConnexion();
            command.CommandText = "select student.student_id,student.first_name,student.last_name,score.course_id,course.label,score.score from student inner join score on student.student_id = score.student_id inner join course on course.id = score.course_id where  score.course_id=@cid";
            command.Parameters.Add("@cid", MySqlDbType.Int32).Value = courseId;
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);

            return table;

        }

        //Create a function to get Student score by course
        public DataTable getStudentScore(int StudentId)
        {
            MySqlCommand command = new MySqlCommand();
            command.Connection = db.getConnexion();
            command.CommandText = "select student.student_id,student.first_name,student.last_name,score.course_id,course.label,score.score from student inner join score on student.student_id = score.student_id inner join course on course.id = score.course_id where  score.student_id=@sid";
            command.Parameters.Add("@sid", MySqlDbType.Int32).Value =StudentId;
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);

            return table;

        }
       
      
    }
}
