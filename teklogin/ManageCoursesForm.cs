using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace teklogin
{
    public partial class ManageCoursesForm : Form
    {
        public ManageCoursesForm()
        {
            InitializeComponent();
        }
        Course course = new Course();
        int pos;
        private void ManageCoursesForm_Load(object sender, EventArgs e)
        {
            reloadListBoxData();
        }
        //create a function to load the listbox with courses
        public void reloadListBoxData()
        {
            listBoxCourses.DataSource = course.GetAll();
            listBoxCourses.ValueMember = "id";
            listBoxCourses.DisplayMember = "label";
            //unselect the data from listbox
            listBoxCourses.SelectedItem = null;
            //display the total courses
            labelTotalCourses.Text = "Total Courses: " + course.totalCourses();
        }

        //create function to display the course date depending on the index
        void ShowData(int index)
        {
            DataRow dr = course.GetAll().Rows[index];

            listBoxCourses.SelectedIndex = index;
            textBoxID.Text = dr.ItemArray[0].ToString();
            textBoxlabel.Text = dr.ItemArray[1].ToString();
            numericUpDownHours.Value = int.Parse(dr.ItemArray[2].ToString());
            textBoxDescription.Text = dr.ItemArray[3].ToString();

        }



        private void listBoxCourses_Click(object sender, EventArgs e)
        {
            //display the select course data
            pos = listBoxCourses.SelectedIndex;
            ShowData(pos);
        }
        //you can use this but i will use the click event instead
        private void listBoxCourses_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //display the select course data
                pos = listBoxCourses.SelectedIndex;
                ShowData(pos);
            }
            catch
            {

               
            }
        }

        //button first
        private void buttonFirst_Click(object sender, EventArgs e)
        {
            pos = 0;
            ShowData(pos);

        }

        //button next
        private void buttonNext_Click(object sender, EventArgs e)
        {
            if (pos<course.GetAll().Rows.Count-1)
            {
                pos = pos + 1;
                ShowData(pos);
            }
           

        }

        //button previous

        private void buttonPrevious_Click(object sender, EventArgs e)
        {
            if (pos>0)
            {
                pos = pos - 1;
                ShowData(pos);

            }
        }

        private void buttonLast_Click(object sender, EventArgs e)
        {
            pos = course.GetAll().Rows.Count - 1;
            ShowData(pos);
        }

      

        private void buttonAddCourse_Click(object sender, EventArgs e)
        {
            try
            {
                Course course = new Course();
                course.Label = textBoxlabel.Text;
                course.Hour_number = (int)numericUpDownHours.Value;
                course.Description = textBoxDescription.Text;



                if (course.Label.Trim().Equals(""))
                {
                    MessageBox.Show("Enter a course name", "Add course", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                else if (course.Check())
                {
                    if (course.Insert())
                    {
                        MessageBox.Show("New Course inserted", "Add course", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        reloadListBoxData();
                    }
                    else
                    {
                        MessageBox.Show("New Course Not inserted", "Add course", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("this course name already exist", "Add course", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {

                MessageBox.Show("Enter the correct values of fields", "Add course", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {

            try
            {
                Course course = new Course();
                course.Id= Convert.ToInt32(textBoxID.Text);

                

                if (MessageBox.Show("Are you sure you want to remove this cours?", "delete course", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    if (course.Delete())
                    {
                        MessageBox.Show("Course Deleted", "Remove Course", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        reloadListBoxData();
                        //clear fields
                        textBoxID.Text = "";
                        numericUpDownHours.Value = 10;
                        textBoxlabel.Text = "";
                        textBoxDescription.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Course Not Deleted", "Remove Course", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
            catch
            {

                MessageBox.Show("Enter a valid course id", "Remove Course", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        //button edit course
        private void buttonEditCourse_Click(object sender, EventArgs e)
        {
            try
            {
                //edit the selecet course*/

                course.Label = textBoxlabel.Text;
                course.Hour_number = (int)numericUpDownHours.Value;
                course.Description = textBoxDescription.Text;
                course.Id = int.Parse(textBoxID.Text);


                if (!course.Label.Trim().Equals(""))
                {
                    //check if this cours name already exist and it is not the current id using the id
                    if (!course.Check())
                    {
                        MessageBox.Show("this course name already exist", "Edit course", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }
                    else if (course.UpdateCourse())
                    {
                        MessageBox.Show("Course Updated", "Edit course", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        reloadListBoxData();
                      
                    }
                    else
                    {
                        MessageBox.Show("Course Not Updated", "Edit course", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Enter the course name", "Edit course", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }
            catch
            {
                MessageBox.Show("No course selected", "Edit course", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
    }
}
