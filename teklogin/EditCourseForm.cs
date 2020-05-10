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
    public partial class EditCourseForm : Form
    {
        public EditCourseForm()
        {
            InitializeComponent();
        }

        Course course = new Course();
        private void EditCourseForm_Load(object sender, EventArgs e)
        {
            //populate the combobox with courses
            comboBoxCourse.DataSource = course.GetAll();
            comboBoxCourse.DisplayMember = "label";
            comboBoxCourse.ValueMember = "id";
            //set the selected combo item to nothing
            comboBoxCourse.SelectedItem = null;
        }
        //create a function to populate the combobox and select the current course
        public void FillCombo(int index)
        {
            //the index is the combobox item index
            comboBoxCourse.DataSource = course.GetAll();
            comboBoxCourse.DisplayMember = "label";
            comboBoxCourse.ValueMember = "id";
            index = comboBoxCourse.SelectedIndex;
        }

        private void buttonEditCourse_Click(object sender, EventArgs e)
        {
            try
            {
                //edit the selecet course*/

                course.Label = textBoxlabel.Text;
                course.Hour_number = (int)numericUpDownHours.Value;
                course.Description = textBoxDescription.Text;
                course.Id= (int)comboBoxCourse.SelectedValue; 

                 
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
                        FillCombo(comboBoxCourse.SelectedIndex);
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

        private void comboBoxCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //display the selected cours data
                int id = (int)comboBoxCourse.SelectedValue;
                DataTable table = new DataTable();
                table = course.getACourseById(id);
                textBoxlabel.Text = table.Rows[0][1].ToString();
                numericUpDownHours.Value = int.Parse(table.Rows[0][2].ToString());
                textBoxDescription.Text = table.Rows[0][3].ToString();
            }
            catch 
            {

               
            }
        }
    }
}
