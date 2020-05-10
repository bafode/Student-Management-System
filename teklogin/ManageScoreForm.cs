using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace teklogin
{
    public partial class ManageScoreForm : Form
    {
        public ManageScoreForm()
        {
            InitializeComponent();
        }

        Course course = new Course();
        Score score = new Score();
        Student student = new Student();
        string data = "score";
       
        private void ManageScoreForm_Load(object sender, EventArgs e)
        {
            //populate de combobox with courses
            comboBoxCourses.DataSource = course.GetAll();
            comboBoxCourses.DisplayMember = "label";
            comboBoxCourses.ValueMember = "id";
            //populate the datagridview with student score
            dataGridView1.DataSource = score.getStudentScore();
        }

        //Display student on datagridview
        private void buttonShowStudent_Click(object sender, EventArgs e)
        {
            data = "student";
            MySqlCommand command = new MySqlCommand("select student_id,first_name,last_name,birthday from student");
            dataGridView1.DataSource = student.getStudent(command);

        }


        //Display courses on datagridview
        private void button3ShowScore_Click(object sender, EventArgs e)
        {
            data = "score";
            dataGridView1.DataSource = score.getStudentScore();
        }
        //get data from datagridview
        private void dataGridView1_Click_1(object sender, EventArgs e)
        {
            getDataFromDatagridview();
        }
        //create function to get data from datagridview
        public void getDataFromDatagridview()
        {
            //if the user selecte to show student the data we will show only student id
            if (data=="student")
            {
                textBoxStudentID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            }

            /*if the user selecte to show score the data we will show the student 
              id and the course and select the course from the combobox*/
            else if (data=="score")
            {
                textBoxStudentID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                comboBoxCourses.SelectedValue = dataGridView1.CurrentRow.Cells[3].Value;
            }
           

        }

        //Add a new score

        private void buttonAddScore_Click(object sender, EventArgs e)
        {

            //Add a new score 

            try
            {
                score.StudentId = int.Parse(textBoxStudentID.Text);
                score.CourseId = (int)comboBoxCourses.SelectedValue;
                score.ScoreValue = double.Parse(textBoxScore.Text);
                score.Description = textBoxDescription.Text;

                if (!score.Check())
                {
                    if (score.Insert())
                    {
                        MessageBox.Show("Student score inserted", "Add score", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Student score not inserted", "Add score", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("the student's score for this course is already set", "Add score", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Add score", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void buttonRemoveScore_Click(object sender, EventArgs e)
        {
            //remove the selected score 
            score.StudentId = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            score.CourseId = int.Parse(dataGridView1.CurrentRow.Cells[3].Value.ToString());

            if (MessageBox.Show("Do you want to delete this score?", "Remove score", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                if (score.Delete())
                {
                    MessageBox.Show("Score Deleted", "Remove Score", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridView1.DataSource = score.getStudentScore();


                }
                else
                {

                    MessageBox.Show(" Score Not Deleted", "Remove Score", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void buttonAvgScorebyCourse_Click(object sender, EventArgs e)
        {
            avgScoreByCourseForm frm = new avgScoreByCourseForm();
            frm.Show(this);
        }

        
    }
}
