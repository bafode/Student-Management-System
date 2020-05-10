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
    public partial class AddCourseForm : Form
    {
        public AddCourseForm()
        {
            InitializeComponent();
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

        private void AddCourseForm_Load(object sender, EventArgs e)
        {

        }
    }
}
