using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace teklogin
{
    public partial class AddScoreForm : Form
    {
        public AddScoreForm()
        {
            InitializeComponent();
        }

        Score score = new Score();
        Student student = new Student();
        Course course = new Course();
        
        //on form load
        private void AddScoreForm_Load(object sender, EventArgs e)
        {
            //populate the combobox with courses
           comboBoxCourses.DataSource = course.GetAll();
          comboBoxCourses.DisplayMember = "label";
           comboBoxCourses.ValueMember = "id";

            //populate the datagridview with student informations(id,first_name,last_name)
            MySqlCommand command = new MySqlCommand("select student_id,first_name,last_name from student");
            dataGridView1.DataSource = student.getStudent(command);

        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            //get the id of the selected students
            textBoxStudentID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
           
        }

        private void buttonAddScore_Click(object sender, EventArgs e)
        {
            //Add a new score 

            try
            {
                score.StudentId= int.Parse(textBoxStudentID.Text);
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
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Add score", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
    }
}
