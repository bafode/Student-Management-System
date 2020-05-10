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
using System.IO;

namespace teklogin
{
    public partial class PrintScoreForm : Form
    {
        public PrintScoreForm()
        {
            InitializeComponent();
        }
        Score score = new Score();
        Student student = new Student();
        Course course = new Course();

        private void PrintScoreForm_Load(object sender, EventArgs e)
        {
            //populate the datagridview with student data
            MySqlCommand command = new MySqlCommand("select student_id,first_name,last_name from student");
            dataGridViewStudentList.DataSource = student.getStudent(command);

            dataGridViewScoreList.DataSource = score.getStudentScore();
            listBoxCourseList.DataSource = course.GetAll();
            listBoxCourseList.DisplayMember = "label";
            listBoxCourseList.ValueMember = "id";

        }

        /*when you select a course from de listbox all the score assigned
        to this course will be displayed in the datagridview*/

        private void listBoxCourseList_Click(object sender, EventArgs e)
        {
            course.Id = (int)listBoxCourseList.SelectedValue;
            dataGridViewScoreList.DataSource = score.getCourseScore(course.Id);
            labelAverage.Text = "Average:"+course.Average();

        }

        
        //Display the selected Student Score
        private void dataGridViewStudentList_Click(object sender, EventArgs e)
        {
            student.Id = int.Parse(dataGridViewStudentList.CurrentRow.Cells[0].Value.ToString());
            dataGridViewScoreList.DataSource = score.getStudentScore(student.Id);
            labelAverage.Text = "Average: "+student.Average();

        }

        private void labelReset_Click(object sender, EventArgs e)
        {
            dataGridViewScoreList.DataSource = score.getStudentScore();
        }

     

        private void labelReset_MouseEnter(object sender, EventArgs e)
        {
            labelReset.ForeColor = Color.White;
        }

        private void labelReset_MouseLeave(object sender, EventArgs e)
        {
            labelReset.ForeColor = Color.Yellow;
        }

        private void PrintScore_Click(object sender, EventArgs e)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\Scores_list.text";
            using (var writer = new StreamWriter(path))
            {
                //check if the file exist
                if (!File.Exists(path))
                {
                    File.Create(path);
                }

                for (int i = 0; i < dataGridViewScoreList.Rows.Count; i++)//rows
                {

                    for (int j = 0; j < dataGridViewScoreList.Columns.Count; j++)//columns
                    {

                        writer.Write("\t" + dataGridViewScoreList.Rows[i].Cells[j].Value + "\t" + "|");

                    }
                    writer.WriteLine();
                    writer.WriteLine("-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
                }

                writer.Close();
                MessageBox.Show("Data exported");
            }
        }
    }
}
